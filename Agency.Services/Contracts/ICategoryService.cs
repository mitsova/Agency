using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryOutputDTO>> GetAllCategoriesAsync();
    }
}