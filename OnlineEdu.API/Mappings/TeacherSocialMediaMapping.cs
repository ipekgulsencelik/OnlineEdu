using AutoMapper;
using OnlineEdu.DTO.DTOs.TeacherSocialMediaDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class TeacherSocialMediaMapping : Profile
    {
        public TeacherSocialMediaMapping()
        {
            CreateMap<TeacherSocialMedia, ResultTeacherSocialMediaDTO>().ReverseMap();
            CreateMap<TeacherSocialMedia, CreateTeacherSocialMediaDTO>().ReverseMap();
            CreateMap<TeacherSocialMedia, UpdateTeacherSocialMediaDTO>().ReverseMap();
        }
    }
}