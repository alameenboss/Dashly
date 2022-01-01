using AutoMapper;
using Dashly.API.Feature.Contacts.Models;
using Dashly.API.Models.Contacts.Request;

namespace Dashly.API.Models.Contacts.Automapper
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