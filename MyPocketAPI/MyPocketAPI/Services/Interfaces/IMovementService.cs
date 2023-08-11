using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IMovementService
    {        
        Task<List<Movement>> GetMovementsByMonth(long userId, int year, AbreviatedMonth month);        
    }
}
