using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using Alameen.Dashly.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public NoteRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<IEnumerable<Note>> GetAllByCategoryId(int noteCategoryId)
        {
            return await _dbContext.Notes
                .Where(x => x.NoteCategoryId == noteCategoryId)
                .ToListAsync();
        }

        public async Task<Note> GetById(int id)
        {
            return await _dbContext.Notes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Note model)
        {
            await _dbContext.Notes.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task<bool> Update(Note model, int id)
        {
            model.Id = id;
            var oldNote = await _dbContext.Notes.Where(p => p.Id == model.Id).SingleOrDefaultAsync();

            if (oldNote != null)
            {
                _dbContext.Entry(oldNote).CurrentValues.SetValues(model);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllByCategoryId(int noteCategoryId)
        {
            var notes = _dbContext.Notes.Where(x => x.NoteCategoryId == noteCategoryId);
            _dbContext.Notes.RemoveRange(notes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var notes = _dbContext.Notes;
            _dbContext.Notes.RemoveRange(notes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task Import(IEnumerable<Note> model)
        {
            await _dbContext.AddRangeAsync(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}