using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> GetBlogsWithCategories();
        List<Blog> GetBlogsWithCategoriesByWriterID(int id);
        List<Blog> GetLast4BlogsWithCategories();
        Blog GetBlogWithCategories(int id);
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        List<Blog> GetBlogsByCategoryID(int id);
    }
}