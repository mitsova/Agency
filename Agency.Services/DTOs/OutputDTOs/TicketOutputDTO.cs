using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Services.DTOs.OutputDTOs
{
    public class TicketOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public decimal Price { get; set; }

        public decimal AdministrativeCosts { get; set; }

        public string Img { get; set; }
    }
}
