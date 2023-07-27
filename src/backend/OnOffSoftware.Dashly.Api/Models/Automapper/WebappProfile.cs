using OnOffSoftware.Dashly.API.Models;
using OnOffSoftware.Dashly.Core;
using AutoMapper;

namespace OnOffSoftware.Dashly.API.Automapper
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