using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPocketAPI.Data.Enumerations;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services;
using MyPocketAPI.Services.Interfaces;

namespace MyPocketAPI.Controllers
{
    //[Authorize]
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

        [HttpPost("Movements/CreateMovement")]
        public async Task<Movement?> CreateMovement(MovementType type, string concept, decimal cost, DateTime payday, DateTime paydayLimit, MovementStatus status, long monthDetailId)
        {
            var newMovId = await _movementService.InsertMovement(type, concept, cost,payday,paydayLimit, status, monthDetailId);
            var newMovement = await _movementService.GetMovementById(newMovId);
            return newMovement;
        }

        [HttpPut("Movements/Update")]
        public async Task<Movement> UpdateMovement(Movement movement)
        {
            return await _movementService.UpdateMovement(movement);
        }

        [HttpPut("Movements/Transfer")]
        public async Task<bool> TransferMovement(long movementId, long periodId)
        {
            return await _movementService.TransferMovement(movementId, periodId);
        }
    }
}
