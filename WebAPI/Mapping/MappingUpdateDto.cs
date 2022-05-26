using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Mapping
{
    public class MappingUpdateDto : Profile
    {
        public MappingUpdateDto()
        {
            CreateMap<ButtonKeyboardUpdateDto, ButtonKeyboard>();
        }
    }
}
