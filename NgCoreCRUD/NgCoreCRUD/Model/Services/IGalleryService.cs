using System.Collections.Generic;
using System.Threading.Tasks;

namespace NgCoreCRUD.Model.Services
{
    public interface IGalleryService
    {
        Task Create(GalleryItem value);
        Task<bool> Delete(int id);
        Task Edit(GalleryItem value);
        IAsyncEnumerable<GalleryItem> GetAll();
        Task<GalleryItem> GetById(int id);
    }
}