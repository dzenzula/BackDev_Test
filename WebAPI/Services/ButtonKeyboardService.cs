using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Services
{
    public class ButtonKeyboardService : IButtonKeyboardService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ButtonKeyboardService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddButton(ButtonKeyboardCreateDto key)
        {
            var check = await _context.ButtonsKeyboard.FirstOrDefaultAsync(c => c.Name.ToLower() == key.Name.ToLower());
            _context.ChangeTracker.DetectChanges();
            var button = _mapper.Map<ButtonKeyboard>(key);
            var currState = String.Empty;

            if (check == null)
            {
                [DllImport("user32.dll")] static extern short VkKeyScan(char ch);
                var ch = key.Name.ToLower().ToCharArray()[0];

                button.Code = VkKeyScan(ch);
                button.Name = button.Name.ToUpper();

                _context.ButtonsKeyboard.Add(button);
                currState = _context.Entry(button).State.ToString();
            }
            else
            {
                check.ClickAmount = key.ClickAmount;
                _context.Update(check);
                currState = _context.Entry(check).State.ToString();
            }

            await _context.SaveChangesAsync();
            return currState;
        }

        public async Task<ButtonKeyboardReadDto> Get(int id)
        {
            var button = await _context.ButtonsKeyboard.FindAsync(id);
            var buttonDto = _mapper.Map<ButtonKeyboardReadDto>(button);

            return buttonDto;
        }

        public async Task<List<ButtonKeyboardReadDto>> GetAll()
        {
            var buttons = await _context.ButtonsKeyboard.ToListAsync();
            var buttonsDto = _mapper.Map<List<ButtonKeyboardReadDto>>(buttons);

            return buttonsDto;
        }

        public async Task<List<ButtonKeyboard>> RemoveButton(int id)
        {
            var dbKey = await _context.ButtonsKeyboard.FindAsync(id);
            _context.Remove(dbKey);
            await _context.SaveChangesAsync();

            return await _context.ButtonsKeyboard.ToListAsync();
        }

        public async Task<ButtonKeyboard> UpdateButton(ButtonKeyboardUpdateDto key)
        {
            var dbButton = await _context.ButtonsKeyboard.FirstOrDefaultAsync(n => n.Name == key.Name);

            var dbButtonDto = _mapper.Map(key, dbButton);

            await _context.SaveChangesAsync();

            return dbButtonDto;
        }
    }
}
