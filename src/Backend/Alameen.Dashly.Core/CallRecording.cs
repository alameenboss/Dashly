using System;

namespace Alameen.Dashly.Core
{
    public class CallRecording
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public double TotalSeconds { get; set; }

        public string HashValue { get; set; }
    }
}