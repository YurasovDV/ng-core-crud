namespace NgCoreCRUD.Model.Services
{
    public class GalleryItemDto
    {
        public GalleryItemDto(GalleryItem entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            ID = entity.ID;
            CategoryId = entity.CategoryId;
            Description = entity.Description;
        }

        public int CategoryId { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    }
}