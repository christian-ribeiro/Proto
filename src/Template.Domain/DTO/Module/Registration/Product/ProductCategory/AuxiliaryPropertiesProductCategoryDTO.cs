using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class AuxiliaryPropertiesProductCategoryDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesProductCategoryDTO>
{
    #region Virtual Properties
    #region External
    public List<ProductDTO> ListProduct { get; private set; }
    #endregion
    #endregion

    public AuxiliaryPropertiesProductCategoryDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesProductCategoryDTO(List<ProductDTO> listProduct)
    {
        ListProduct = listProduct;
    }
}