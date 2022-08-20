using Dashly.API.Data.Entity;
using Dashly.API.Feature.Bookmarks.Data.Entity;
using Dashly.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Bookmarks.Data
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public BookmarkRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<bool> Delete(int id)
        {
            var bookmark = await _dbContext.Bookmarks.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Bookmarks.Remove(bookmark);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            _dbContext.Bookmarks.RemoveRange(_dbContext.Bookmarks);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Bookmark>> GetAll()
        {
            return await _dbContext.Bookmarks.ToListAsync();
        }

        public async Task<Bookmark> GetById(int id)
        {
            return await _dbContext.Bookmarks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save(Bookmark model)
        {
            var bookmark = await _dbContext.Bookmarks.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (bookmark != null)
            {
                bookmark.Url = model.Url;
                bookmark.Icon = model.Icon;
                bookmark.Title = model.Title;

                _dbContext.Bookmarks.Update(bookmark);
            }
            else
            {
                _dbContext.Bookmarks.Add(model);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}