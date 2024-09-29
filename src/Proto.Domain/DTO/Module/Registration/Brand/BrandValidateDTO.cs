using Proto.Arguments.Arguments.Module.Registration;

namespace Proto.Domain.DTO.Module.Registration;

public class BrandValidateDTO : BrandPropertyValidateDTO
{
    public InputCreateBrand? InputCreateBrand { get; private set; }
    public InputIdentityUpdateBrand? InputIdentityUpdateBrand { get; private set; }
    public InputIdentityDeleteBrand? InputIdentityDeleteBrand { get; private set; }
    public InputIdentityViewBrand? InputIdentityViewBrand { get; private set; }

    public BrandValidateDTO ValidateCreate(InputCreateBrand inputCreateBrand, BrandDTO? originalBrandDTO)
    {
        InputCreateBrand = inputCreateBrand;
        ValidateCreate(originalBrandDTO);
        return this;
    }

    public BrandValidateDTO ValidateUpdate(InputIdentityUpdateBrand inputIdentityUpdateBrand, BrandDTO? originalBrandDTO)
    {
        InputIdentityUpdateBrand = inputIdentityUpdateBrand;
        ValidateUpdate(originalBrandDTO);
        return this;
    }

    public BrandValidateDTO ValidateDelete(InputIdentityDeleteBrand inputIdentityDeleteBrand, BrandDTO? originalBrandDTO)
    {
        InputIdentityDeleteBrand = inputIdentityDeleteBrand;
        ValidateDelete(originalBrandDTO);
        return this;
    }

    public BrandValidateDTO ValidateView(InputIdentityViewBrand? inputIdentityViewBrand, BrandDTO? originalBrandDTO)
    {
        InputIdentityViewBrand = inputIdentityViewBrand;
        ValidateView(originalBrandDTO);
        return this;
    }
}