using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class RequestResponseLoggingMiddleware
    {

        private readonly RequestDelegate _next;
        

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       
        public async Task Invoke(HttpContext context, AppDbContext _db)
        {
            LogRequest logRequest = new LogRequest();
            //First, get the incoming request
            var request = await FormatRequest(context.Request);
            logRequest.searchValue = request;
            logRequest.RequestDate = DateTime.Now;
            var check = _db.LogRequests.Where(x => x.searchValue == request).FirstOrDefault();

            var path = context.Request.Path.ToString();

            string ids = path.Split('/').Last();

            var isNumeric = int.TryParse(ids, out int n);

            if(isNumeric)
            {
                logRequest.UserId = ids;
            }
            else
            {
                logRequest.UserId = "0";
            }
            //Copy a pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            //Create a new memory stream...
            using (var responseBody = new MemoryStream())
            {
                //...and use that for the temporary response body
                context.Response.Body = responseBody;
                if(check != null)
                {
                    context.Request.Method = "GET";
                    context.Request.Path = "/api/SearchMovies/AlreadySearched/" + check.Response;
                }
                //Continue down the Middleware pipeline, eventually returning to this class
                await _next(context);

                //Format the response from the server
                var response = await FormatResponse(context.Response);
                logRequest.Response = response;

                _db.LogRequests.Add(logRequest);
                _db.SaveChanges();
                //TODO: Save log to chosen datastore
                // MockLoggingRepository mockLogging = new MockLoggingRepository(AppDbContext db);
                //MockLoggingRepository mockLoggingRepository = new MockLoggingRepository();
                //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            //return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
            return $"{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{text}";

            //return $"{response.StatusCode}: {text}";
        }
    }

}
