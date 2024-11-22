using AutoMapper;
using OnlineEdu.DTO.DTOs.ImageDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class ImageMapping : Profile
    {
        public ImageMapping()
        {
            CreateMap<CreateImageDTO, Image>().ReverseMap();
            CreateMap<UpdateImageDTO, Image>().ReverseMap();
            CreateMap<ResultImageDTO, Image>().ReverseMap();
        }
    }
}