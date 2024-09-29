using System.Text.Json.Serialization;
using Template.Arguments.Enum;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Entry.Module.Registration;

public class Product : BaseEntry<Product>
{
    public string Code { get; private set; }
    public string Description { get; private set; }
    public string? BarCode { get; private set; }
    public decimal CostValue { get; private set; }
    public decimal SaleValue { get; private set; }
    public EnumStatus Status { get; private set; }
    public decimal Weight { get; private set; }
    public decimal NetWeight { get; private set; }
    public string? Observation { get; private set; }
    public long BrandId { get; private set; }
    public long? ProductCategoryId { get; private set; }

    #region Virtual Properties
    #region Internal
    public virtual Brand? Brand { get; private set; }
    public virtual ProductCategory? ProductCategory { get; private set; }
    #endregion
    #endregion
    public Product() { }

    [JsonConstructor]
    public Product(string code, string description, string? barCode, decimal costValue, decimal saleValue, EnumStatus status, decimal weight, decimal netWeight, string? observation, Brand? brand, ProductCategory? productCategory)
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
        Brand = brand;
        ProductCategory = productCategory;
    }
}