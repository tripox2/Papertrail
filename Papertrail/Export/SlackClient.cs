using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;

namespace Papertrail.Export
{
    public class SlackClient
    {
        private readonly string webhookUrl = Environment.GetEnvironmentVariable("SLACK_WEBHOOK");
        private readonly string channel = Environment.GetEnvironmentVariable("SLACK_CHANNEL");
        private readonly string username = Environment.GetEnvironmentVariable("SLACK_USERNAME");

        public bool Publish(Dictionary<string, int> logCollection)
        {
            Console.WriteLine("Publish logs to Slack channel: " + channel + " with username:" + username);

            bool result = false;
            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 10);

            Console.WriteLine("Number of logs to export: " + logCollection.Count);
            foreach (var log in logCollection)
            {
                var message = new Model.SlackMessage()
                {
                    Channel = channel,
                    Text = String.Format("{0} | {1} rows", log.Key, log.Value),
                    Username = username
                };
               
                var content = new StringContent(message.ToJson(), Encoding.UTF8, "application/json");
                var response = client.PostAsync(webhookUrl, content).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    result = true;
            }
            return result;
        }
    }
}
