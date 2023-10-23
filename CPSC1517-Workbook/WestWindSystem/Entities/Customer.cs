using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? ContactTitle { get; set; }

    public string ContactEmail { get; set; } = null!;

    public int AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
