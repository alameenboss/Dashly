using Dashly.API.Feature.DataImport;
using Dashly.API.Feature.WebApps.Data.Entity;
using Dashly.API.Feature.WebApps.Data.Repository;
using Dashly.API.Feature.WebApps.DTO.Request;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.WebApps
{
    public class ImportWebapp : IDataImport
    {
        private readonly IWebappRepository _webappRepository;

        public ImportWebapp(IWebappRepository webappRepository)
        {
            _webappRepository = webappRepository;
        }

        public async Task<bool> ExecuteAsync(string data)
        {
            var result = JsonConvert.DeserializeObject<List<WebappData>>(data);

            var model = new List<Webapp>();
            result.ForEach(item =>
            {
                model.Add(new Webapp()
                {
                    Name = item.name,
                    HostedLocationUrl = item.hostedLocationUrl,
                    Attachments = PrepareAttachment(item),
                    Tags = PrepareTags(item),
                    IsActive = true
                });
            });

            return await _webappRepository.Import(model);
        }

        private static List<Tag> PrepareTags(WebappData item)
        {
            var tagList = new List<Tag>();
            item.tags?.ForEach(tag => tagList.Add(new Tag() { Name = tag, IsActive = true }));
            return tagList;
        }

        private static List<Attachment> PrepareAttachment(WebappData item)
        {
            return new List<Attachment>()
            {
                new Attachment() { Name = item.fullImageUrl, IsActive = true, Type = "FullImage", IsPrimary = true },
                new Attachment() { Name = item.thumbnailUrl, IsActive = true, Type = "Thumbnail", IsPrimary = true }
            };
        }
    }
}