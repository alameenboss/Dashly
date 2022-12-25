using System.Collections.Generic;

namespace Alameen.Dashly.API.Models
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
