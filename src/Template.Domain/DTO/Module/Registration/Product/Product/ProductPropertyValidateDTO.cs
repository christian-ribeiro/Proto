using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ProductPropertyValidateDTO : BaseValidateDTO
{
    public ProductDTO? OriginalProductDTO { get; private set; }
    public BrandDTO? RelatedBrandDTO { get; private set; }
    public ProductCategoryDTO? RelatedProductCategoryDTO { get; private set; }

    public ProductPropertyValidateDTO ValidateCreate(ProductDTO? originalProductDTO, BrandDTO? relatedBrandDTO, ProductCategoryDTO? relatedProductCategoryDTO)
    {
        OriginalProductDTO = originalProductDTO;
        RelatedBrandDTO = relatedBrandDTO;
        RelatedProductCategoryDTO = relatedProductCategoryDTO;
        return this;
    }

    public ProductPropertyValidateDTO ValidateUpdate(ProductDTO? originalProductDTO, BrandDTO? relatedBrandDTO, ProductCategoryDTO? relatedProductCategoryDTO)
    {
        OriginalProductDTO = originalProductDTO;
        RelatedBrandDTO = relatedBrandDTO;
        RelatedProductCategoryDTO = relatedProductCategoryDTO;
        return this;
    }

    public ProductPropertyValidateDTO ValidateDelete(ProductDTO? originalProductDTO)
    {
        OriginalProductDTO = originalProductDTO;
        return this;
    }

    public ProductPropertyValidateDTO ValidateView(ProductDTO? originalProductDTO)
    {
        OriginalProductDTO = originalProductDTO;
        return this;
    }
}