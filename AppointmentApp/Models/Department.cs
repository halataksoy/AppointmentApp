using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
