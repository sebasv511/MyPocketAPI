using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;
using System.Linq.Expressions;

namespace MyPocketAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PocketsController : ControllerBase
    {
        private readonly IPocketService _pocketService;

        public PocketsController(IPocketService pocketService)
        {
            _pocketService = pocketService;
        }

        [HttpGet("Years")]
        public async Task<List<PocketDetail>> GetPocketYears(long userId)
        {
            var years = await _pocketService.GetPocketYears(userId);
            if (years == null)
            {
                years = new List<PocketDetail>();
            }

            return years;
        }

        [HttpGet("Months")]
        public async Task<List<Month>> GetMonthsByYear(long userId, int year)
        {
            var months = await _pocketService.GetPocketMonthsByYear(userId, year);
            if (months == null)
            {
                months = new List<Month>();
            }

            return months;
        }

        [HttpGet("Periods")]
        public async Task<List<MonthDetail>> GetPeriodsByMonth(long userId, int year, AbreviatedMonth month)
        {
            var periods = await _pocketService.GetPocketPeriodsByMonth(userId, year, month);
            if (periods == null)
            {
                periods = new List<MonthDetail>();
            }

            return periods;
        }



        [HttpPost("Pocket/CreatePocket")]
        public async Task<Pocket?> CreatePocket(long userId)
        {
            var newPocketId = await _pocketService.InsertPocket(userId);
            var pocket = await _pocketService.GetPocketById(newPocketId);

            return pocket;
        }

        [HttpPost("Pocket/CreateYear")]
        public async Task<PocketDetail?> CreateYear(long pocketId, int year)
        {
            var newPocketDetailId = await _pocketService.InsertYear(pocketId, year);
            var pocketDetail = await _pocketService.GetPocketDetailById(newPocketDetailId);

            return pocketDetail;
        }

        [HttpPost("Pocket/CreateMonth")]
        public async Task<Month?> CreateMonth(long pocketDetailId, AbreviatedMonth month)
        {
            var newMonthId = await _pocketService.InsertMonth(pocketDetailId, month);
            var newMonth = await _pocketService.GetMonthById(newMonthId);
            return newMonth;
        }

        [HttpPost("Pocket/CreatePeriod")]
        public async Task<MonthDetail?> CreatePeriod(long monthId, int period)
        {
            var newMonthDetailId = await _pocketService.InsertPeriod(monthId, period);
            var monthDetail = await _pocketService.GetMonthDetailById(newMonthDetailId);
            return monthDetail;

        }
    }
}
