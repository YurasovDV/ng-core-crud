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

        public IEnumerable<GalleryItem> GetAll()
        {
            return _context.Pictures.AsEnumerable();
        }

        public async Task<GalleryItem> GetById(int id)
        {
            var res = await _context.Pictures.FindAsync(id);
            return res;
        }

        public async Task<int> Create(GalleryItem value, byte[] image)
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

        public async Task Edit(GalleryItem value)
        {
            var old = await _context.Pictures.FindAsync(value.ID);
            if (old == null)
            {
                throw new Exception();
            }
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

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.AsEnumerable();
        }

        public async Task<Category> GetCategory(int id)
        {
            var res = await _context.Categories.FindAsync(id);
            if (res != null)
            {
                return res;
            }
            return null;
        }
    }
}
