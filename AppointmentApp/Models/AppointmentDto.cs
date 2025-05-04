using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppointmentApp.Models;

public class AppointmentDto
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }
    [BindNever]
    [ValidateNever]
    public string DepartmentName { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }
    [BindNever]
    [ValidateNever]
    public string UserName { get; set; }

    public AppointmentStatus Status { get; set; }

    public string GetStatusText(UserRole userRole)
    {
        return Status switch
        {
            AppointmentStatus.Approved => "Randevu Oluşturuldu",
            AppointmentStatus.Denied => userRole == UserRole.Admin
                ? "Randevu reddedilmiştir."
                : "Doktorunuz tarafından randevunuz reddedilmiştir.",
            AppointmentStatus.Cancelled => "Hasta tarafından randevu iptal edildi.",
            AppointmentStatus.Completed => "Randevunuz gerçekleştirilmiştir.",
            AppointmentStatus.Edited =>
             userRole == UserRole.User
                ? "Randevunuz güncellenmiştir."
                : "Hasta tarafından randevu tarihi ve saati değiştirilmiştir.",
            _ => ""
        };
    }


}
