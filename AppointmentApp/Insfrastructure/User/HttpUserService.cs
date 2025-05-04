using AppointmentApp.Models;
using System.Security.Claims;

namespace AppointmentApp.Insfrastructure.User;

public class HttpUserService(IHttpContextAccessor httpContext) : IUserService
{
    private HttpContext GetContext => httpContext.HttpContext ?? throw new Exception("HttpContext not found");

    public UserRole GetRole()
    {
        string? role = GetContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(role))
        {
            throw new Exception("User not found");
        }

        if (Enum.TryParse(role, out UserRole userRole))
        {
            return userRole;
        }

        throw new Exception("User role is not valid value");
    }

    public int GetUserId()
    {
        string? userId = GetContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("User not found");
        }

        if (int.TryParse(userId, out int id))
        {
            return id;
        }

        throw new Exception("User ID is not a valid integer");
    }

    public string GetUserName()
    {
        string? username = GetContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("User not found");
        }

        return username;
    }
}
