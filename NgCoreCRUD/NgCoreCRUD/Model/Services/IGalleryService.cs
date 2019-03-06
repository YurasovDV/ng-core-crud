using System.Collections.Generic;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    public interface IGalleryService
    {
        Task<int> Create(GalleryItemDto value, byte[] image);
        Task<bool> Delete(int id);
        Task Edit(GalleryItemDto value);
        IAsyncEnumerable<GalleryItemDto> GetAll();
        Task<GalleryItemDto> GetById(int id);

        IAsyncEnumerable<CategoryDto> GetCategories();
        Task<CategoryDto> GetCategory(int id);

        Task<byte[]> GetImage(int id);
    }
}