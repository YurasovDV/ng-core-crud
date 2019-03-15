using System.ComponentModel.DataAnnotations;

namespace NgCoreCRUD.Entities
{
    public class GalleryItem
    {
        public int ID { get; set; }

        public byte[] Image { get; set; }

        [MaxLength(140, ErrorMessage = "Description must be 140 symbols or less")]
        public string Description { get; set; }


        public Category Category { get; set; }
        
        public int CategoryId { get; set; }
    }
}
