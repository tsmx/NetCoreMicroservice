using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NetCoreMicroservice.Controllers
{
    [ApiController]
    [Route("testservice")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello from .Net-Core to " + HttpContext.Connection.RemoteIpAddress + "!";
        }

        [HttpPost]
        public void Post()
        {
            string requestBody;
            object obj = null;
            using (var reader = new StreamReader(Request.Body))
            {
                requestBody = reader.ReadToEnd();
            }
            try
            {
                obj = JsonConvert.DeserializeObject(requestBody);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.Body.Write(Encoding.ASCII.GetBytes("Invalid JSON request: " + ex.Message));
                Response.StartAsync();
                return;
            }
            Response.StatusCode = 200;
            Response.Body.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(obj, Formatting.Indented)));
            Response.StartAsync();
        }
    }
}
