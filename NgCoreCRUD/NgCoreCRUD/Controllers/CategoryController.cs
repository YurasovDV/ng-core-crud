using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IAsyncEnumerable<CategoryDto> Get()
        {
            return _galleryService.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
        {
            var result = await _galleryService.GetCategory(id);
            return result;
        }

       

    }
}