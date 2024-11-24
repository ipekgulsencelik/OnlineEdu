using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDTOs;
using OnlineEdu.WebUI.DTOs.TeacherSocialMediaDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDTO>().ReverseMap();
            CreateMap<AppRole, CreateRoleDTO>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDTO>().ReverseMap();
            CreateMap<AppUser, ResultUserDTO>().ReverseMap();
            CreateMap<TeacherSocialMedia, ResultTeacherSocialMediaDTO>().ReverseMap();
        }
    }
}   