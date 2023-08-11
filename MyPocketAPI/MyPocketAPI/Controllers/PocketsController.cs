using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;

namespace MyPocketAPI.Controllers
{
    [Authorize]
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
    }
}
