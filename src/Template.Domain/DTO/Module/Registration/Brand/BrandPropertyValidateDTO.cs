using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class BrandPropertyValidateDTO : BaseValidateDTO
{
    public BrandDTO? OriginalBrandDTO { get; private set; }

    public BrandPropertyValidateDTO ValidateCreate(BrandDTO? originalBrandDTO)
    {
        OriginalBrandDTO = originalBrandDTO;
        return this;
    }

    public BrandPropertyValidateDTO ValidateUpdate(BrandDTO? originalBrandDTO)
    {
        OriginalBrandDTO = originalBrandDTO;
        return this;
    }

    public BrandPropertyValidateDTO ValidateDelete(BrandDTO? originalBrandDTO)
    {
        OriginalBrandDTO = originalBrandDTO;
        return this;
    }

    public BrandPropertyValidateDTO ValidateView(BrandDTO? originalBrandDTO)
    {
        OriginalBrandDTO = originalBrandDTO;
        return this;
    }
}