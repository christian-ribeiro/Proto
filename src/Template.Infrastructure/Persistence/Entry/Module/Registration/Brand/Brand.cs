using System.Text.Json.Serialization;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Entry.Module.Registration;

public class Brand : BaseEntry<Brand>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    #region Virtual Properties
    #region External
    public virtual List<Product> ListProduct { get; private set; }
    #endregion
    #endregion

    public Brand() { }

    [JsonConstructor]
    public Brand(string code, string description, List<Product> listProduct)
    {
        Code = code;
        Description = description;
        ListProduct = listProduct;
    }
}