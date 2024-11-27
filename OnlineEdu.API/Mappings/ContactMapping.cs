using AutoMapper;
using OnlineEdu.DTO.DTOs.ContactDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();
            CreateMap<ResultContactDTO, Contact>().ReverseMap();
        }
    }
}