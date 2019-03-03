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

        public IAsyncEnumerable<GalleryItemDto> GetAll()
        {
            return _context.Pictures.ToAsyncEnumerable().Select(i => new GalleryItemDto(i));
        }

        public async Task<GalleryItemDto> GetById(int id)
        {
            var res = await _context.Pictures.FindAsync(id);
            return res == null ? null : new GalleryItemDto(res);
        }

        public async Task<int> Create(GalleryItemDto value, byte[] image)
        {
            var picture = new GalleryItem()
            {
                CategoryId = value.CategoryId,
                Description = value.Description,
                Image = image
            };
            await _context.Pictures.AddAsync(picture);
            await _context.SaveChangesAsync();
            return picture.ID;
        }

        public async Task Edit(GalleryItemDto value)
        {
            var old = await _context.Pictures.FindAsync(value.ID);
            old.CategoryId = value.CategoryId;
            old.Description = value.Description;
            _context.Pictures.Update(old);
            await _context.SaveChangesAsync();
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

        public async Task<byte[]> GetImage(int id)
        {
            var pict = await _context.Pictures.FindAsync(id);
            if (pict != null)
            {
                return pict.Image;
            }
            return null;
        }
    }
}
