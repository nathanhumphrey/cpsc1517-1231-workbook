using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public string Address1 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string Country { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Supplier? Supplier { get; set; }
}
