using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    internal class GalleryServiceFake : IGalleryService
    {
        private byte[] value;

        public Dictionary<int, CategoryDto> Categories { get; set; }
        public List<GalleryItemDto> Pictures { get; set; }
        public Dictionary<int, byte[]> PicturesData { get; private set; }

        public GalleryServiceFake()
        {
            Categories = new Dictionary<int, CategoryDto>()
            {
                {
                    1,
                    new CategoryDto()
                    {
                        Description = "Landscapes",
                        ID = 1
                    }
                },
                {
                    2,
                    new CategoryDto()
                    {
                        Description = "Cars",
                        ID = 2
                    }
                },
                {
                    3,
                    new CategoryDto()
                    {
                        Description = "Space",
                        ID = 3
                    }
                },
            };

            Pictures = new List<GalleryItemDto>();

            PicturesData = new Dictionary<int, byte[]>();
        }


        public Task<int> Create(GalleryItemDto value, byte[] image)
        {
            value.ID = Pictures.Count + 1;
            Pictures.Add(value);
            PicturesData.Add(value.ID, image);
            return Task.FromResult(value.ID);
        }

        public Task<bool> Delete(int id)
        {
            int removed = Pictures.RemoveAll(p => p.ID == id);
            if (removed != 0)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public IAsyncEnumerable<GalleryItemDto> GetAll()
        {
            foreach (var pic in Pictures)
            {
                pic.CategoryName = Categories[pic.CategoryId].Description;
            }

            return Pictures.ToAsyncEnumerable();
        }


        public Task<GalleryItemDto> GetById(int id)
        {
            var res = Pictures.FirstOrDefault(p => p.ID == id);
            if (res != null)
            {
                res.CategoryName = Categories[res.CategoryId].Description;
            }
            return Task.FromResult(res);
        }

        public Task<byte[]> GetImage(int id)
        {
            byte[] value;
            PicturesData.TryGetValue(id, out value);
            if (value != null)
            {
                return Task.FromResult(value);
            }
            throw new Exception("image not found");
        }

        public Task Edit(GalleryItemDto value)
        {
            var updated = value ?? throw new ArgumentNullException(nameof(value));
            var old = Pictures.FirstOrDefault(p => p.ID == value.ID);
            if (old == null)
            {
                throw new Exception($"image not found: id = {value.ID}");
            }

            Pictures.Remove(old);
            Pictures.Add(value);

            return Task.CompletedTask;
        }

        #region categories


        public IAsyncEnumerable<CategoryDto> GetCategories()
        {
            return Categories.Values.ToAsyncEnumerable();
        }

        public Task<CategoryDto> GetCategory(int id)
        {
            return Task.FromResult(Categories[id]);
        }


        #endregion
    }
}