using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Papertrail
{
    public class PapertrailHandler
    {
        public void Invoke(string content)
        {
            Console.WriteLine("PapertrailHandler invoked");
            // Deserialize information
            var events = ConvertContent(content);
            Console.WriteLine("Number of events: " + events.Count);
            if (events.Count > 0)
            {
                // Count and sort the information
                var logs = CountAndSort(events);
                // Export information
                var exporter = new Export.SlackClient();
                exporter.Publish(logs);
            }
            Console.WriteLine("PapertrailHandler finished");
        }

        private List<string> ConvertContent(string content)
        {
            var payload = new Model.Payload();
            var logs = new List<string>();
            try
            {
                payload = JsonConvert.DeserializeObject<Model.Payload>(content);
                foreach (var theEvent in payload.Events)
                    logs.Add(theEvent.Message);
            }
            catch (Exception exc)
            {
                string innerExceptionStr = exc.InnerException != null ? exc.InnerException.Message : string.Empty;
                Console.WriteLine("Failed to deserialize the content: " + exc.Message + ". InnerException: " + innerExceptionStr);
            }
            return logs;
        }

        private Dictionary<string, int> CountAndSort(List<string> events)
        {
            Console.WriteLine("Count and sort the events");
            var logs = new Dictionary<string, int>();
            // Count number of matched events
            for(int i = 0; i < events.Count; i++)
            {
                if (logs.Keys.Any(item => item == events[i]))
                    logs[events[i]]++;
                else
                    logs.Add(events[i], 1);
            }

            // Sort on number of events
            logs = logs.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);

            return logs;
        }
    }
}
