using FirstAPI.Models;
using System.Collections.Generic;

namespace FirstAPI.Managers
{
    public interface IBooksManager
    {
        Book AddBook(Book newBook);
        IEnumerable<Book> GetAll(string filterString, int? minimumPrice);
        Book GetByID(int ID);
    }
}