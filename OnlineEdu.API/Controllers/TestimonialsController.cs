﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TestimonialDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDTO createTestimonialDTO)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDTO);
            _testimonialService.TCreate(newValue);
            return Ok("Yeni Referans Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDTO);
            _testimonialService.TUpdate(value);
            return Ok("Referans Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _testimonialService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _testimonialService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [AllowAnonymous]
        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var courseCount = _testimonialService.TCount();
            return Ok(courseCount);
        }
    }
}