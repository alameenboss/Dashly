using Alameen.Dashly.API.Models;
using Alameen.Dashly.Core;
using AutoMapper;

namespace Alameen.Dashly.API.Automapper
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