using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string email, string phone, string password);
    }
}
