using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputCreateProduct(string code, string description, string? barCode, decimal costValue, decimal saleValue, EnumStatus status, decimal weight, decimal netWeight, string? observation, long brandId, long? productCategoryId) : BaseInputCreate<InputCreateProduct>
{
    public string Code { get; private set; } = code;
    public string Description { get; private set; } = description;
    public string? BarCode { get; private set; } = barCode;
    public decimal CostValue { get; private set; } = costValue;
    public decimal SaleValue { get; private set; } = saleValue;
    public EnumStatus Status { get; private set; } = status;
    public decimal Weight { get; private set; } = weight;
    public decimal NetWeight { get; private set; } = netWeight;
    public string? Observation { get; private set; } = observation;
    public long BrandId { get; private set; } = brandId;
    public long? ProductCategoryId { get; private set; } = productCategoryId;
}