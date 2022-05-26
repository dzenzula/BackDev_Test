using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Mapping
{
    public class MappingReadDto : Profile
    {
        public MappingReadDto()
        {
            CreateMap<ButtonKeyboard, ButtonKeyboardReadDto>();
        }
    }
}
