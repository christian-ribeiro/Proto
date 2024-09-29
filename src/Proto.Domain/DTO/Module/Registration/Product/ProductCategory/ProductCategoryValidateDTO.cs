using Proto.Arguments.Arguments.Module.Registration;

namespace Proto.Domain.DTO.Module.Registration;

public class ProductCategoryValidateDTO : ProductCategoryPropertyValidateDTO
{
    public InputCreateProductCategory? InputCreateProductCategory { get; private set; }
    public InputIdentityUpdateProductCategory? InputIdentityUpdateProductCategory { get; private set; }
    public InputIdentityDeleteProductCategory? InputIdentityDeleteProductCategory { get; private set; }
    public InputIdentityViewProductCategory? InputIdentityViewProductCategory { get; private set; }

    public ProductCategoryValidateDTO ValidateCreate(InputCreateProductCategory inputCreateProductCategory, ProductCategoryDTO? originalProductCategoryDTO)
    {
        InputCreateProductCategory = inputCreateProductCategory;
        ValidateCreate(originalProductCategoryDTO);
        return this;
    }

    public ProductCategoryValidateDTO ValidateUpdate(InputIdentityUpdateProductCategory inputIdentityUpdateProductCategory, ProductCategoryDTO? originalProductCategoryDTO)
    {
        InputIdentityUpdateProductCategory = inputIdentityUpdateProductCategory;
        ValidateUpdate(originalProductCategoryDTO);
        return this;
    }

    public ProductCategoryValidateDTO ValidateDelete(InputIdentityDeleteProductCategory inputIdentityDeleteProductCategory, ProductCategoryDTO? originalProductCategoryDTO)
    {
        InputIdentityDeleteProductCategory = inputIdentityDeleteProductCategory;
        ValidateDelete(originalProductCategoryDTO);
        return this;
    }

    public ProductCategoryValidateDTO ValidateView(InputIdentityViewProductCategory? inputIdentityViewProductCategory, ProductCategoryDTO? originalProductCategoryDTO)
    {
        InputIdentityViewProductCategory = inputIdentityViewProductCategory;
        ValidateView(originalProductCategoryDTO);
        return this;
    }
}