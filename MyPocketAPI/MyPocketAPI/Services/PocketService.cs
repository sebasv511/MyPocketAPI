using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Data;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;
using System.ComponentModel;

namespace MyPocketAPI.Services
{
    public class PocketService : IPocketService
    {
        private readonly MyPocketDbContext _context;
        public PocketService(MyPocketDbContext context)
        {
            _context = context;
        }

        public async Task<List<PocketDetail>> GetPocketYears(long userId)
        {
            var years = new List<PocketDetail>();
            if (_context.PocketsDetail != null)
            {
                years = await _context.PocketsDetail
                    .Where(p => p.Pocket.UserId == userId)
                    .ToListAsync();
            }
            return years;
        }

        public async Task<List<Month>> GetPocketMonthsByYear(long userId, int year)
        {
            var months = new List<Month>();
            if (_context.Months != null)
            {
                months = await _context.Months
                    .Where(m => m.PocketDetail.Pocket.UserId == userId && m.PocketDetail.year == year)
                    .ToListAsync();
            }
            return months;
        }
    }
}
