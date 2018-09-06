using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Papertrail.Model
{
    public class Event
    {
        [JsonProperty(PropertyName = "id")]
        public ulong Id { get; set; }

        [JsonProperty(PropertyName = "received_at")]
        public DateTimeOffset ReceivedAt { get; set; }

        [JsonProperty(PropertyName = "displayed_received_at")]
        public string DisplayedReceivedAt { get; set; }

        [JsonProperty(PropertyName = "source_ip")]
        public string SourceIp { get; set; }

        [JsonProperty(PropertyName = "source_name")]
        public string SourceName { get; set; }

        [JsonProperty(PropertyName = "source_id")]
        public int SourceId { get; set; }

        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }

        [JsonProperty(PropertyName = "program")]
        public string Program { get; set; }

        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "facility")]
        public string Facility { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] {1}: {2}", Severity, Program, Message);
        }
    }
}
