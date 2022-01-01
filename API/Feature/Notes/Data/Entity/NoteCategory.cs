using System.Collections.Generic;

namespace Dashly.API.Repositories.Data.Entity.Notes
{
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
