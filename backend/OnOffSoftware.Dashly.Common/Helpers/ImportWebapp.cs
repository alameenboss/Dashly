using OnOffSoftware.Dashly.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.Common.Helpers
{
    public class ImportWebapp : IDataImport<Webapp>
    {
        internal class WebappData
        {
            public string name { get; set; }

            public string hostedLocationUrl { get; set; }

            public string fullImageUrl { get; set; }

            public string thumbnailUrl { get; set; }

            public List<string> tags { get; set; }

        }

        public async Task<IEnumerable<Webapp>> ExecuteAsync(string data)
        {
            return await Task.Run(() =>
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
                return model;
            });
        }

        private List<Tag> PrepareTags(WebappData item)
        {
            var tagList = new List<Tag>();
            item.tags?.ForEach(tag => tagList.Add(new Tag() { Name = tag, IsActive = true }));
            return tagList;
        }

        private List<Attachment> PrepareAttachment(WebappData item)
        {
            return new List<Attachment>()
            {
                new Attachment() { Name = item.fullImageUrl, IsActive = true, Type = "FullImage", IsPrimary = true },
                new Attachment() { Name = item.thumbnailUrl, IsActive = true, Type = "Thumbnail", IsPrimary = true }
            };
        }
    }


}