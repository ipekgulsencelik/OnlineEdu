using AutoMapper;
using OnlineEdu.DTO.DTOs.AboutDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();
            CreateMap<ResultAboutDTO, About>().ReverseMap();
        }
    }
}