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

    #region Virtual Properties
    #region Internal
    public OutputBrand? Brand { get; set; }
    #endregion
    #endregion
    public OutputProduct() { }

    public OutputProduct(string code, string description, string? barCode, decimal costValue, decimal saleValue, EnumStatus status, decimal weight, decimal netWeight, string? observation, OutputBrand? brand)
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
    }
}