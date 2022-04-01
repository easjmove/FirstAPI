using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class Book : IComparable<Book>
    {
        /// <summary>
        /// Det ID vi bruger
        /// </summary>
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public int CompareTo(Book other)
        {
            return Title.CompareTo(other.Title);
        }

        public class TitleComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return x.Title.CompareTo(y.Title);
            }
        }

        public class GenericComparer : IComparer<Book>
        {
            private string _compareField;
            public GenericComparer(string compareField)
            {
                _compareField = compareField;
            }
            public int Compare(Book x, Book y)
            {
                switch (_compareField)
                {
                    case ("title"):
                        return x.Title.CompareTo(y.Title);
                        break;
                    default:
                        return x.ID.CompareTo(y.ID);
                }
            }
        }
    }
}
