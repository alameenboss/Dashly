namespace Dashly.API.Feature.Notes.Data.Entity
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Notes { get; set; }

        public int NoteCategoryId { get; set; }
        public virtual NoteCategory Category { get; set; }
    }
}