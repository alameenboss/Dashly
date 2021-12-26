using Dashly.API.Helpers;
using Dashly.API.Repositories.Data;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Data.Entity.Notes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.DataImport
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
