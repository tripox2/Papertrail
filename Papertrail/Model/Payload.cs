using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Papertrail.Model
{
    public class Payload
    {
        [JsonProperty(PropertyName = "events")]
        public List<Event> Events { get; set; }

        [JsonProperty(PropertyName = "saved_search")]
        public object SavedSearch { get; set; }

        [JsonProperty(PropertyName = "max_id")]
        public ulong MaxId { get; set; }

        [JsonProperty(PropertyName = "min_id")]
        public ulong minId { get; set; }

        [JsonProperty(PropertyName = "frequency")]
        public string Frequency { get; set; }
    }
}
