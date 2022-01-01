using Dashly.API.Data.Entity;
using Dashly.API.Feature.DataImport;
using Dashly.API.Feature.Notes.Data.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Notes
{
    public class ImportNote : IDataImport
    {
        private DashlyContext _context;

        public ImportNote(DashlyContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecuteAsync(string data)
        {
            var result = JsonConvert.DeserializeObject<List<Note>>(data);

            result.ForEach(item =>
            {
                _context.Add(new Note()
                {
                    Title = item.Title,
                    Notes = item.Notes,
                    NoteCategoryId = item.NoteCategoryId
                });
            });

            _context.SaveChanges();

            return true;
        }
    }
}