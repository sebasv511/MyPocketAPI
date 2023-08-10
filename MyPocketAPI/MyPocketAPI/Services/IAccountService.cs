using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}
