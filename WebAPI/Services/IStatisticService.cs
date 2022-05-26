using WebAPI.Models.DTO;

namespace WebAPI.Services
{
    public interface IStatisticService
    {
        Task<string> GetClicks();
        Task<List<ButtonKeyboardUpdateDto>> GetButtons();
    }
}
