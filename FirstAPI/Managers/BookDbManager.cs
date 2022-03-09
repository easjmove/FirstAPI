using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Managers
{
    public class BookDbManager : IBooksManager
    {
        private BookDbContext _bookContext;

        public BookDbManager(BookDbContext context)
        {
            _bookContext = context;
        }

        public Book AddBook(Book newBook)
        {
            newBook.ID = 0;
            _bookContext.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        public IEnumerable<Book> GetAll(string filterString, int? minimumPrice)
        {
            return _bookContext.Books;
        }

        public Book GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
