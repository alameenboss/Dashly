using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
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