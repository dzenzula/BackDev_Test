using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Nodes;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UploadController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Upload(JsonValue value)
        {
            var json = JsonSerializer.Deserialize<List<ButtonKeyboard>>(value);
            foreach (var buttonKeyboard in json)
            {
                var check = await _context.ButtonsKeyboard.FirstOrDefaultAsync(c => c.Name.ToLower() == buttonKeyboard.Name.ToLower());

                if (check != null)
                {
                    check.ClickAmount += buttonKeyboard.ClickAmount;
                }
                else
                {
                    _context.ButtonsKeyboard.Add(buttonKeyboard);
                }
            }
            _context.SaveChanges();
            return Ok(value);
        }
    }
}
