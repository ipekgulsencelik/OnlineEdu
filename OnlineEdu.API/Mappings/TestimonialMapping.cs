﻿using AutoMapper;
using OnlineEdu.DTO.DTOs.TestimonialDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO, Testimonial>().ReverseMap();
        }
    }
}