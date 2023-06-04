using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookOrderBusinessEntity
{
    public class BookOrders
    {
        public BookOrders() { }

        public BookOrders(List<BookOrder> list)
        {
            BookOrderList = list;
        }
        public List<BookOrder> BookOrderList
        {
            get;
            set;
        }
    }
}
