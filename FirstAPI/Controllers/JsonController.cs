using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class JsonController : ControllerBase
    {
        // GET: api/<JsonController>
        [HttpGet]
        public string Get([FromHeader] string myCustomHeader)
        {
            string headerValue = Request.Headers["myRequestHeader"];
            Response.Headers.Add("myResponseHeader", headerValue);
            Response.Headers.Add("test2resp", myCustomHeader);

            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                return headerValue;
            }
            return "some Json";
        }

        // POST api/<JsonController>
        [HttpPost]
        public Book Post([FromBody] string value)
        {
            return JsonSerializer.Deserialize<Book>("{\\\"ID\\\":2,\\\"Title\\\":\\\"Wee god bog\\\",\\\"Price\\\":5}");
        }
    }
}
