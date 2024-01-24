using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.Common.Helpers
{
    public interface IDataImport<T>
    {
        Task<IEnumerable<T>> ExecuteAsync(string data);
    }

    public enum ImportType
    {
        WebApp = 1,
        Note
    }
}