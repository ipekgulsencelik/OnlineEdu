﻿using OnlineEdu.Business.Abstract;
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
    }
}