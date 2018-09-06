using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Papertrail
{
    class Program
    {
        static string port = Environment.GetEnvironmentVariable("WEBSERVICE_PORT");

        static void Main(string[] args)
        {
            Console.WriteLine("Web service port: " + port);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .UseUrls("http://*:" + port)
           .Build();
    }
}
