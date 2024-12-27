using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogCategoryService : IGenericService<BlogCategory>
    {
        List<BlogCategory> TGetCategoriesWithBlogs();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}