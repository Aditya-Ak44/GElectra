using System;
using System.Collections.Generic;

namespace GElectra.Entities;

public partial class Bill
{
    public int BillId { get; set; }

    public double AmountDue { get; set; }

    public DateTime DateUpdated { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
