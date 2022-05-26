using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StatisticService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ButtonKeyboardUpdateDto>> GetButtons()
        {
            var buttons = await _context.ButtonsKeyboard.ToListAsync();
            var buttonsDto = _mapper.Map<List<ButtonKeyboardUpdateDto>>(buttons);
            return buttonsDto;
        }

        public async Task<string> GetClicks()
        {
            var totalClicks = await _context.ButtonsKeyboard.SumAsync(i => i.ClickAmount);
            var result = $"Total clicks: " + totalClicks.ToString();
            return result;
        }
    }
}
