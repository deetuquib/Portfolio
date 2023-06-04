using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookOrderBusinessEntity
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }

        public Book Book
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
    }
}
