using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper, IBlogService _blogService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDTO>>(values);
            return Ok(blogs);
        }

        [AllowAnonymous]
        [HttpGet("GetLast4Blogs")]
        public IActionResult GetLast4Blogs()
        {
            var values = _blogService.TGetLast4BlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDTO>>(values);
            return Ok(blogs);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _blogService.TGetBlogWithCategories(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogDTO createBlogDTO)
        {
            var newValue = _mapper.Map<Blog>(createBlogDTO);
            _blogService.TCreate(newValue);
            return Ok("Yeni Blog Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDTO updateBlogDTO)
        {
            var value = _mapper.Map<Blog>(updateBlogDTO);
            _blogService.TUpdate(value);
            return Ok("Blog Alanı Güncellendi");
        }

        [HttpGet("GetBlogByWriterID/{id}")]
        public IActionResult GetBlogByWriterID(int id)
        {
            var values = _blogService.TGetBlogsWithCategoriesByWriterID(id);
            var mappedValues = _mapper.Map<List<ResultBlogDTO>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _blogService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _blogService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveBlogs")]
        public IActionResult GetActiveBlogs()
        {
            var values = _blogService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var blogCount = _blogService.TCount();
            return Ok(blogCount);
        }

        [AllowAnonymous]
        [HttpGet("GetBlogsByCategoryID/{id}")]
        public IActionResult GetBlogsByCategoryID(int id)
        {
            var blogs = _blogService.TGetBlogsByCategoryID(id);
            return Ok(blogs);
        }
    }
}