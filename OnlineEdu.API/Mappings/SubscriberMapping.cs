﻿using AutoMapper;
using OnlineEdu.DTO.DTOs.SubscriberDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDTO, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscriberDTO, Subscriber>().ReverseMap();
        }
    }
}