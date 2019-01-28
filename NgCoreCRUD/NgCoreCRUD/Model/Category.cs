﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCoreCRUD.Model
{
    public class Category
    {
        public Category()
        {
            
        }

        public int CategoryId { get; set; }

        [MaxLength(40, ErrorMessage = "Category name must be 40 symbols or less")]
        public string Name { get; set; }

        public virtual ICollection<GalleryItem> Pictures { get; set; }
    }
}