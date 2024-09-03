using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class Train
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int CartsAmount { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
