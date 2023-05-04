using Alameen.Dashly.API.Models;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Alameen.Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireJobsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetBackgroundJobs()
        {
            var jobStorage = JobStorage.Current;
            var monitoringApi = JobStorage.Current.GetMonitoringApi();

            var processingJobs = monitoringApi.ProcessingJobs(0, int.MaxValue);
            var enqueuedJobs = monitoringApi.EnqueuedJobs("default", 0, int.MaxValue);
            var scheduledJobs = monitoringApi.ScheduledJobs(0, int.MaxValue);

            var succeededJobs = monitoringApi.SucceededJobs(0, int.MaxValue);

            var jobs = new List<HangfireJob>();

            foreach (var job in processingJobs)
            {
                jobs.Add(new HangfireJob
                {
                    Id = job.Key,
                    State = "Processing",
                    StartTime = job.Value.StartedAt
                });
            }

            foreach (var job in enqueuedJobs)
            {
                jobs.Add(new HangfireJob
                {
                    Id = job.Key,
                    State = "Enqueued",
                    EnqueueTime = job.Value.EnqueuedAt.Value
                });
            }

            foreach (var job in scheduledJobs)
            {
                jobs.Add(new HangfireJob
                {
                    Id = job.Key,
                    State = "Scheduled",
                    EnqueueTime = job.Value.EnqueueAt
                });
            }
            foreach (var job in succeededJobs)
            {
                jobs.Add(new HangfireJob
                {
                    Id = job.Key,
                    State = "Completed",
                    CompletedTime = job.Value.SucceededAt.Value
                });
            }
            return Ok(jobs);
        }
    }
}
