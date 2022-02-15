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
    public class JsonController : ControllerBase
    {
        // GET: api/<JsonController>
        [HttpGet]
        public string Get()
        {
            Book myBook = new Book() { ID = 2, Price = 5, Title = "Wee god bog" };
            string outerJson = "{\"book\":\"" + JsonSerializer.Serialize(myBook).Replace("\"","\\\"") + "\"}";
            JsonSerializer.Deserialize<Book>("{\\\"ID\\\":2,\\\"Title\\\":\\\"Wee god bog\\\",\\\"Price\\\":5}");
            return outerJson;
        }

        // POST api/<JsonController>
        [HttpPost]
        public Book Post([FromBody] string value)
        {
            return JsonSerializer.Deserialize<Book>("{\\\"ID\\\":2,\\\"Title\\\":\\\"Wee god bog\\\",\\\"Price\\\":5}");
        }
    }
}
