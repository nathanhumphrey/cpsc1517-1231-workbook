using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class ManifestItem
{
    public int ManifestItemId { get; set; }

    public int ShipmentId { get; set; }

    public int ProductId { get; set; }

    public short ShipQuantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Shipment Shipment { get; set; } = null!;
}
