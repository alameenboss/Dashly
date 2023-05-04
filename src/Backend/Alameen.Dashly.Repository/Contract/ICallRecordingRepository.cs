using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
{
    public interface ICallRecordingRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteAll();
        Task<IEnumerable<CallRecording>> GetAll();
        Task<CallRecording> GetById(int id);
        Task Import(IEnumerable<CallRecording> entities);
        Task<int> Insert(CallRecording entity);
        Task<bool> Update(CallRecording model, int id);
    }
}