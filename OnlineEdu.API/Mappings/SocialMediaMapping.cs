﻿using AutoMapper;
using OnlineEdu.DTO.DTOs.SocialMediaDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<ResultSocialMediaDTO, SocialMedia>().ReverseMap();
        }
    }
}