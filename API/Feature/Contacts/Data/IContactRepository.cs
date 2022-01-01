using Dashly.API.Feature.Contacts.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Contacts.Data
{
    public interface IContactRepository
    {
        Task<Contact> GetById(int id);

        Task<IEnumerable<Contact>> GetAll();

        Task<int> Insert(Contact entity);

        Task<bool> Update(Contact entity, int id);

        Task<bool> Delete(int id);

        Task<bool> DeleteAll();

        Task<bool> Import(IEnumerable<Contact> entities);
    }
}