using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class Bus
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
