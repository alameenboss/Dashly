using Alameen.Dashly.API.Models;
using Alameen.Dashly.Core;
using AutoMapper;

namespace Alameen.Dashly.API.Automapper
{
    public class WebappProfile : Profile
    {
        public WebappProfile()
        {
            CreateMap<CreateWebappRequest, Webapp>();

            CreateMap<UpdateWebappRequest, Webapp>();

            CreateMap<AttachmentRequest, Attachment>();

            CreateMap<TagRequest, Tag>();
        }
    }
}