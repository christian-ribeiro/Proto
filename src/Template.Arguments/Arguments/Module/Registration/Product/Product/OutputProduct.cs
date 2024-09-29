using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.Registration;

public class OutputProduct : BaseOutput<OutputProduct>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string? BarCode { get; set; }
    public decimal CostValue { get; set; }
    public decimal SaleValue { get; set; }
    public EnumStatus Status { get; set; }
    public decimal Weight { get; set; }
    public decimal NetWeight { get; set; }
    public string? Observation { get; set; }
    public long BrandId { get; set; }
    public long? ProductCategoryId { get; set; }

    #region Virtual Properties
    #region Internal
    public OutputBrand? Brand { get; set; }
    public OutputProductCategory? ProductCategory { get; set; }
    #endregion
    #endregion
    public OutputProduct() { }

    public OutputProduct(string code, string description, string? barCode, decimal costValue, decimal saleValue, EnumStatus status, decimal weight, decimal netWeight, string? observation, long brandId, long? productCategoryId, OutputBrand? brand, OutputProductCategory? productCategory)
    {
        Code = code;
        Description = description;
        BarCode = barCode;
        CostValue = costValue;
        SaleValue = saleValue;
        Status = status;
        Weight = weight;
        NetWeight = netWeight;
        Observation = observation;
        BrandId = brandId;
        ProductCategoryId = productCategoryId;
        Brand = brand;
        ProductCategory = productCategory;
    }
}