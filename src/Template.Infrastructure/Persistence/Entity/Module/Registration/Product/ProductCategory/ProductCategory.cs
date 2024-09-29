﻿using System.Text.Json.Serialization;
using Template.Infrastructure.Persistence.Entity.Module.Base;

namespace Template.Infrastructure.Persistence.Entity.Module.Registration;

public class ProductCategory : BaseEntity<ProductCategory>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    #region Virtual Properties
    #region External
    public virtual List<Product>? ListProduct { get; private set; }
    #endregion
    #endregion

    public ProductCategory() { }

    [JsonConstructor]
    public ProductCategory(string code, string description, List<Product>? listProduct)
    {
        Code = code;
        Description = description;
        ListProduct = listProduct;
    }
}