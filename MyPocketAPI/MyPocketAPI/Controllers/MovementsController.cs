using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;

namespace MyPocketAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementsController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        public async Task<List<Movement>> GetMovementsByMonth(long userId, int year, AbreviatedMonth month)
        {
            var movements = await _movementService.GetMovementsByMonth(userId, year, month);
            if (movements == null)
            {
                movements = new List<Movement>();
            }

            return movements;
        }
    }
}
