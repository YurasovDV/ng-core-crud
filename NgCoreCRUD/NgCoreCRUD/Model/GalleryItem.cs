using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model
{
    public class GalleryItem
    {
        public int ID { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }


        public int CategoryId { get; set; }
    }
}
