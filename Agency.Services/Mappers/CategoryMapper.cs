using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Services.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryOutputDTO ToDTO(this Data.Models.Category category)
        {
            var cat = new CategoryOutputDTO
            {
                Name = category.Name,
                Img = "https://w7.pngwing.com/pngs/266/704/png-transparent-computer-icons-task-other-categories-miscellaneous-angle-text.png"
            };

            return cat;
        }
    }
}
