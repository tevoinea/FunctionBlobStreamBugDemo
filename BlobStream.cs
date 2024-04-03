using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace BugDemo
{
    public class BlobStream
    {
        private readonly ILogger _logger;

        public BlobStream(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BlobStream>();
        }

        [Function("BlobStream")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var fStream = new FileStream("C:\\CustomerLogs\\tools.zip", FileMode.Open);
            return new FileStreamResult(fStream, new MediaTypeHeaderValue("application/zip"));
        }
    }
}
