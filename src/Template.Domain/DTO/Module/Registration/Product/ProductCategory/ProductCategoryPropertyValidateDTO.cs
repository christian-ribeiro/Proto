using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ProductCategoryPropertyValidateDTO : BaseValidateDTO
{
    public ProductCategoryDTO? OriginalProductCategoryDTO { get; private set; }

    public ProductCategoryPropertyValidateDTO ValidateCreate(ProductCategoryDTO? originalProductCategoryDTO)
    {
        OriginalProductCategoryDTO = originalProductCategoryDTO;
        return this;
    }

    public ProductCategoryPropertyValidateDTO ValidateUpdate(ProductCategoryDTO? originalProductCategoryDTO)
    {
        OriginalProductCategoryDTO = originalProductCategoryDTO;
        return this;
    }

    public ProductCategoryPropertyValidateDTO ValidateDelete(ProductCategoryDTO? originalProductCategoryDTO)
    {
        OriginalProductCategoryDTO = originalProductCategoryDTO;
        return this;
    }

    public ProductCategoryPropertyValidateDTO ValidateView(ProductCategoryDTO? originalProductCategoryDTO)
    {
        OriginalProductCategoryDTO = originalProductCategoryDTO;
        return this;
    }
}