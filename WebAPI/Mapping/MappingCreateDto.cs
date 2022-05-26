using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Mapping
{
    public class MappingCreateDto : Profile
    {
        public MappingCreateDto()
        {
            CreateMap<ButtonKeyboardCreateDto, ButtonKeyboard>();
        }
    }
}
