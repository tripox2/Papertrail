using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Papertrail.Model
{
    public class SlackMessage
    {
        private string channel;

        [JsonProperty(PropertyName = "channel", Required = Required.Always)]
        public string Channel
        {
            get { return channel; }
            set
            {
                if (value.StartsWith('#'))
                    channel = value;
                else
                    channel = "#" + value;
            }
        }

        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "username", Required = Required.Always)]
        public string Username { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
