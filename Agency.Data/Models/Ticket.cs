using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Data.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int JourneyId { get; set; }

    public decimal AdministrativeCosts { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Journey Journey { get; set; } = null!;

}
