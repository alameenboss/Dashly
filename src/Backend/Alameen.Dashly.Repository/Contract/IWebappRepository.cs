using Dashly.API.Feature.WebApps.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.WebApps.Data.Repository
{
    public interface IWebappRepository
    {
        Task<Webapp> GetById(int id);

        Task<IEnumerable<Webapp>> GetAll();

        Task<int> Insert(Webapp entity);

        Task<bool> Update(Webapp entity, int id);

        Task<bool> Delete(int id);

        Task<bool> DeleteAll();

        Task<bool> AddAttachment(int id, Attachment attachment);

        Task<bool> Import(IEnumerable<Webapp> entities);
    }
}