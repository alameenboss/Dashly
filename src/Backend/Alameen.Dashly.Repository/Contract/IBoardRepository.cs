using Dashly.API.Feature.TaskModule.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.TaskModule.Data
{
    public interface IBoardRepository
    {
        Task<bool> Delete(int id);

        Task<bool> DeleteAll();

        Task<IEnumerable<Board>> GetAll();

        Task<Board> GetById(int id);

        Task<bool> Save(Board model);
    }
}