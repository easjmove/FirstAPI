using FirstAPI;
using System;
using System.Net.Http;

namespace Consunmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpClient client = new HttpClient();
            BookClient bookClient = new BookClient("", client);
            bookClient.BooksAllAsync()
        }
    }
}
