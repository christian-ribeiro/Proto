using AutoMapper;
using Proto.Arguments.General.Session;
using Proto.Domain.Mapper;
using Proto.Infrastructure.Mapper;

namespace Proto.Api.Extensions;

public static class MapperExtension
{
    public static IServiceCollection ConfigureMapper(this IServiceCollection services)
    {
        SessionData.SetMapper(new Mapper.Mapper(
            new MapperConfiguration(config => { config.AddProfile(new MapperDTOOutput()); }).CreateMapper(),
            new MapperConfiguration(config => { config.AddProfile(new MapperEntityDTO()); }).CreateMapper(),
            new MapperConfiguration(config => { config.AddProfile(new MapperInputDTO()); }).CreateMapper()));

        return services;
    }
}