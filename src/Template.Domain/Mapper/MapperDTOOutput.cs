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

        CreateMap<OutputUser, InternalPropertiesUserDTO>().ReverseMap();
        CreateMap<OutputUser, ExternalPropertiesUserDTO>().ReverseMap();
        CreateMap<OutputUser, AuxiliaryPropertiesUserDTO>().ReverseMap();
        #endregion

        #region Menu
        CreateMap<OutputMenu, MenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputMenu, InternalPropertiesMenuDTO>().ReverseMap();
        CreateMap<OutputMenu, AuxiliaryPropertiesMenuDTO>().ReverseMap();
        #endregion

        #region UserMenu
        CreateMap<OutputUserMenu, UserMenuDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputUserMenu, InternalPropertiesUserMenuDTO>().ReverseMap();
        CreateMap<OutputUserMenu, ExternalPropertiesUserMenuDTO>().ReverseMap();
        CreateMap<OutputUserMenu, AuxiliaryPropertiesUserMenuDTO>().ReverseMap();
        #endregion

        #region EmailConfiguration
        CreateMap<OutputEmailConfiguration, EmailConfigurationDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputEmailConfiguration, InternalPropertiesEmailConfigurationDTO>().ReverseMap();
        CreateMap<OutputEmailConfiguration, ExternalPropertiesEmailConfigurationDTO>().ReverseMap();
        CreateMap<OutputEmailConfiguration, AuxiliaryPropertiesEmailConfigurationDTO>().ReverseMap();
        #endregion

        #region Brand
        CreateMap<OutputBrand, BrandDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputBrand, InternalPropertiesBrandDTO>().ReverseMap();
        CreateMap<OutputBrand, ExternalPropertiesBrandDTO>().ReverseMap();
        CreateMap<OutputBrand, AuxiliaryPropertiesBrandDTO>().ReverseMap();
        #endregion

        #region Product
        CreateMap<OutputProduct, ProductDTO>()
            .ForMember(dest => dest.InternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AuxiliaryPropertiesDTO, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<OutputProduct, InternalPropertiesProductDTO>().ReverseMap();
        CreateMap<OutputProduct, ExternalPropertiesProductDTO>().ReverseMap();
        CreateMap<OutputProduct, AuxiliaryPropertiesProductDTO>().ReverseMap();
        #endregion
    }
}