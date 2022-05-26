using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValuesController : ControllerBase
    {
        private readonly IButtonKeyboardService _buttonKeyboardService;

        public KeyValuesController(IButtonKeyboardService buttonKeyboardService)
        {
            _buttonKeyboardService = buttonKeyboardService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ButtonKeyboardReadDto>>> GetAll()
        {
            var list = await _buttonKeyboardService.GetAll();
            return Ok(list);
        }

        [HttpGet("GetButtonById")]
        public async Task<ActionResult<ButtonKeyboardReadDto>> Get(int id)
        {
            var button = await _buttonKeyboardService.Get(id);

            if (button == null)
                return NotFound();

            return Ok(button);
        }

        [HttpPost("AddButton")]
        public async Task<ActionResult<string>> Add(ButtonKeyboardCreateDto key)
        {
            var button = await _buttonKeyboardService.AddButton(key);

            if (button == null)
                return BadRequest("This button already exist!");

            return Ok(key.Name.ToUpper() + " button was " + button);
        }

        [HttpPut("UpdateButton")]
        public async Task<ActionResult<ButtonKeyboard>> Update(ButtonKeyboardUpdateDto key)
        {
            var button = await _buttonKeyboardService.UpdateButton(key);

            if (button == null)
                return NotFound();

            return Ok(button);
        }

        [HttpDelete("DeleteButton")]
        public async Task<ActionResult<List<ButtonKeyboard>>> Delete(int id)
        {
            var dbButton = _buttonKeyboardService.RemoveButton(id);

            if (dbButton == null)
                return NotFound();

            return Ok(dbButton);
        }
    }
}
