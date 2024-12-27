using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.BlogCategories.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<BlogCategory> GetCategoriesWithBlogs()
        {
            return _context.BlogCategories.Include(x => x.Blogs).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.BlogCategories.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}