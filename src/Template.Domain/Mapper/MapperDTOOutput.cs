using AutoMapper;
using Template.Arguments.Arguments;
using Template.Domain.DTO;

namespace Template.Domain.Mapper;

public class MapperDTOOutput : Profile
{
    public MapperDTOOutput()
    {
        #region User
        CreateMap<OutputUser, UserDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputUser, InternalPropertiesUserDTO>();
        CreateMap<OutputUser, ExternalPropertiesUserDTO>();
        CreateMap<OutputUser, AuxiliaryPropertiesUserDTO>();

        CreateMap<InternalPropertiesUserDTO, OutputUser>();
        CreateMap<ExternalPropertiesUserDTO, OutputUser>();
        CreateMap<AuxiliaryPropertiesUserDTO, OutputUser>();
        #endregion

        #region Menu
        CreateMap<OutputMenu, MenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputMenu, InternalPropertiesMenuDTO>();
        CreateMap<OutputMenu, AuxiliaryPropertiesMenuDTO>();

        CreateMap<InternalPropertiesMenuDTO, OutputMenu>();
        CreateMap<AuxiliaryPropertiesMenuDTO, OutputMenu>();
        #endregion

        #region UserMenu
        CreateMap<OutputUserMenu, UserMenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputUserMenu, InternalPropertiesUserMenuDTO>();
        CreateMap<OutputUserMenu, ExternalPropertiesUserMenuDTO>();
        CreateMap<OutputUserMenu, AuxiliaryPropertiesUserMenuDTO>();

        CreateMap<InternalPropertiesUserMenuDTO, OutputUserMenu>();
        CreateMap<ExternalPropertiesUserMenuDTO, OutputUserMenu>();
        CreateMap<AuxiliaryPropertiesUserMenuDTO, OutputUserMenu>();
        #endregion
    }
}