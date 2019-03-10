using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NgCoreCRUD.Model;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD.Controllers
{
    [Route("api/v1/galleryitem")]
    // [ApiController] if present, file is skipped during model binding
    public class GalleryApiController : BaseController
    {
        public GalleryApiController(IGalleryService service) : base(service) { }

        [HttpGet]
        public IEnumerable<GalleryItemDto> Get()
        {
            var data = _galleryService.GetAll().Select(img => new GalleryItemDto(img));
            return data;
        }

        [HttpGet("{id}")]
        public async Task<GalleryItemDto> Get(int id)
        {
            var result = await _galleryService.GetById(id);
            var r1 = new GalleryItemDto(result);
            return r1;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GalleryItemDto imageDto)
        {
            var imageFile = imageDto.File;
            if (imageFile != null)
            {
                using (MemoryStream to = new MemoryStream())
                {
                    imageFile.CopyTo(to);
                    var entity = new GalleryItem()
                    {
                        CategoryId = imageDto.CategoryId,
                        Description = imageDto.Description,
                    };
                    await _galleryService.Create(entity, to.GetBuffer());
                    return Ok();
                }
            }
            else
            {
                return BadRequest("file is not attached");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GalleryItemDto value)
        {
            try
            {
                var entity = new GalleryItem()
                {
                    CategoryId = value.CategoryId,
                    Description = value.Description,
                    ID = value.ID.Value
                };
                await _galleryService.Edit(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write($"image id = {value.ID.Value} not found: {ex.Message}");
                return new StatusCodeResult((int)System.Net.HttpStatusCode.InternalServerError);
            }
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
            return File(data, "image/png");
        }
    }
}
