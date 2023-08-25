using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Data;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace MyPocketAPI.Services
{
    public class MovementService : IMovementService
    {
        private readonly MyPocketDbContext _context;
        public MovementService(MyPocketDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Movement>> GetMovementsByMonth(long userId, int year, AbreviatedMonth month)
        {
            var movements = new List<Movement>();
            if (_context.Movements != null)
            {
                movements = await _context.Movements
                    .Where(m => m.MonthDetail.Month.PocketDetail.Pocket.UserId == userId &&
                    m.MonthDetail.Month.PocketDetail.year == year &&
                    m.MonthDetail.Month.MonthNumber == month)
                    .ToListAsync();
            }
            return movements;
        }

        public async Task<int> InsertMovement(MovementType type, string concept, decimal cost, DateTime payday, DateTime paydayLimit, MovementStatus status, long monthDetailId)
        {
            var newMov = _context.Movements.Add(new Movement
            {
                Type = type,
                Concept = concept,
                Cost = cost,
                Payday = payday,
                PaydayLimit = paydayLimit,
                State = status,
                MonthDetailId = monthDetailId
            });

            return await _context.SaveChangesAsync();       
        }

        public async Task<Movement?> GetMovementById(long id)
        {
            var movimiento = await _context.Movements.FirstOrDefaultAsync(m => m.MovementId == id);
            return movimiento;
        }

        public async Task<Movement> UpdateMovement(Movement movement)
        {
            _context.Movements.Update(movement);
            var idMovement = await _context.SaveChangesAsync();

            return await _context.Movements.FirstAsync(m => m.MovementId == idMovement);
        }
        public async Task<bool> TransferMovement(long movementId, long periodId)
        {
            var movement = await GetMovementById(movementId);
            if (movement != null)
            {
                movement.MonthDetailId = periodId;
                _context.Movements.Attach(movement).Property(m=> m.MonthDetailId).IsModified = true;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
