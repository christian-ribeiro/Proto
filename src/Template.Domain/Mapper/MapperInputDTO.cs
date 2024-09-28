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

        #region UserMenu
        CreateMap<InputCreateUserMenu, UserMenuDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateUserMenu, UserMenuDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateUserMenu, ExternalPropertiesUserMenuDTO>();
        CreateMap<InputUpdateUserMenu, ExternalPropertiesUserMenuDTO>();
        #endregion
    }
}