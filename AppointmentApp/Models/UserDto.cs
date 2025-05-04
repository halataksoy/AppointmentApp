using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
