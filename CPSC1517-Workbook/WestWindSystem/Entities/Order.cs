using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? SalesRepId { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? PaymentDueDate { get; set; }

    public decimal? Freight { get; set; }

    public bool Shipped { get; set; }

    public string? ShipName { get; set; }

    public int? ShipAddressId { get; set; }

    public string? Comments { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Employee? SalesRep { get; set; }

    public virtual Address? ShipAddress { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
