using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.ImageDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IImageService _imageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _imageService.TGetList();
            var courseCategories = _mapper.Map<List<ResultImageDTO>>(values);
            return Ok(courseCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _imageService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _imageService.TDelete(id);
            return Ok("Kurs Kategori Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateImageDTO createImageDTO)
        {
            var newValue = _mapper.Map<Image>(createImageDTO);
            _imageService.TCreate(newValue);
            return Ok("Yeni Kurs Kategori Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateImageDTO updateImageDTO)
        {
            var value = _mapper.Map<Image>(updateImageDTO);
            _imageService.TUpdate(value);
            return Ok("Kurs Kategori Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _imageService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _imageService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveImages")]
        public IActionResult GetActiveImages()
        {
            var values = _imageService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetImageCount")]
        public IActionResult GetImageCount()
        {
            var courseCount = _imageService.TCount();
            return Ok(courseCount);
        }
    }
}