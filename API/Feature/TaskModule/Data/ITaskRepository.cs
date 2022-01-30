using Dashly.API.Feature.TaskModule.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.TaskModule.Data
{
    public interface ITaskRepository
    {
        Task<bool> Delete(int id);

        Task<bool> DeleteAll();

        Task<IEnumerable<Tasks>> GetAll();

        Task<Tasks> GetById(int id);

        Task<bool> Save(Tasks model);
    }
}