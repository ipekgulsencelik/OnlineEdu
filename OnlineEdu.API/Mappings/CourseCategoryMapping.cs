using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class CourseCategoryMapping : Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CreateCourseCategoryDTO, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDTO, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDTO, CourseCategory>().ReverseMap();
        }
    }
}