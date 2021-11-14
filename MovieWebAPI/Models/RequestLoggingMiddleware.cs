using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class RequestLoggingMiddleware
    {
        private RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Logic to log your request. Can be accessed via "context.Request"
            var request = context.Request;
            request.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(request.Body).ReadToEndAsync();
            await _next.Invoke(context);
        }
    }
}
