using System;

namespace Alameen.Dashly.API.Models
{
    public class HangfireJob
    {
        public string Id { get; set; }
        public string State { get; set; }
        public DateTime EnqueueTime { get; set; }
        public DateTime? StartTime { get; set; }

        public DateTime? CompletedTime { get; set; }

    }
}