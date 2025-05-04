using AppointmentApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<AppointmentDto> AllAppointments { get; set; }

        public async Task OnGetAsync()
        {
            AllAppointments = await _context.Appointments
              .AsNoTracking()
              .Include(a => a.User)
              .Include(a => a.Department)
              .Select(a => new AppointmentDto
              {
                  Id = a.Id,
                  DepartmentId = a.DepartmentId,
                  DepartmentName = a.Department.Name,
                  DateTime = a.DateTime,
                  UserId = a.UserId,
                  UserName = a.User.UserName, // burasý önemli
                  Status = a.Status
              })
              .OrderByDescending(a => a.DateTime)
              .ToListAsync();
        }

        public async Task<IActionResult> OnPostRejectAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if (appointment == null || appointment.Status != AppointmentStatus.Approved)
                return BadRequest();

            appointment.Status = AppointmentStatus.Denied;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
