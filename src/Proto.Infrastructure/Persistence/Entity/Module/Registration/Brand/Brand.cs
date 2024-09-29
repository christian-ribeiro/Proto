using System.Text.Json.Serialization;
using Proto.Infrastructure.Persistence.Entity.Module.Base;

namespace Proto.Infrastructure.Persistence.Entity.Module.Registration;

public class Brand : BaseEntity<Brand>
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