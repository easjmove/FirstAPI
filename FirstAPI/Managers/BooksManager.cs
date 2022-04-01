using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Managers
{
    public class BooksManager : IBooksManager
    {
        private static int nextID = 1;
        private static List<Book> data = new List<Book>()
        {
            new Book() {ID = nextID++, Title = "Computer Networks", Price=300},
            new Book() {ID = nextID++, Title = "Not Computer Networks", Price=500},
            new Book() {ID = nextID++, Title = "Complitely different book", Price=10}
        };
        public IEnumerable<Book> GetAll(string filterString, int? minimumPrice, string sortBy)
        {
            List<Book> result = new List<Book>(data);
            if (!string.IsNullOrWhiteSpace(filterString))
            {
                result = result.FindAll(c => c.Title.Contains(filterString, StringComparison.OrdinalIgnoreCase));
            }

            if (minimumPrice != null)
            {
                result = result.FindAll(c => c.Price >= minimumPrice);
            }

            //result = result.OrderBy(x => x.Title).ToList();
            result.Sort(new Book.GenericComparer(sortBy));

            return result;
        }


        public Book GetByID(int ID)
        {
            return data.Find(book => book.ID == ID);

            //foreach (Book book in data)
            //{
            //    if (book.ID == ID)
            //    {
            //        return book;
            //    }
            //}
            //return null;
        }

        public Book AddBook(Book newBook)
        {
            newBook.ID = nextID++;
            data.Add(newBook);
            return newBook;
        }
    }
}
