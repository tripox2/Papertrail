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
    public class MiddlewareHandler
    {
        public MiddlewareHandler(RequestDelegate next)
        { }

        public async Task Invoke(HttpContext context)
        {
            var papertrailHandler = new PapertrailHandler();
            string content = ReadContent(context);
            new Task(() =>
            {
                papertrailHandler.Invoke(content);
            }).Start();
            // Return response
            context.Response.StatusCode = 200;
        }

        private string ReadContent(HttpContext context)
        {
            string content = string.Empty;
            if (context.Request.Body != null)
            {
                StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8);
                content = reader.ReadToEnd();
                reader.Close();
                
                if(context.Request.ContentType.ToLower() == "application/x-www-form-urlencoded")
                {
                    content = System.Web.HttpUtility.UrlDecode(content);
                    // Remove payload key
                    content = content.Replace("payload=", "");
                }
                // If content type = application/json. Just extract and forward the content.
            }
            return content;
        }
    }

    public static class MiddlewareHandlerExtensions
    {
        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareHandler>();
        }
    }
}
