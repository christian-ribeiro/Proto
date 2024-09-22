using AutoMapper;

namespace Template.Api.Mapper;

public class Mapper(IMapper mapperDTOOutput, IMapper MapperEntryDTO, IMapper mapperInputDTO)
{
    public IMapper MapperDTOOutput { get; private set; } = mapperDTOOutput;
    public IMapper MapperEntryDTO { get; private set; } = MapperEntryDTO;
    public IMapper MapperInputDTO { get; private set; } = mapperInputDTO;
}