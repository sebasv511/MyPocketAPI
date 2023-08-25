using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IMovementService
    {        
        Task<List<Movement>> GetMovementsByMonth(long userId, int year, AbreviatedMonth month);
        Task<int> InsertMovement(MovementType type, string concept, decimal cost, DateTime payday, DateTime paydayLimit, MovementStatus status, long monthDetailId);
        Task<Movement?> GetMovementById(long id);
        Task<Movement> UpdateMovement(Movement movement);
        Task<bool> TransferMovement(long movementId, long periodId);
    }
}
