using AutoMapper;
using OnlineEdu.DTO.DTOs.RoleDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<AppRole, CreateRoleDTO>().ReverseMap();
        }
    }
}