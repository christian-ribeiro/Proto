using AutoMapper;
using Template.Arguments.Arguments.Module.General;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.General;
using Template.Domain.DTO.Module.Registration;

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

        #region EmailConfiguration
        CreateMap<OutputEmailConfiguration, EmailConfigurationDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputEmailConfiguration, InternalPropertiesEmailConfigurationDTO>();
        CreateMap<OutputEmailConfiguration, ExternalPropertiesEmailConfigurationDTO>();
        CreateMap<OutputEmailConfiguration, AuxiliaryPropertiesEmailConfigurationDTO>();

        CreateMap<InternalPropertiesEmailConfigurationDTO, OutputEmailConfiguration>();
        CreateMap<ExternalPropertiesEmailConfigurationDTO, OutputEmailConfiguration>();
        CreateMap<AuxiliaryPropertiesEmailConfigurationDTO, OutputEmailConfiguration>();
        #endregion

        #region Brand
        CreateMap<OutputBrand, BrandDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputBrand, InternalPropertiesBrandDTO>();
        CreateMap<OutputBrand, ExternalPropertiesBrandDTO>();
        CreateMap<OutputBrand, AuxiliaryPropertiesBrandDTO>();

        CreateMap<InternalPropertiesBrandDTO, OutputBrand>();
        CreateMap<ExternalPropertiesBrandDTO, OutputBrand>();
        CreateMap<AuxiliaryPropertiesBrandDTO, OutputBrand>();
        #endregion

        #region Product
        CreateMap<OutputProduct, ProductDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputProduct, InternalPropertiesProductDTO>();
        CreateMap<OutputProduct, ExternalPropertiesProductDTO>();
        CreateMap<OutputProduct, AuxiliaryPropertiesProductDTO>();

        CreateMap<InternalPropertiesProductDTO, OutputProduct>();
        CreateMap<ExternalPropertiesProductDTO, OutputProduct>();
        CreateMap<AuxiliaryPropertiesProductDTO, OutputProduct>();
        #endregion
    }
}