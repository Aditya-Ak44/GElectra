using System;
using System.Collections.Generic;

namespace GElectra.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PropertyType { get; set; } = null!;

    public int BedroomCount { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
