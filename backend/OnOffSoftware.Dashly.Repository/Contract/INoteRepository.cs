using OnOffSoftware.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.Repository.Contract
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

        Task Import(IEnumerable<Note> model);
    }
}