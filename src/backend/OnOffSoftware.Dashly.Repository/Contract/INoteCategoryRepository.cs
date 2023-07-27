using OnOffSoftware.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.Repository.Contract
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