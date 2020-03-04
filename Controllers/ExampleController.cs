using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NetCoreMicroservice.Domain;

namespace NetCoreMicroservice.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {

        [HttpGet]
        [Route("testservice")]
        public string Get()
        {
            return "Hello from .Net-Core to " + HttpContext.Connection.RemoteIpAddress + "!";
        }

        [HttpPost]
        [Route("testservice")]
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

        [HttpPost]
        [Route("testservice/person")]
        [Consumes("application/json")]
        public string PostPersonJson([FromBody] Person person)
        {
            return "Hello, " + person.FirstName + "! Nice JSON.";
        }

        [HttpPost]
        [Route("testservice/person")]
        [Consumes("application/x-www-form-urlencoded")]
        public string PostPersonUrlEncoded([FromForm] Person person)
        {
            return "Hello, " + person.FirstName + "! Nice URL-Encoding.";
        }
    }
}
