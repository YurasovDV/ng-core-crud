using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IGalleryService service) : base(service) { }

        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            var categories = _galleryService.GetCategories();
            IEnumerable<CategoryDto> categories2 = categories.Select(cat => new CategoryDto() { ID = cat.CategoryId, Description = cat.Name });
            return categories2;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
        {
            CategoryDto result = null;
            var categoryEntity = await _galleryService.GetCategory(id);
            if (categoryEntity != null)
            {
                result = new CategoryDto()
                {
                    ID = categoryEntity.CategoryId,
                    Description = categoryEntity.Name
                };
            }
            return result;
        }
    }
}