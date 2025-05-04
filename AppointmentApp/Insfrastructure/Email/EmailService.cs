namespace AppointmentApp.Insfrastructure.Email;

public class EmailService : IEmailService
{
    // todo: Otomatik e-posta bildirimi (mock yapılması yeterlidir)

    public Task SendAppointmentEmail()
    {
        Console.WriteLine("E-posta gönderildi.");
        return Task.CompletedTask;
    }

    public Task SendWelcomeEmail()
    {
        Console.WriteLine("E-posta gönderildi.");
        return Task.CompletedTask;
    }
}
