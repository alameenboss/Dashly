using System.Collections.Generic;
using System.Threading.Tasks;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Data.Entity.Notes;

namespace Dashly.API.Repositories.Interface
{
    public interface INoteCategoryRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteAll();
        Task<IEnumerable<NoteCategory>> GetAll();
        Task<NoteCategory> GetById(int id);
        Task<int> Insert(NoteCategory model);
        Task<bool> Update(NoteCategory model, int id);
    }
}