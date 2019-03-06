using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD.Controllers
{
    [Route("api/v1/galleryitem")]
    [ApiController]
    public class GalleryApiController : BaseController
    {
        public GalleryApiController(IGalleryService service) : base(service) { }

        [HttpGet]
        public IAsyncEnumerable<GalleryItemDto> Get()
        {
            return _galleryService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GalleryItemDto> Get(int id)
        {
            var result = await _galleryService.GetById(id);
            return result;
        }

        [HttpPost]
        public async void Post([FromBody] GalleryItemDto value)
        {
            var provider = new MultipartMemoryStreamProvider();
            IFormFile imageFile = Request.Form.Files.FirstOrDefault();
            using (MemoryStream to = new MemoryStream())
            {
                imageFile.CopyTo(to);
                await _galleryService.Create(value, to.GetBuffer());
            }
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] GalleryItemDto value)
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

        [HttpGet("GetImage/{id}")]
        public async Task<ActionResult> GetImage(int id)
        {
            var data = await _galleryService.GetImage(id);
            if (data == null)
            {
                return NotFound();
            }
            return File(data, "image");
        }
    }
}
