using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}
