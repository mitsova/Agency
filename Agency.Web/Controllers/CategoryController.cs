using Agency.Data.Models;
using Agency.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _catService;

        public CategoryController(ICategoryService service)
        {
            _catService = service;
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var cats = await _catService.GetAllCategoriesAsync();

                if (cats != null && cats.Count() > 0)
                {
                    return Ok(cats);
                }

                return Ok("No Categories Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
