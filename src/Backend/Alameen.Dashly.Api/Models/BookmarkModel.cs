using System.Collections.Generic;

namespace Dashly.API.Feature.Bookmarks
{
    public class BookmarkModel
    {
        public BookmarkModel()
        {
            Children = new List<BookmarkModel>();
        }
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int Hierarchy { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public List<BookmarkModel> Children { get; set; }
    }
}