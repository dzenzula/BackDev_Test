using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Mapping
{
    public class MappingStatisticDto : Profile
    {
        public MappingStatisticDto()
        {
            CreateMap<ButtonKeyboard, ButtonKeyboardUpdateDto>();
        }
    }
}
