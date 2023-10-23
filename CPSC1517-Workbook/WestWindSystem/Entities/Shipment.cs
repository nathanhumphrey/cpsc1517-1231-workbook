using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public int OrderId { get; set; }

    public DateTime ShippedDate { get; set; }

    public int ShipVia { get; set; }

    public decimal FreightCharge { get; set; }

    public string? TrackingCode { get; set; }

    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    public virtual Order Order { get; set; } = null!;

    public virtual Shipper ShipViaNavigation { get; set; } = null!;
}
