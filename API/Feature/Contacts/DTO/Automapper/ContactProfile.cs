using AutoMapper;
using Dashly.API.Feature.Contacts.Data.Entity;
using Dashly.API.Feature.Contacts.DTO.Request;

namespace Dashly.API.Feature.Contacts.DTO.Automapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactRequest, Contact>();
            CreateMap<UpdateContactRequest, Contact>();
        }
    }
}