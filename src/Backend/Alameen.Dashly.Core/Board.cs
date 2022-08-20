using Dashly.API.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Feature.TaskModule.Data.Entity
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
