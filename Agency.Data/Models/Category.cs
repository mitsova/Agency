using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Journey> Journeys { get; set; } = new List<Journey>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
