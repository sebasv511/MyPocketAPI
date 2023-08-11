using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services.Interfaces
{
    public interface IPocketService
    {
        Task<List<PocketDetail>> GetPocketYears(long userId);
        Task<List<Month>> GetPocketMonthsByYear(long userId, int year);
    }
}
