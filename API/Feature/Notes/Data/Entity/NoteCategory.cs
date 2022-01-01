using System.Collections.Generic;

namespace Dashly.API.Feature.Notes.Data.Entity
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