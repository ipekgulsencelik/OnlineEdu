using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.FeatureDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService _featureService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _featureService.TGetList();
            var features = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(features);
        }

        [AllowAnonymous]
        [HttpGet("GetLast4Features")]
        public IActionResult GetLast4Features()
        {
            var values = _featureService.TGetLast4Features();
            var features = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(features);
        }

        [HttpGet("GetAllFeatures")]
        public IActionResult GetAllFeatures()
        {
            var values = _featureService.TGetAllFeatures();
            var features = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(features);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _featureService.TDelete(id);
            return Ok("Ozellik Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDTO createFeatureDTO)
        {
            var newValue = _mapper.Map<Feature>(createFeatureDTO);
            _featureService.TCreate(newValue);
            return Ok("Yeni Ozellik Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            _featureService.TUpdate(value);
            return Ok("Ozellik Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _featureService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _featureService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveFeatures")]
        public IActionResult GetActiveFeatures()
        {
            var values = _featureService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetFeatureCount")]
        public IActionResult GetFeatureCount()
        {
            var featureCount = _featureService.TCount();
            return Ok(featureCount);
        }
    }
}