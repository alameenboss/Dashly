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
    public class ContactRepository : IContactRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public ContactRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _dbContext
                .Contacts
                .ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _dbContext
                .Contacts
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Contact entity)
        {
            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Update(Contact model, int id)
        {
            var oldContact = _dbContext.Contacts
                    .Where(p => p.Id == model.Id)
                    .SingleOrDefault();

            if (oldContact != null)
            {
                _dbContext.Entry(oldContact).CurrentValues.SetValues(model);
                _dbContext.SaveChanges();
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var Contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Contacts.Remove(Contact);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var Contacts = _dbContext.Contacts;
            _dbContext.Contacts.RemoveRange(Contacts);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Import(IEnumerable<Contact> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}