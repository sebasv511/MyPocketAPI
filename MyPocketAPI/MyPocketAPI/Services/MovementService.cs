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
    }
}
