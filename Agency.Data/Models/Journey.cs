using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class Journey
{
    public int Id { get; set; }

    public string StartLocation { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public double Distance { get; set; }

    public decimal TravelCosts { get; set; }

    public int VehicleId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Vehicle Vehicle { get; set; } = null!;
}
