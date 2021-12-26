using Dashly.API.Feature.Contacts.Models;
using Dashly.API.Repositories.Data;
using MixERP.Net.VCards;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.DataImport
{
    public class ImportContact : IDataImport
    {
        private DashlyContext _context;
        public ImportContact(DashlyContext context)
        {
            _context = context;
        }
        public async Task<bool> ExecuteAsync(string data)
        {
            var vcards = Deserializer.GetVCards(data).ToList();

            vcards.ForEach(vcard =>
            {
                var contact = new Contact()
                {
                    FirstName = vcard.FirstName,
                    LastName = vcard.LastName,
                    Number = vcard?.Telephones?.FirstOrDefault()?.Number,
                };
                //_context.Add(contact);
            });

            //_context.SaveChanges();

            return true;
        }
    }
}
