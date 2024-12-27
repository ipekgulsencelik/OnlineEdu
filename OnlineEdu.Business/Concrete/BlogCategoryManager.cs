using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogCategoryManager : GenericManager<BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryManager(IRepository<BlogCategory> _repository, IBlogCategoryRepository blogCategoryRepository) : base(_repository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _blogCategoryRepository.DontShowOnHome(id);
        }

        public List<BlogCategory> TGetCategoriesWithBlogs()
        {
            return _blogCategoryRepository.GetCategoriesWithBlogs();
        }

        public void TShowOnHome(int id)
        {
            _blogCategoryRepository.ShowOnHome(id);
        }
    }
}