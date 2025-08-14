using AutoMapper;
using OnlineEdu.Dto.Dtos.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
        }
    }
}
