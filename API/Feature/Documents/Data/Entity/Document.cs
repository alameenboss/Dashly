using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Documents.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string DocId { get; set; }
        public string Content { get; set; }
    }
}
