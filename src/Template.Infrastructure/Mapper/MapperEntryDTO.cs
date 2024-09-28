using AutoMapper;
using Template.Domain.DTO;
using Template.Infrastructure.Persistence.Entry;

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
    }
}