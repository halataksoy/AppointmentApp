using AppointmentApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AppointmentApp.Insfrastructure.Email;

namespace AppointmentApp.Pages.Appointment
{
    [Authorize(Roles = "User")]
    public class CreateAppointmentModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public CreateAppointmentModel(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [BindProperty]
        public AppointmentDto Appointment { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }

        public IActionResult OnGet()
        {
            LoadDepartments();
            return Page();
        }

        public async Task<IActionResult> OnPostSave()
        {
            LoadDepartments();

            if (Appointment.DateTime <= DateTime.Now)
            {
                ModelState.AddModelError("Appointment.DateTime", "Geçmiþ tarihli randevu alýnamaz.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            Appointment.UserId = int.Parse(userIdClaim.Value);

            var newAppointment = new Models.Appointment
            {
                DepartmentId = Appointment.DepartmentId,
                DateTime = Appointment.DateTime,
                UserId = Appointment.UserId,
                Status = AppointmentStatus.Approved
            };

            _context.Appointments.Add(newAppointment);
            _context.SaveChanges();

            // E-posta gönderme iþlemi burada yapýlabilir
            // Kullanýcý email gönderimini beklemek zorunda deðil (Asenkron çalýþmalý)
            Task.Run(async () =>
            {
                await _emailService.SendAppointmentEmail();
            });

            return RedirectToPage("Index");
        }

        private void LoadDepartments()
        {
            DepartmentList = _context.Departments
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
        }
    }
}

