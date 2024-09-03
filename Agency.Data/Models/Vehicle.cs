using System;
using System.Collections.Generic;

namespace Agency.Data.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public int PassangerCapacity { get; set; }

    public decimal PricePerKilometer { get; set; }

    public int TypeId { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Airplane> Airplanes { get; set; } = new List<Airplane>();

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Journey> Journeys { get; set; } = new List<Journey>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();

    public virtual VehicleType Type { get; set; } = null!;
}
