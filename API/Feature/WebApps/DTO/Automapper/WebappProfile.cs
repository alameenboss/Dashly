using AutoMapper;
using Dashly.API.Feature.WebApps.Data.Entity;
using Dashly.API.Feature.WebApps.DTO.Request;

namespace Dashly.API.Feature.WebApps.DTO.Automapper
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