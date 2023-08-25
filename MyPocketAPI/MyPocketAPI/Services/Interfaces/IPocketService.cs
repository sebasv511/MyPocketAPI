using Microsoft.VisualBasic;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IPocketService
    {
        Task<int> InsertPocket(long userId);
        Task<Pocket?> GetPocketById(int id);

        Task<int> InsertYear(long pocketId, int year);
        Task<PocketDetail?> GetPocketDetailById(int id);

        Task<int> InsertMonth(long pocketDetailId, AbreviatedMonth month);
        Task<Month?> GetMonthById(long monthId);

        Task<int> InsertPeriod(long monthId, int period);
        Task<MonthDetail?> GetMonthDetailById(long monthId);

        Task<List<PocketDetail>> GetPocketYears(long userId);
        Task<List<Month>> GetPocketMonthsByYear(long userId, int year);
        Task<List<MonthDetail>> GetPocketPeriodsByMonth(long userId, int year, AbreviatedMonth month);
    }
}
