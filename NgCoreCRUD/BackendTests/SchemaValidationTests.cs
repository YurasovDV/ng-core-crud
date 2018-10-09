using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NgCoreCRUD.DAL;
using NgCoreCRUD.Model;

namespace BackendTests
{
    [TestClass]
    public class SchemaValidationTests
    {
        [TestMethod]
        public void TryInsertARecord()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            builder.UseSqlServer("Server=ASUS;Database=GalleryDB; User ID = sa; Password=12345; Trusted_Connection=True;");

            GalleryDbContext ctx = new GalleryDbContext(builder.Options);

            var pictures = ctx.Pictures.ToList();

            ctx.Pictures.RemoveRange(pictures);

            ctx.SaveChanges();

            var categories = ctx.Categories.ToList();

            ctx.Categories.RemoveRange(categories);

            ctx.SaveChanges();

            ctx.Categories.Add(new Category()
            {
                Name = "Landscapes",
            });

            ctx.SaveChanges();

            var singleCat = ctx.Categories.Single();

            StringAssert.Contains(singleCat.Name, "Landscapes", "cat name");
            Assert.IsTrue(singleCat.CategoryId > 0, "id for the first category should be set");

            ctx.Pictures.Add(
                new GalleryItem()
                {
                    Category = singleCat,
                    Description = "blank picture",
                });

            ctx.SaveChanges();

            var singlePicture = ctx.Pictures.Single();

            StringAssert.Contains(singlePicture.Description, "blank picture", "picture description");

            Assert.IsTrue(singlePicture.CategoryId > 0, "category id should be set");
            Assert.IsTrue(singlePicture.ID > 0, "picture id should be set");

        }
    }
}
