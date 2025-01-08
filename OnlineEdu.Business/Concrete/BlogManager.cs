using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        
        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository) : base(_repository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return _blogRepository.GetBlogsWithCategories();
        }

        public List<Blog> TGetBlogsWithCategoriesByWriterID(int id)
        {
            return _blogRepository.GetBlogsWithCategoriesByWriterID(id);
        }

        public List<Blog> TGetLast4BlogsWithCategories()
        {
            return _blogRepository.GetLast4BlogsWithCategories();
        }

        public void TDontShowOnHome(int id)
        {
            _blogRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _blogRepository.ShowOnHome(id);
        }

        public Blog TGetBlogWithCategories(int id)
        {
            return _blogRepository.GetBlogWithCategories(id);
        }

        public List<Blog> TGetBlogsByCategoryID(int id)
        {
            return _blogRepository.GetBlogsByCategoryID(id);
        }
    }
}