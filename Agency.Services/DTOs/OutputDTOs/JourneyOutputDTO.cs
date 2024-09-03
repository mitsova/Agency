using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Services.DTOs.OutputDTOs
{
    public class JourneyOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StartLocation { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public decimal TravelCosts { get; set; }

        public string Img { get; set; }
    }
}
