using Template.Arguments.Arguments.Module.Registration;

namespace Template.Domain.DTO.Module.Registration;

public class ProductValidateDTO : ProductPropertyValidateDTO
{
    public InputCreateProduct? InputCreateProduct { get; private set; }
    public InputIdentityUpdateProduct? InputIdentityUpdateProduct { get; private set; }
    public InputIdentityDeleteProduct? InputIdentityDeleteProduct { get; private set; }
    public InputIdentityViewProduct? InputIdentityViewProduct { get; private set; }

    public ProductValidateDTO ValidateCreate(InputCreateProduct inputCreateProduct, ProductDTO? originalProductDTO, BrandDTO? relatedBrandDTO)
    {
        InputCreateProduct = inputCreateProduct;
        ValidateCreate(originalProductDTO, relatedBrandDTO);
        return this;
    }

    public ProductValidateDTO ValidateUpdate(InputIdentityUpdateProduct inputIdentityUpdateProduct, ProductDTO? originalProductDTO, BrandDTO? relatedBrandDTO)
    {
        InputIdentityUpdateProduct = inputIdentityUpdateProduct;
        ValidateUpdate(originalProductDTO, relatedBrandDTO);
        return this;
    }

    public ProductValidateDTO ValidateDelete(InputIdentityDeleteProduct inputIdentityDeleteProduct, ProductDTO? originalProductDTO)
    {
        InputIdentityDeleteProduct = inputIdentityDeleteProduct;
        ValidateDelete(originalProductDTO);
        return this;
    }

    public ProductValidateDTO ValidateView(InputIdentityViewProduct? inputIdentityViewProduct, ProductDTO? originalProductDTO)
    {
        InputIdentityViewProduct = inputIdentityViewProduct;
        ValidateView(originalProductDTO);
        return this;
    }
}