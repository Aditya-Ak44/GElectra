using System;
using System.Collections.Generic;

namespace GElectra.Entities;

public partial class Reading
{
    public int Id { get; set; }

    public string ElectricityReading { get; set; } = null!;

    public string GasReading { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
