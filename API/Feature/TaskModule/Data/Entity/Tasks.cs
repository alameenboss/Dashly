using Dashly.API.Data.Entity;
using Dashly.API.Feature.WebApps.Data.Entity;
using System.Collections.Generic;

namespace Dashly.API.Feature.TaskModule.Data.Entity
{
    public class Tasks : BaseEntity
    {
        public string BoardId { get; set; }

        public string ParentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string DueDate { get; set; }

        public string StatusId { get; set; }

        public string AssignedTo { get; set; }

        public string PriorityId { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Attachment> Attachments { get; set; }


    }
}
