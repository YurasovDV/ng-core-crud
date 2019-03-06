using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    internal class GalleryServiceFake : IGalleryService
    {
        public List<CategoryDto> Cats { get; set; }
        public List<GalleryItemDto> Pics { get; set; }

        public GalleryServiceFake()
        {
            this.Cats = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Description = "cat1",
                    ID = 1
                }
            };

            this.Pics = new List<GalleryItemDto>()
            {
                new GalleryItemDto()
                {
                    CategoryId = Cats.FirstOrDefault().ID,
                    ID = 1,
                    Description = "des1111"
                },
                new GalleryItemDto()
                {
                    ID = 2,
                    CategoryId = Cats.First().ID,
                    Description = "des2222"
                }
            };
        }



        public Task<int> Create(GalleryItemDto value, byte[] image)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(GalleryItemDto value)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerable<GalleryItemDto> GetAll()
        {
            return Pics.ToAsyncEnumerable();
        }

        public Task<GalleryItemDto> GetById(int id)
        {
            return Task.FromResult(Pics.FirstOrDefault(p => p.ID == id));
        }

        public IAsyncEnumerable<CategoryDto> GetCategories()
        {
            return Cats.ToAsyncEnumerable();
        }

        public Task<CategoryDto> GetCategory(int id)
        {
            return Task.FromResult(Cats.FirstOrDefault(c => c.ID == id));
        }

        public Task<byte[]> GetImage(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}