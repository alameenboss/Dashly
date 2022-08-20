using Dashly.API.Data.Entity;
using Dashly.API.Feature.TaskModule.Data.Entity;
using Dashly.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.TaskModule.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public TaskRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            _dbContext.Tasks.RemoveRange(_dbContext.Tasks);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save(Tasks model)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity != null)
            {
                _dbContext.Tasks.Update(entity);
            }
            else
            {
                _dbContext.Tasks.Add(model);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}