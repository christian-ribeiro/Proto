using AutoMapper;
using Template.Domain.DTO.Module.General;
using Template.Domain.DTO.Module.Registration;
using Template.Infrastructure.Persistence.Entry.Module.General;
using Template.Infrastructure.Persistence.Entry.Module.Registration;

namespace Template.Infrastructure.Mapper;

public class MapperEntryDTO : Profile
{
    public MapperEntryDTO()
    {
        #region User
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<User, InternalPropertiesUserDTO>();
        CreateMap<User, ExternalPropertiesUserDTO>();
        CreateMap<User, AuxiliaryPropertiesUserDTO>();

        CreateMap<InternalPropertiesUserDTO, User>();
        CreateMap<ExternalPropertiesUserDTO, User>();
        CreateMap<AuxiliaryPropertiesUserDTO, User>();
        #endregion

        #region Menu
        CreateMap<Menu, MenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<Menu, InternalPropertiesMenuDTO>();
        CreateMap<Menu, AuxiliaryPropertiesMenuDTO>();

        CreateMap<InternalPropertiesMenuDTO, Menu>();
        CreateMap<AuxiliaryPropertiesMenuDTO, Menu>();
        #endregion

        #region UserMenu
        CreateMap<UserMenu, UserMenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<UserMenu, InternalPropertiesUserMenuDTO>();
        CreateMap<UserMenu, ExternalPropertiesUserMenuDTO>();
        CreateMap<UserMenu, AuxiliaryPropertiesUserMenuDTO>();

        CreateMap<InternalPropertiesUserMenuDTO, UserMenu>();
        CreateMap<ExternalPropertiesUserMenuDTO, UserMenu>();
        CreateMap<AuxiliaryPropertiesUserMenuDTO, UserMenu>();
        #endregion

        #region EmailConfiguration
        CreateMap<EmailConfiguration, EmailConfigurationDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<EmailConfiguration, InternalPropertiesEmailConfigurationDTO>();
        CreateMap<EmailConfiguration, ExternalPropertiesEmailConfigurationDTO>();
        CreateMap<EmailConfiguration, AuxiliaryPropertiesEmailConfigurationDTO>();

        CreateMap<InternalPropertiesEmailConfigurationDTO, EmailConfiguration>();
        CreateMap<ExternalPropertiesEmailConfigurationDTO, EmailConfiguration>();
        CreateMap<AuxiliaryPropertiesEmailConfigurationDTO, EmailConfiguration>();
        #endregion
    }
}