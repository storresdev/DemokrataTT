using AutoMapper;
using DemokrataTT.Models.Entities;
using DemokrataTT.Models.UserDtos;

namespace DemokrataTT.Mapping
{
    public class MappingConfig : Profile
    {
        /// <summary>
        /// Mapeo de los DTO necesarios
        /// </summary>
        public MappingConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
