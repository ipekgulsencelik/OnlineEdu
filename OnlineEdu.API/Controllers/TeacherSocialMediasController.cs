using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TeacherSocialMediaDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialMediasController(ITeacherSocialMediaService _teacherSocialMediaService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("byTeacherID/{id}")]
        public IActionResult GetSocialMediaByTeacherID(int id)
        {
            var values = _teacherSocialMediaService.TGetFilteredList(x => x.TeacherId == id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _teacherSocialMediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherSocialMediaService.TDelete(id);
            return Ok("Eğitmen Sosyal Medyası Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateTeacherSocialMediaDTO createTeacherSocialMediaDTO)
        {
            var newValue = _mapper.Map<TeacherSocialMedia>(createTeacherSocialMediaDTO);
            _teacherSocialMediaService.TCreate(newValue);
            return Ok("Yeni Eğitmen Sosyal Medyası Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialMediaDTO updateTeacherSocialMediaDTO)
        {
            var value = _mapper.Map<TeacherSocialMedia>(updateTeacherSocialMediaDTO);
            _teacherSocialMediaService.TUpdate(value);
            return Ok("Eğitmen Sosyal Medyası Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _teacherSocialMediaService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _teacherSocialMediaService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetLast3SocialMediasByTeacherID")]
        public IActionResult GetLast3TeacherSocialMedias(int id)
        {
            var values = _teacherSocialMediaService.TGetLast3SocialMediasByTeacherID(id);
            var accounts = _mapper.Map<List<ResultTeacherSocialMediaDTO>>(values);
            return Ok(accounts);
        }
    }
}