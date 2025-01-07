using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {

        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).ToList();
        }
        
        public List<Blog> GetBlogsWithCategoriesByWriterID(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToList();
        }

        public List<Blog> GetLast4BlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.IsShown).OrderByDescending(x => x.BlogID).Take(4).ToList();
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Blogs.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Blogs.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }

        public Blog GetBlogWithCategories(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).ThenInclude(x => x.TeacherSocialMedias).FirstOrDefault(x => x.BlogID == id);
        }
    }
}