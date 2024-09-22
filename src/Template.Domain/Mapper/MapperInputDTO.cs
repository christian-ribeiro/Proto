using AutoMapper;
using Template.Arguments.Arguments;
using Template.Domain.DTO;

namespace Template.Domain.Mapper;

public class MapperInputDTO : Profile
{
    public MapperInputDTO()
    {
        #region User
        CreateMap<InputCreateUser, UserDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateUser, UserDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateUser, ExternalPropertiesUserDTO>();
        CreateMap<InputUpdateUser, ExternalPropertiesUserDTO>();
        #endregion
    }
}