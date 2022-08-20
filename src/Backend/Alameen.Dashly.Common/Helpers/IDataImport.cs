using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.DataImport
{
    public interface IDataImport<T>
    {
        Task<IEnumerable<T>> ExecuteAsync(string data);
    }

    public enum ImportType
    {
        WebApp=1,
        Note,
        Contact
    }
}