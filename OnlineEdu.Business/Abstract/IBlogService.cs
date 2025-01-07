using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetLast4BlogsWithCategories();
        List<Blog> TGetBlogsWithCategoriesByWriterID(int id);
        Blog TGetBlogWithCategories(int id);
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}