using System.Collections.Generic;
using System.Threading.Tasks;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Data.Entity.Notes;

namespace Dashly.API.Repositories.Interface
{
    public interface INoteRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteAll();
        Task<bool> DeleteAllByCategoryId(int noteCategoryId);
        Task<IEnumerable<Note>> GetAllByCategoryId(int noteCategoryId);
        Task<Note> GetById(int id);
        Task<int> Insert(Note entity);
        Task<bool> Update(Note model, int id);
    }
}