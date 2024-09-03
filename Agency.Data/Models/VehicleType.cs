using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class VehicleType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
