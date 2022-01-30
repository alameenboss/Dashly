using Dashly.API.Feature.Bookmarks.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Bookmarks.Data
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