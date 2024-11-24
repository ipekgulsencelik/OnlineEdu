using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetAllCoursesWithCategories();
            var courses = _mapper.Map<List<ResultCourseDTO>>(values);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _courseService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.TDelete(id);
            return Ok("Kurs Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDTO createCourseDTO)
        {
            var newValue = _mapper.Map<Course>(createCourseDTO);
            _courseService.TCreate(newValue);
            return Ok("Yeni Kurs Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDTO updateCourseDTO)
        {
            var value = _mapper.Map<Course>(updateCourseDTO);
            _courseService.TUpdate(value);
            return Ok("Kurs Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveCourses")]
        public IActionResult GetActiveCourses()
        {
            var values = _courseService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCoursesByTeacherID/{id}")]
        public IActionResult GetCoursesByTeacherID(int id)
        {
            var values = _courseService.TGetCoursesByTeacherID(id);
            var mappedValues = _mapper.Map<List<ResultCourseDTO>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var courseCount = _courseService.TCount();
            return Ok(courseCount);
        }
    }
}