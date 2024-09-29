using System.Text.Json.Serialization;
using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.DTO.Module.Registration;

public class AuxiliaryPropertiesProductDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesProductDTO>
{
    #region Virtual Properties
    #region Internal
    public BrandDTO? Brand { get; private set; }
    public ProductCategoryDTO? ProductCategory { get; private set; }
    #endregion
    #endregion
    public AuxiliaryPropertiesProductDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesProductDTO(BrandDTO? brand, ProductCategoryDTO? productCategory)
    {
        Brand = brand;
        ProductCategory = productCategory;
    }
}