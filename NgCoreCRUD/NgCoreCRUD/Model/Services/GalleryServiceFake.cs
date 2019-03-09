using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    internal class GalleryServiceFake : IGalleryService
    {
        public Dictionary<int, Category> Categories { get; set; }
        public List<GalleryItem> Pictures { get; set; }

        public GalleryServiceFake()
        {
            Categories = new Dictionary<int, Category>()
            {
                {
                    1,
                    new Category()
                    {
                        Name = "Landscapes",
                        CategoryId = 1,
                        Pictures = new List<GalleryItem>()
                    }
                },
                {
                    2,
                    new Category()
                    {
                        Name = "Cars",
                        CategoryId = 2,
                        Pictures = new List<GalleryItem>()
                    }
                },
                {
                    3,
                    new Category()
                    {
                        Name = "Space",
                        CategoryId = 3,
                        Pictures = new List<GalleryItem>()
                    }
                },
            };

            Pictures = new List<GalleryItem>();
        }


        public Task<int> Create(GalleryItem picture, byte[] image)
        {
            picture.ID = Pictures.Count + 1;
            var category = Categories[picture.CategoryId];

            var added = new GalleryItem()
            {
                CategoryId = picture.CategoryId,
                Category = category,
                Description = picture.Description,
                Image = image,
                ID = picture.ID
            };

            category.Pictures.Add(added);

            Pictures.Add(added);
            return Task.FromResult(added.ID);
        }

        public Task<bool> Delete(int id)
        {
            var toDelete = Pictures.FirstOrDefault(p => p.ID == id);
            if (toDelete != null)
            {
                toDelete.Category.Pictures.Remove(toDelete);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public IAsyncEnumerable<GalleryItem> GetAll()
        {
            return Pictures.ToAsyncEnumerable();
        }

        public Task<GalleryItem> GetById(int id)
        {
            var res = Pictures.FirstOrDefault(p => p.ID == id);
            return Task.FromResult(res);
        }

        public Task<byte[]> GetImage(int id)
        {
            byte[] value;
            value = Pictures.FirstOrDefault(p => p.ID == id)?.Image;
            if (value != null)
            {
                return Task.FromResult(value);
            }
            throw new Exception("image not found");
        }

        public Task Edit(GalleryItem value)
        {
            var updated = value ?? throw new ArgumentNullException(nameof(value));
            var toUpdate = Pictures.FirstOrDefault(p => p.ID == value.ID);
            if (toUpdate == null)
            {
                throw new Exception($"image not found: id = {value.ID}");
            }

            toUpdate.Description = value.Description;

            if (toUpdate.CategoryId != value.CategoryId)
            {
                var oldCategoryId = toUpdate.CategoryId;
                toUpdate.Category.Pictures.Remove(toUpdate);
                toUpdate.CategoryId = value.CategoryId;
                toUpdate.Category = Categories[value.CategoryId];
                toUpdate.Category.Pictures.Add(toUpdate);
            }

            return Task.CompletedTask;
        }

        #region categories


        public IAsyncEnumerable<Category> GetCategories()
        {
            return Categories.Values.ToAsyncEnumerable();
        }

        public Task<Category> GetCategory(int id)
        {
            return Task.FromResult(Categories[id]);
        }


        #endregion
    }
}