using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using Alameen.Dashly.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public BoardRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Boards.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Boards.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            _dbContext.Boards.RemoveRange(_dbContext.Boards);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Board>> GetAll()
        {
            return await _dbContext.Boards.ToListAsync();
        }

        public async Task<Board> GetById(int id)
        {
            return await _dbContext.Boards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save(Board model)
        {
            var entity = await _dbContext.Boards.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity != null)
            {
                _dbContext.Boards.Update(entity);
            }
            else
            {
                _dbContext.Boards.Add(model);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}