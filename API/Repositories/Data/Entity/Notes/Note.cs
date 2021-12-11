using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Repositories.Data.Entity.Notes
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Notes { get; set; }

        public int NoteCategoryId { get; set; }
        public virtual NoteCategory Category { get; set; }
    }

    public class NoteCategory
    {
        public NoteCategory()
        {
            Notes = new List<Note>();
            Categories = new List<NoteCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int? NoteCategoryId { get; set; }
        public virtual List<Note> Notes { get; set; }
        public virtual List<NoteCategory> Categories { get; set; }

        
    }
}
