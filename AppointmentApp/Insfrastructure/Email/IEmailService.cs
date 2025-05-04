namespace AppointmentApp.Insfrastructure.Email;

public interface IEmailService
{
    Task SendAppointmentEmail();
    Task SendWelcomeEmail();
}
