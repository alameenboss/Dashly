using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.DataImport
{
    public interface IDataImport
    {
        Task<bool> ExecuteAsync(string data);
    }
}
