using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
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