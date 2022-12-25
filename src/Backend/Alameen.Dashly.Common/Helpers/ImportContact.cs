using Alameen.Dashly.Core;
using MixERP.Net.VCards;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alameen.Dashly.Common.Helpers
{
    public class ImportContact : DataImport<Contact>, IDataImport<Contact>
    {
        public override async Task<IEnumerable<Contact>> ExecuteAsync(string data)
        {
            return await Task.Run(() =>
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
                return contacts;
            });
        }
    }
}