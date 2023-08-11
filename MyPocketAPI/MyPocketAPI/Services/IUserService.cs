using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string login, string password);
    }
}
