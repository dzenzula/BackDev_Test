using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyStatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public KeyStatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetTotalClicks")]
        public async Task<ActionResult<string>> GetSumClicks()
        {
            return Ok(await _statisticService.GetClicks());
        }

        [HttpGet("GetAllKeysOnly")]
        public async Task<ActionResult<List<ButtonKeyboardUpdateDto>>> GetAllKeysOnly()
        {
            return Ok(await _statisticService.GetButtons());
        }
    }
}
