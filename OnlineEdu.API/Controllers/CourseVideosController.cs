using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher, Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController(IGenericService<CourseVideo> _courseVideoService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseVideoService.TGetList();
            return Ok(values);
        }

        [HttpGet("GetCourseVideosByCourseID/{id}")]
        public IActionResult GetCourseVideosByCourseID(int id)
        {
            var values = _courseVideoService.TGetFilteredList(x => x.CourseID == id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _courseVideoService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseVideoService.TDelete(id);
            return Ok("Kurs Video Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseVideoDTO createCourseVideoDTO)
        {
            var newValue = _mapper.Map<CourseVideo>(createCourseVideoDTO);
            _courseVideoService.TCreate(newValue);
            return Ok("Yeni Kurs Video Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseVideoDTO updateCourseVideoDTO)
        {
            var value = _mapper.Map<CourseVideo>(updateCourseVideoDTO);
            _courseVideoService.TUpdate(value);
            return Ok("Kurs Video Alanı Güncellendi");

        }
    }
}