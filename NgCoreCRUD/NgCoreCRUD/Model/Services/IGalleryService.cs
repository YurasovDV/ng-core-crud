using System.Collections.Generic;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    public interface IGalleryService
    {
        Task<int> Create(GalleryItem value, byte[] image);
        Task<bool> Delete(int id);
        Task Edit(GalleryItem value);
        IAsyncEnumerable<GalleryItem> GetAll();
        Task<GalleryItem> GetById(int id);

        Task<byte[]> GetImage(int id);

        IAsyncEnumerable<Category> GetCategories();
        Task<Category> GetCategory(int id);
    }
}