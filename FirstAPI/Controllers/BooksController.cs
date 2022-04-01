using FirstAPI.Managers;
using FirstAPI.Models;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors(Startup.AllowOnlyGetCorsPolicy)]
    [Route("mitsuperapi/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly string BookCache = "books";
        private readonly IMemoryCache _memoryCache;
        private IBooksManager _manager;

        public BooksController(IMemoryCache memoryCache, BookDbContext context)
        {
            _memoryCache = memoryCache;

            _manager = new BooksManager();
            //_manager = new BookDbManager(context);
        }

        [EnableCors(Startup.AllowAllCorsPolicy)]
        // GET: api/Books?test=1&filterString=networks
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery] string filterString, [FromQuery] int? minimumPrice, [FromHeader] string testheader, [FromQuery] string sortBy)
        {
            //string testHeader = Request.Headers["testheader"];
            Response.Headers.Add("test-header-response", testheader);

            IEnumerable<Book> books = null;

            //if (_memoryCache.TryGetValue(BookCache, out books))
            //{
            //    return books;
            //}

            books = _manager.GetAll(filterString, minimumPrice, sortBy);

            //var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            //_memoryCache.Set(BookCache, books, cacheOptions);
            if (books.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }
        }

        [HttpGet("titlesort")]
        public ActionResult<IEnumerable<Book>> Get()
        {
        }

            [HttpGet("authers/{autherId}/books/{bookid}")]
        public void test(int autherId, int bookid)
        {

        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        // GET https://hostt/api/books/1
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _manager.GetByID(id);
        }

        /// <summary>
        /// Opretter et object og sender object plus URI tilbage
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        // POST api/<BooksController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book newBook)
        {
            Book createdBook = _manager.AddBook(newBook);
            return Created("/api/books/" + createdBook.ID, createdBook);
        }

        [ApiExplorerSettings(GroupName = "v2")]
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
