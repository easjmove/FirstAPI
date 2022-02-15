﻿using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Managers
{
    public class BooksManager
    {
        private static int nextID = 1;
        private static List<Book> data = new List<Book>()
        {
            new Book() {ID = nextID++, Title = "Computer Networks", Price=800},
            new Book() {ID = nextID++, Title = "Not Computer Networks", Price=500},
            new Book() {ID = nextID++, Title = "Complitely different book", Price=10}
        };

        public List<Book> GetAll(string filterString, int? minimumPrice)
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