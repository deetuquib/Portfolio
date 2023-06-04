using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookOrderBusinessEntity
{
    public class Book
    {
        public Book() { }
        public Book(string isbn, string title, double price)
        {
            ISBN = isbn;
            Title = title;
            Price = price;
        }

        public string ISBN
        {
            get;
            set;
        }


        public string Title
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
    }
}
