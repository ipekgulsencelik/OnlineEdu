using AutoMapper;
using OnlineEdu.DTO.DTOs.RoleDTOs;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppRole, CreateRoleDTO>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDTO>().ReverseMap();
            CreateMap<AppUser, ResultUserDTO>().ReverseMap();
        }
    }
}