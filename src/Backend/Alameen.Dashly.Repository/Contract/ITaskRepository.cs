using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
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