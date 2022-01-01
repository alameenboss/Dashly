using System.Threading.Tasks;

namespace Dashly.API.Feature.DataImport
{
    public interface IDataImport
    {
        Task<bool> ExecuteAsync(string data);
    }
}