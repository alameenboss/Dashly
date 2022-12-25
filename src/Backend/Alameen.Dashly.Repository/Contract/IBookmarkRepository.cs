using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
{
    public interface IBookmarkRepository
    {
        Task<bool> Delete(int id);

        Task<bool> DeleteAll();

        Task<IEnumerable<Bookmark>> GetAll();

        Task<Bookmark> GetById(int id);

        Task<bool> Save(Bookmark model);
    }
}