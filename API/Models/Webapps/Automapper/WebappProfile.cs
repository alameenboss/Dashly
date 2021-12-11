using AutoMapper;
using Dashly.API.Models.Webapps.Request;
using Dashly.API.Repositories.Data.Entity;

namespace Dashly.API.Models.Webapps.Automapper
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