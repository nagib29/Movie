using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class ResponseLoggingMiddleware
    {
        private RequestDelegate _next;
        public ResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // observe the Invoke() method being called first
            var response=context.Response;
            await _next.Invoke(context);
            // This is where your logging logic goes. For eg., you can capture 404 as below
        
        }
    }
}
