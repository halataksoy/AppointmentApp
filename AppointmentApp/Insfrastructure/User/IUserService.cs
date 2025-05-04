using AppointmentApp.Models;

namespace AppointmentApp.Insfrastructure.User;

public interface IUserService
{
    string GetUserName();
    int GetUserId();
    UserRole GetRole();
}
