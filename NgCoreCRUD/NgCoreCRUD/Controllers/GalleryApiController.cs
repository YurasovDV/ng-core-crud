using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NgCoreCRUD.Model;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD.Controllers
{
    [Route("api/v1/galleryitem")]
    [ApiController]
    public class GalleryApiController : BaseController
    {
        public GalleryApiController(GalleryService service) : base(service) { }

        [HttpGet]
        public IAsyncEnumerable<GalleryItem> Get()
        {
            return _galleryService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GalleryItem> Get(int id)
        {
            GalleryItem result = await _galleryService.GetById(id);
            return result;
        }

        [HttpPost]
        public async void Post([FromBody] GalleryItem value)
        {
            await _galleryService.Create(value);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] GalleryItem value)
        {
            await _galleryService.Edit(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _galleryService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
