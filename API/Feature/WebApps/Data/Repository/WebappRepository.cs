using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashly.API.Helpers;
using Dashly.API.Repositories.Data;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Interface;

namespace Dashly.API.Repositories
{
    public class WebappRepository : IWebappRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public WebappRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<IEnumerable<Webapp>> GetAll()
        {
            return await _dbContext
                .Webapps
                .Where(x => x.IsActive == true)
                .Include(x => x.Attachments)
                .Include(x => x.Tags)
                .ToListAsync();
        }

        public async Task<Webapp> GetById(int id)
        {
            return await _dbContext
                .Webapps
                .Where(x => x.Id == id)
                .Include(x => x.Attachments)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Webapp entity)
        {
            SetInsertDefaults<Webapp>(entity);

            entity.Attachments.ForEach(a => SetInsertDefaults<Attachment>(a));
            entity.Tags.ForEach(t => SetInsertDefaults<Tag>(t));

            await _dbContext.Webapps.AddAsync(entity);

            await _dbContext.Attachments.AddRangeAsync(entity.Attachments);

            await _dbContext.Tags.AddRangeAsync(entity.Tags);

            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Update(Webapp model, int id)
        {

            var oldWebapp = _dbContext.Webapps
                    .Where(p => p.Id == model.Id)
                    .Include(x => x.Attachments)
                    .Include(x => x.Tags)
                    .SingleOrDefault();

            if (oldWebapp != null)
            {
                SetUpdateDefaults<Webapp>(model, model.Id);
                // Update parent
                _dbContext.Entry(oldWebapp).CurrentValues.SetValues(model);

                // Update Children
                UpdateAttachments(model, oldWebapp);
                UpdateTags(model, oldWebapp);

                _dbContext.SaveChanges();
            }

            return true;
        }

        private void UpdateAttachments(Webapp newWebapp, Webapp oldWebapp)
        {
            // Delete children
            foreach (var attachment in oldWebapp.Attachments)
            {
                if (!newWebapp.Attachments.Any(c => c.Id == attachment.Id))
                    _dbContext.Attachments.Remove(attachment);
            }

            // Update and Insert children
            foreach (var attachment in newWebapp.Attachments)
            {
                var existingChild = oldWebapp.Attachments
                    .Where(c => c.Id == attachment.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {
                    // Update child
                    SetUpdateDefaults<Attachment>(attachment, attachment.Id);
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(attachment);
                }
                else
                {
                    SetInsertDefaults<Attachment>(attachment);
                    oldWebapp.Attachments.Add(attachment);
                }
            }
        }
        private void UpdateTags(Webapp newWebapp, Webapp oldWebapp)
        {
            // Delete children
            foreach (var tag in oldWebapp.Tags)
            {
                if (!newWebapp.Tags.Any(c => c.Id == tag.Id))
                    _dbContext.Tags.Remove(tag);
            }

            // Update and Insert children
            foreach (var tag in newWebapp.Tags)
            {
                var existingChild = oldWebapp.Tags
                    .Where(c => c.Id == tag.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {
                    // Update child
                    SetUpdateDefaults<Tag>(tag, tag.Id);
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(tag);
                }
                else
                {
                    SetInsertDefaults<Tag>(tag);
                    oldWebapp.Tags.Add(tag);
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            var webapp = await _dbContext.Webapps.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Webapps.Remove(webapp);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var webapps = _dbContext.Webapps;
            _dbContext.Webapps.RemoveRange(webapps);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private void SetInsertDefaults<T>(T entity) where T : BaseEntity
        {
            entity.IsActive = true;
            entity.CreatedAt = System.DateTime.UtcNow;
            entity.CreatedBy = _contextResolver.GetCurrentUser();
            entity.UpdatedAt = System.DateTime.UtcNow;
            entity.UpdatedBy = _contextResolver.GetCurrentUser();
        }

        private void SetUpdateDefaults<T>(T entity, int id) where T : BaseEntity
        {
            entity.Id = id;
            entity.IsActive = true;
            entity.UpdatedAt = System.DateTime.UtcNow;
            entity.UpdatedBy = _contextResolver.GetCurrentUser();
        }

        public async Task<bool> AddAttachment(int webAppId, Attachment attachment)
        {
            var primaryAttachments = _dbContext.Attachments.Where(x => x.IsPrimary == true && x.WebAppId == webAppId).ToList();
            primaryAttachments.ForEach(x =>
            {
                x.IsPrimary = false;
            });
            _dbContext.Attachments.UpdateRange(primaryAttachments);

            SetInsertDefaults<Attachment>(attachment);
            attachment.WebAppId = webAppId;
            attachment.IsPrimary = true;
            _dbContext.Attachments.Add(attachment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}