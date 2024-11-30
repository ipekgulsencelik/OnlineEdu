using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IMapper _mapper, IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout()
        {
            var values = _aboutService.TGetLastAbout();
            var about = _mapper.Map<ResultAboutDTO>(values);
            return Ok(about);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımızda Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDTO createAboutDTO)
        {
            var newValue = _mapper.Map<About>(createAboutDTO);
            _aboutService.TCreate(newValue);
            return Ok("Yeni Hakkımızda Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDTO updateAboutDTO)
        {
            var value = _mapper.Map<About>(updateAboutDTO);
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _aboutService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _aboutService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }
    }
}