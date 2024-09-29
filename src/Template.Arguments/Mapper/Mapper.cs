using AutoMapper;

namespace Template.Api.Mapper;

public class Mapper(IMapper mapperDTOOutput, IMapper MapperEntityDTO, IMapper mapperInputDTO)
{
    public IMapper MapperDTOOutput { get; private set; } = mapperDTOOutput;
    public IMapper MapperEntityDTO { get; private set; } = MapperEntityDTO;
    public IMapper MapperInputDTO { get; private set; } = mapperInputDTO;
}