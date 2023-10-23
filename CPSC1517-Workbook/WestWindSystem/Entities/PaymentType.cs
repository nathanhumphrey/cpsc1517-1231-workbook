using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class PaymentType
{
    public byte PaymentTypeId { get; set; }

    public string PaymentTypeDescription { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
