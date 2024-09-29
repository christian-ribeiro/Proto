using AutoMapper;
using Proto.Arguments.Arguments.Module.General;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.General;
using Proto.Domain.DTO.Module.Registration;

namespace Proto.Domain.Mapper;

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

        #region EmailConfiguration
        CreateMap<InputCreateEmailConfiguration, EmailConfigurationDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateEmailConfiguration, EmailConfigurationDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateEmailConfiguration, ExternalPropertiesEmailConfigurationDTO>();
        CreateMap<InputUpdateEmailConfiguration, ExternalPropertiesEmailConfigurationDTO>();
        #endregion

        #region Brand
        CreateMap<InputCreateBrand, BrandDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateBrand, BrandDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateBrand, ExternalPropertiesBrandDTO>();
        CreateMap<InputUpdateBrand, ExternalPropertiesBrandDTO>();
        #endregion

        #region Product
        CreateMap<InputCreateProduct, ProductDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateProduct, ProductDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateProduct, ExternalPropertiesProductDTO>();
        CreateMap<InputUpdateProduct, ExternalPropertiesProductDTO>();
        #endregion

        #region ProductCategory
        CreateMap<InputCreateProductCategory, ProductCategoryDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputUpdateProductCategory, ProductCategoryDTO>()
            .ForMember(dest => dest.ExternalPropertiesDTO, opt => opt.MapFrom(src => src));

        CreateMap<InputCreateProductCategory, ExternalPropertiesProductCategoryDTO>();
        CreateMap<InputUpdateProductCategory, ExternalPropertiesProductCategoryDTO>();
        #endregion
    }
}