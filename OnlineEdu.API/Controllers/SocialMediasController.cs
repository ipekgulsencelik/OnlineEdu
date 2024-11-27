using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SocialMediaDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(ISocialMediaService _socialMediaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _socialMediaService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Sosyal Medya Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDTO createSocialMediaDTO)
        {
            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDTO);
            _socialMediaService.TCreate(newValue);
            return Ok("Yeni Sosyal Medya Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDTO);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya Alanı Güncellendi");
        }


        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _socialMediaService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _socialMediaService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetLast4SocialMedias")]
        public IActionResult GetLast4SocialMedias()
        {
            var values = _socialMediaService.TGetLast4SocialMedias();
            var accounts = _mapper.Map<List<ResultSocialMediaDTO>>(values);
            return Ok(accounts);
        }
    }
}