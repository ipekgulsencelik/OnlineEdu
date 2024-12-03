using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseRegisterDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister, ResultCourseRegisterDTO>().ReverseMap();
            CreateMap<CourseRegister, CreateCourseRegisterDTO>().ReverseMap();
            CreateMap<CourseRegister, UpdateCourseRegisterDTO>().ReverseMap();
        }
    }
}