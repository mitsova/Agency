using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Mappers;

namespace Agency.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AgencyContext _context;

        public CategoryService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryOutputDTO>> GetAllCategoriesAsync()
        {
            var categories = _context.Categories.ToArray();

            var dtos = categories.Select(x => x.ToDTO());

            return dtos;
        }
    }
}
