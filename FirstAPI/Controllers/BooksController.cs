using FirstAPI.Managers;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly string BookCache = "books";
        private readonly IMemoryCache _memoryCache;
        private BooksManager _manager = new BooksManager();

        public BooksController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET: api/Books?test=1&filterString=networks
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery] string filterString, [FromQuery] int? minimumPrice)
        {
            IEnumerable<Book> books = null;

            //if (_memoryCache.TryGetValue(BookCache, out books))
            //{
            //    return books;
            //}

            books = _manager.GetAll(filterString, minimumPrice);

            //var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            //_memoryCache.Set(BookCache, books, cacheOptions);

            if (books.Count() <= 0)
            {
                return NotFound();
            } else
            {
                return Ok(books);
            }
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _manager.GetByID(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book newBook)
        {
            return _manager.AddBook(newBook);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
