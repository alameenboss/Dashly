using Dashly.API.Helpers;
using Dashly.API.Repositories.Data;
using Dashly.API.Repositories.Data.Entity.Notes;
using Dashly.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Repositories
{

    public class NoteCategoryRepository : INoteCategoryRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public NoteCategoryRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<IEnumerable<NoteCategory>> GetAll()
        {
            return 
                _dbContext.NoteCategories
                 .Include(e => e.Notes)
                .Include(e => e.Categories)
                .AsEnumerable()
                .Where(e => e.NoteCategoryId == null)
                .ToList() ;
        }

        public async Task<NoteCategory> GetById(int id)
        {
            return await 
                _dbContext.NoteCategories
                .Include(x => x.Categories)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Insert(NoteCategory model)
        {
            await _dbContext.NoteCategories.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task<bool> Update(NoteCategory model, int id)
        {
            model.Id = id;
            var oldNoteCategory = await _dbContext.NoteCategories.Where(p => p.Id == model.Id).SingleOrDefaultAsync();

            if (oldNoteCategory != null)
            {
                _dbContext.Entry(oldNoteCategory).CurrentValues.SetValues(model);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var note = await _dbContext.NoteCategories.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.NoteCategories.Remove(note);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var NoteCategories = _dbContext.NoteCategories;
            _dbContext.NoteCategories.RemoveRange(NoteCategories);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}