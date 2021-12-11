using Dashly.API.Helpers;
using Dashly.API.Repositories.Data;
using Dashly.API.Repositories.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.DataImport
{
    public class ImportWebapp : IDataImport
    {
        private DashlyContext _context;
        public ImportWebapp(DashlyContext context)
        {
            _context = context;
        }
        public async Task<bool> ExecuteAsync(string data)
        {
            var result = JsonConvert.DeserializeObject<List<WebappData>>(data);
            
            result.ForEach(item =>
            {
                _context.Add(new Webapp()
                {
                    Name = item.name,
                    HostedLocationUrl = item.hostedLocationUrl,
                    Attachments = PrepareAttachment(item),
                    Tags = PrepareTags(item),
                    IsActive = true
                });
            });

            _context.SaveChanges();

            return true;
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
