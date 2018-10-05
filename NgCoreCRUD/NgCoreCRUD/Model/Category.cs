using System.Collections.Generic;

namespace NgCoreCRUD.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GalleryItem> Pictures { get; set; }
    }
}