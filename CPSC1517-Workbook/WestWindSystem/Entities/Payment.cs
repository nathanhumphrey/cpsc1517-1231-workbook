using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public byte PaymentTypeId { get; set; }

    public int OrderId { get; set; }

    public Guid TransactionId { get; set; }

    public DateTime? ClearedDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaymentType PaymentType { get; set; } = null!;
}
