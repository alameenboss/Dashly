using Alameen.Dashly.Core;
using Alameen.Dashly.Repository;
using Alameen.Dashly.Repository.Contract;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneCallsController : ControllerBase
    {
        private readonly ICallRecordingRepository _callRecordingRepository;
        private readonly ScanRecordings _scanRecordings;
        public PhoneCallsController(ScanRecordings scanRecordings, ICallRecordingRepository callRecordingRepository)
        {
            _scanRecordings = scanRecordings;
            _callRecordingRepository = callRecordingRepository;
        }

        [HttpPost("scan")]
        public IActionResult ScanCallRecorings()
        {
            BackgroundJob.Enqueue(() => _scanRecordings.ScanCallRecordingAsync());
            return Ok();
        }


        [HttpGet]
        public async Task<IEnumerable<CallRecording>> GetAll()
        {
            return await _callRecordingRepository.GetAll();
        }

        [HttpDelete]
        public async Task DeleteAll()
        {
            await _callRecordingRepository.DeleteAll();
        }

    }
}
