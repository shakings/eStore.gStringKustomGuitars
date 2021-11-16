using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System.IO;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }
        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            context.Request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await _next(context);

            RewindStreamToIndex(context.Response.Body, 0);
            var text = await ReadResponseBodyAsync(context);
            RewindStreamToIndex(context.Response.Body, 0);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private static async Task<string> ReadResponseBodyAsync(HttpContext context)
        {
            return await new StreamReader(context.Response.Body).ReadToEndAsync();
        }

        private static void RewindStreamToIndex(Stream stream, int idx)
        {
            stream.Seek(idx, SeekOrigin.Begin);
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            RewindStreamToIndex(stream, 0);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
    }
}
