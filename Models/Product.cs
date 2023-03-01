using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public string? ProductPhoto { get; set; }

    public int ProductManufacturerId { get; set; }

    public int ProductSupplierId { get; set; }

    public decimal ProductCost { get; set; }

    public sbyte? ProductDiscountAmount { get; set; }

    public sbyte? ProductDiscountMax { get; set; }

    public int ProductQuantityInStock { get; set; }

    public int ProductUnitId { get; set; }

    public virtual ICollection<Orderproduct> Orderproducts { get; } = new List<Orderproduct>();

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Manufacturer ProductManufacturer { get; set; } = null!;

    public virtual Supplier ProductSupplier { get; set; } = null!;

    public virtual Unit ProductUnit { get; set; } = null!;
}
