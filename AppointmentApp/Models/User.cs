using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;

        public ICollection<Appointment> Appointments { get; set; }
    }
}
