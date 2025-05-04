using AppointmentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApp.Pages.Appointment
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<AppointmentDto> Appointments { get; set; }
        [BindProperty]
        public AppointmentDto EditableAppointment { get; set; }
        public async Task OnGetAsync()
        {
            var username = User.Identity?.Name;

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                Appointments = new List<AppointmentDto>();
                return;
            }

            var now = DateTime.Now;

            // Geçmiþ randevularý completed yap
            var pastAppointments = await _context.Appointments
                .Where(a => a.UserId == user.Id && a.Status == AppointmentStatus.Approved && a.DateTime <= now)
                .ToListAsync();

            foreach (var appt in pastAppointments)
            {
                appt.Status = AppointmentStatus.Completed;
            }

            if (pastAppointments.Any())
                await _context.SaveChangesAsync();

            // Tüm aktif ve geçmiþ randevularý çek
            var appointments = await _context.Appointments
                .AsNoTracking()
                .Where(a => a.UserId == user.Id && a.Status != AppointmentStatus.Cancelled)
                .Include(a => a.Department)
                .Select(x => new AppointmentDto
                {
                    Id = x.Id,
                    DateTime = x.DateTime,
                    UserId = x.UserId,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.Name,
                    Status = x.Status
                })
                .ToListAsync();

            Appointments = appointments ?? new List<AppointmentDto>();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id, DateTime dateTime)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null || appointment.Status == AppointmentStatus.Cancelled)
            {
                return BadRequest();
            }

            if (dateTime <= DateTime.Now)
            {
                ModelState.AddModelError("", "Geçmiþ bir tarih seçilemez.");
                return RedirectToPage();
            }

            appointment.DateTime = dateTime;
            appointment.Status = AppointmentStatus.Edited;
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDeleteAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if (appointment == null || appointment.Status == AppointmentStatus.Cancelled || appointment.DateTime <= DateTime.Now)
            {
                return BadRequest();
            }

            appointment.Status = AppointmentStatus.Cancelled;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}

