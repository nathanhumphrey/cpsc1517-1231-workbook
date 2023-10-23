using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? ContactTitle { get; set; }

    public string Email { get; set; } = null!;

    public int AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
