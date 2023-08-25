using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string login, string password);
        Task<bool>? InsertUserAsync(User user);        
    }
}
