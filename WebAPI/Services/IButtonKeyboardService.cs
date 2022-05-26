using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Services
{
    public interface IButtonKeyboardService
    {
        Task<List<ButtonKeyboardReadDto>> GetAll();
        Task<ButtonKeyboardReadDto> Get(int id);
        Task<string> AddButton(ButtonKeyboardCreateDto key);
        Task<ButtonKeyboard> UpdateButton(ButtonKeyboardUpdateDto key);
        Task<List<ButtonKeyboard>> RemoveButton(int id);
    }
}
