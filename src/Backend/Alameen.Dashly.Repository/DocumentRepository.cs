using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using Alameen.Dashly.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;   
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public DocumentRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<bool> Delete(string docId)
        {
            var doc = await _dbContext.Documents.FirstOrDefaultAsync(x => x.DocId == docId);
            _dbContext.Documents.Remove(doc);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            _dbContext.Documents.RemoveRange(_dbContext.Documents);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _dbContext.Documents.ToListAsync();
        }

        public async Task<Document> GetById(string docId)
        {
            return await _dbContext.Documents.FirstOrDefaultAsync(x => x.DocId == docId);
        }

        public async Task<bool> Save(Document model)
        {
            var doc = await _dbContext.Documents.FirstOrDefaultAsync(x => x.DocId == model.DocId);
            if (doc != null)
            {
                doc.Content = model.Content;
                _dbContext.Documents.Update(doc);
            }
            else
            {
                _dbContext.Documents.Add(model);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}