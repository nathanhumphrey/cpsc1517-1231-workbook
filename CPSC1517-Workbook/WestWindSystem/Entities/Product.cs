using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int SupplierId { get; set; }

    public int CategoryId { get; set; }

    public string QuantityPerUnit { get; set; } = null!;

    public short? MinimumOrderQuantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
