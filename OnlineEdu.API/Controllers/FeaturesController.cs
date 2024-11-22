﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.FeatureDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService _featureService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _featureService.TGetList();
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
            return Ok("Yeni Kurs Kategori Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            _featureService.TUpdate(value);
            return Ok("Kurs Kategori Alanı Güncellendi");
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
            var values = _featureService.TGetFilteredList(x => x.IsHome == true);
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