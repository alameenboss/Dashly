using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
{
    public interface IDocumentRepository
    {
        Task<bool> Delete(string docId);

        Task<bool> DeleteAll();

        Task<IEnumerable<Document>> GetAll();

        Task<Document> GetById(string docId);

        Task<bool> Save(Document model);
    }
}