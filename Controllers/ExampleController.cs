using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
