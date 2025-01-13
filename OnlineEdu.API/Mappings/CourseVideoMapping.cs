using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class CourseVideoMapping : Profile
    {
        public CourseVideoMapping()
        {
            CreateMap<CourseVideo, CreateCourseVideoDTO>().ReverseMap();
            CreateMap<CourseVideo, UpdateCourseVideoDTO>().ReverseMap();
            CreateMap<CourseVideo, ResultCourseVideoDTO>().ReverseMap();
        }
    }
}