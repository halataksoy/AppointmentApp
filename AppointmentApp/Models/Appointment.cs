using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentApp.Models
{
    public enum AppointmentStatus
    {
        Approved = 1,
        Denied = 2,
        Cancelled = 3,
        Completed = 4,
        Edited = 5,
    }

    public enum UserRole
    {
        User = 1,
        Admin = 2
    }
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Approved; // Default olarak Approved
        [BindNever]
        public int UserId { get; set; }
        [BindNever]
        [ValidateNever]
        public User User { get; set; }
    }
}
