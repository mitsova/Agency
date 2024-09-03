using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agency.Data.Models;

public partial class Airplane
{
    public int Id { get; set; }

    [Required]
    public int VehicleId { get; set; }

    public bool HasFreeFood { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
