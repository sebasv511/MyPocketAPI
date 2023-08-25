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
        
        public async Task<int> InsertPocket(long userId)
        {
            var newPocket = _context.Pocket.Add(new Pocket { UserId = userId });
            return await _context.SaveChangesAsync();
        }
        public async Task<Pocket?> GetPocketById(int id)
        {
            var pocket = await _context.Pocket.FirstOrDefaultAsync(p=> p.PocketId== id);
            return pocket;
        }

        public async Task<int> InsertYear(long pocketId, int _year)
        {            
            var newPocketDetail = _context.PocketsDetail.Add(new PocketDetail { year = _year, PocketId = pocketId });
            return await _context.SaveChangesAsync();
        }
        public async Task<PocketDetail?> GetPocketDetailById(int pocketDetailId)
        {
            var pocketDetail = await _context.PocketsDetail.FirstOrDefaultAsync(d => d.PocketDetailId== pocketDetailId);
            return pocketDetail;
        }

        public async Task<int> InsertMonth(long pocketDetailId, AbreviatedMonth month)
        {
            var newMonth = _context.Months.Add(new Month { MonthNumber = month, PocketDetailId = pocketDetailId });
            return await _context.SaveChangesAsync();
        }
        public async Task<Month?> GetMonthById(long monthId)
        {
            var month = await _context.Months.FirstOrDefaultAsync(m => m.MonthId== monthId);
            return month;
        }

        public async Task<int> InsertPeriod(long monthId, int period)
        {
            var newMonthDetail = _context.MonthDetail.Add(new MonthDetail { Period = period, MonthId = monthId });
            return await _context.SaveChangesAsync();
        }
        public async Task<MonthDetail?> GetMonthDetailById(long monthDetailId)
        {
            var monthDetail = await _context.MonthDetail.FirstOrDefaultAsync(d => d.MonthDetailId== monthDetailId);
            return monthDetail;
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
        public async Task<List<MonthDetail>> GetPocketPeriodsByMonth(long userId, int year, AbreviatedMonth month)
        {
            var periods = new List<MonthDetail>();
            if (_context.MonthDetail != null)
            {
                periods = await _context.MonthDetail
                    .Where(p => p.Month.PocketDetail.Pocket.UserId == userId && p.Month.MonthNumber == month && p.Month.PocketDetail.year == year)
                    .ToListAsync();
            }
            return periods;
        }
    }
}
