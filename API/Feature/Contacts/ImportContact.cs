using Dashly.API.Feature.Contacts.Data;
using Dashly.API.Feature.Contacts.Data.Entity;
using Dashly.API.Feature.DataImport;
using MixERP.Net.VCards;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Contacts
{
    public class ImportContact : IDataImport
    {
        private readonly IContactRepository _contactRepository;

        public ImportContact(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> ExecuteAsync(string data)
        {
            var vcards = Deserializer.GetVCards(data).ToList();
            var contacts = new List<Contact>();

            vcards.ForEach(vcard =>
            {
                contacts.Add(new Contact()
                {
                    FirstName = vcard.FirstName,
                    LastName = vcard.LastName,
                    Number = vcard?.Telephones?.FirstOrDefault()?.Number,
                });
            });

            await _contactRepository.Import(contacts);

            return true;
        }
    }
}