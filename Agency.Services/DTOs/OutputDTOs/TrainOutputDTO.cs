using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Services.DTOs.OutputDTOs
{
    public class TrainOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PassangerCapacity { get; set; }

        public decimal PricePerKilometer { get; set; }

        public int CartsAmount { get; set; }

        public string Img { get; set;}
    }
}
