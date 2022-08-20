using Dashly.API.Feature.Documents.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Documents.Data
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