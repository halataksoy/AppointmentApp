using Microsoft.EntityFrameworkCore;
using AppointmentApp.Models;

namespace AppointmentApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kullanıcı ekle
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "123" , Role = UserRole.Admin },
                new User { Id = 2, UserName = "testuser", Password = "456", Role = UserRole.User },
                new User { Id = 3, UserName = "ali", Password = "1234", Role = UserRole.User },
                new User { Id = 4, UserName = "ayse", Password = "1234", Role = UserRole.User }
            );

            //Randevu ekle
            modelBuilder.Entity<Appointment>().HasData(
            // User 2 - testuser
            new Appointment { Id = 1, DepartmentId = 1, DateTime = new DateTime(2025, 4, 10, 10, 0, 0), UserId = 2, Status = AppointmentStatus.Approved },
            new Appointment { Id = 2, DepartmentId = 2, DateTime = new DateTime(2025, 4, 28, 11, 0, 0), UserId = 2, Status = AppointmentStatus.Denied },
            new Appointment { Id = 3, DepartmentId = 3, DateTime = new DateTime(2025, 5, 5, 14, 0, 0), UserId = 2, Status = AppointmentStatus.Approved },
            new Appointment { Id = 4, DepartmentId = 4, DateTime = new DateTime(2025, 5, 10, 16, 0, 0), UserId = 2, Status = AppointmentStatus.Cancelled },
            new Appointment { Id = 5, DepartmentId = 5, DateTime = new DateTime(2025, 6, 1, 9, 0, 0), UserId = 2, Status = AppointmentStatus.Approved },
            new Appointment { Id = 6, DepartmentId = 6, DateTime = new DateTime(2025, 6, 3, 13, 30, 0), UserId = 2, Status = AppointmentStatus.Denied },
            new Appointment { Id = 7, DepartmentId = 7, DateTime = new DateTime(2025, 6, 5, 15, 45, 0), UserId = 2, Status = AppointmentStatus.Cancelled },

            // User 3 - ali
            new Appointment { Id = 8, DepartmentId = 1, DateTime = new DateTime(2025, 4, 12, 9, 0, 0), UserId = 3, Status = AppointmentStatus.Cancelled },
            new Appointment { Id = 9, DepartmentId = 2, DateTime = new DateTime(2025, 5, 3, 10, 30, 0), UserId = 3, Status = AppointmentStatus.Approved },
            new Appointment { Id = 10, DepartmentId = 3, DateTime = new DateTime(2025, 5, 7, 12, 0, 0), UserId = 3, Status = AppointmentStatus.Denied },
            new Appointment { Id = 11, DepartmentId = 4, DateTime = new DateTime(2025, 5, 14, 14, 30, 0), UserId = 3, Status = AppointmentStatus.Approved },
            new Appointment { Id = 12, DepartmentId = 5, DateTime = new DateTime(2025, 6, 6, 10, 15, 0), UserId = 3, Status = AppointmentStatus.Approved },
            new Appointment { Id = 13, DepartmentId = 6, DateTime = new DateTime(2025, 6, 10, 11, 45, 0), UserId = 3, Status = AppointmentStatus.Cancelled },
            new Appointment { Id = 14, DepartmentId = 7, DateTime = new DateTime(2025, 6, 12, 13, 0, 0), UserId = 3, Status = AppointmentStatus.Denied },

            // User 4 - ayse
            new Appointment { Id = 15, DepartmentId = 1, DateTime = new DateTime(2025, 4, 18, 10, 30, 0), UserId = 4, Status = AppointmentStatus.Denied },
            new Appointment { Id = 16, DepartmentId = 2, DateTime = new DateTime(2025, 5, 2, 14, 15, 0), UserId = 4, Status = AppointmentStatus.Approved },
            new Appointment { Id = 17, DepartmentId = 3, DateTime = new DateTime(2025, 5, 8, 15, 30, 0), UserId = 4, Status = AppointmentStatus.Cancelled },
            new Appointment { Id = 18, DepartmentId = 4, DateTime = new DateTime(2025, 5, 16, 9, 45, 0), UserId = 4, Status = AppointmentStatus.Approved },
            new Appointment { Id = 19, DepartmentId = 5, DateTime = new DateTime(2025, 6, 2, 10, 0, 0), UserId = 4, Status = AppointmentStatus.Approved },
            new Appointment { Id = 20, DepartmentId = 6, DateTime = new DateTime(2025, 6, 4, 12, 30, 0), UserId = 4, Status = AppointmentStatus.Denied },
            new Appointment { Id = 21, DepartmentId = 7, DateTime = new DateTime(2025, 6, 8, 14, 0, 0), UserId = 4, Status = AppointmentStatus.Cancelled }
        );


            //Departman ekle
            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Dahiliye" },
            new Department { Id = 2, Name = "Kardiyoloji" },
            new Department { Id = 3, Name = "Göz" },
            new Department { Id = 4, Name = "Ortopedi" },
            new Department { Id = 5, Name = "Nöroloji" },
            new Department { Id = 6, Name = "Kulak Burun Boğaz" },
            new Department { Id = 7, Name = "Üroloji" },
            new Department { Id = 8, Name = "Dermatoloji" },
            new Department { Id = 9, Name = "Psikiyatri" },
            new Department { Id = 10, Name = "Genel Cerrahi" },
            new Department { Id = 11, Name = "Kadın Doğum" },
            new Department { Id = 12, Name = "Pediatri (Çocuk)" },
            new Department { Id = 13, Name = "Endokrinoloji" },
            new Department { Id = 14, Name = "Göğüs Hastalıkları" },
            new Department { Id = 15, Name = "Enfeksiyon Hastalıkları" },
            new Department { Id = 16, Name = "Gastroenteroloji" },
            new Department { Id = 17, Name = "Radyoloji" },
            new Department { Id = 18, Name = "Anestezi" },
            new Department { Id = 19, Name = "Hematoloji" },
            new Department { Id = 20, Name = "Onkoloji" }
        );

            base.OnModelCreating(modelBuilder);
        }


    }
}
