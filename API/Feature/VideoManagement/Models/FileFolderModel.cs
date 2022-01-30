using System.Collections.Generic;

namespace Dashly.API.Feature.VideoManagement.Models
{
    public class FileFolderModel
    {
        public FileFolderModel()
        {
            Folders = new List<string>();
            Files = new List<string>();
        }

        public IEnumerable<string> Folders { get; set; }
        public IEnumerable<string> Files { get; set; }

    }
}
