namespace Proto.Domain.DTO.Module.Base;

public class BaseValidateDTO
{
    public bool Invalid { get; private set; }

    public bool SetInvalid()
    {
        return Invalid = true;
    }
}