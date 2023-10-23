using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class InvoiceItem
{
    public string? ShipName { get; set; }

    public string ShipAddress { get; set; } = null!;

    public string ShipCity { get; set; } = null!;

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string ShipCountry { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string Country { get; set; } = null!;

    public string? SalesRep { get; set; }

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public string QuantityPerUnit { get; set; } = null!;

    public float Discount { get; set; }

    public decimal? ExtendedPrice { get; set; }

    public decimal? Freight { get; set; }
}
