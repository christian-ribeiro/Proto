using System.Text.Json.Serialization;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ExternalPropertiesProductDTO : BaseExternalPropertiesDTO<ExternalPropertiesProductDTO>
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

    public ExternalPropertiesProductDTO() { }

    [JsonConstructor]
    public ExternalPropertiesProductDTO(string code, string description, string? barCode, decimal costValue, decimal saleValue, EnumStatus status, decimal weight, decimal netWeight, string? observation, long brandId, long? productCategoryId)
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
    }
}