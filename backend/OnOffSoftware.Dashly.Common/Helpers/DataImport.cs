using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.Common.Helpers
{
    public abstract class DataImport<T> : IDataImport<T>
    {
        public virtual async Task<IEnumerable<T>> ExecuteAsync(string data)
        {
            return await Task.Run(() =>
            {
                var result = JsonConvert.DeserializeObject<List<T>>(data);
                return result;
            });

        }
    }
}