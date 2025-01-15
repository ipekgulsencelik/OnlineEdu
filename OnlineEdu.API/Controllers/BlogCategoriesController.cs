using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IBlogCategoryService _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogCategoryService.TGetCategoriesWithBlogs();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _blogCategoryService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogCategoryService.TDelete(id);
            return Ok("Blog Kategori Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            var newValue = _mapper.Map<BlogCategory>(createBlogCategoryDTO);
            _blogCategoryService.TCreate(newValue);
            return Ok("Yeni Blog Kategori Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            var value = _mapper.Map<BlogCategory>(updateBlogCategoryDTO);
            _blogCategoryService.TUpdate(value);
            return Ok("Blog Kategori Alanı Güncellendi");
        }


        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _blogCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _blogCategoryService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _blogCategoryService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }
    }
}