using Microsoft.AspNetCore.Http;
using NgCoreCRUD.Entities;

namespace NgCoreCRUD.Model.Services
{
    public class GalleryItemDto
    {
        public GalleryItemDto()
        {

        }

        public GalleryItemDto(GalleryItem entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            ID = entity.ID;
            CategoryId = entity.CategoryId;
            CategoryName = entity.Category?.Name ?? string.Empty;
            Description = entity.Description;
        }

        public int? ID { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IFormFile File { get; set; }
    }
}