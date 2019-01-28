using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgCoreCRUD.DAL;

namespace NgCoreCRUD.Model.Services
{
    public class GalleryService : IGalleryService
    {
        private GalleryDbContext _context;

        public GalleryService(GalleryDbContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<GalleryItem> GetAll()
        {
            return _context.Pictures.ToAsyncEnumerable();
        }

        public async Task<GalleryItem> GetById(int id)
        {
            return await _context.Pictures.FindAsync(id);
        }

        public async Task Create(GalleryItem value)
        {
            await _context.Pictures.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(GalleryItem value)
        {
            await Task.Delay(0);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _context.Pictures.FindAsync(id);
            if (result != null)
            {
                _context.Pictures.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
