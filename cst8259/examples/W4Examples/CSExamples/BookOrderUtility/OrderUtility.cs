using BookOrderBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookOrderUtility
{
    public static class OrderUtility
    {
        static public BookOrder GetABookOrder()
        {
            List<OrderItem> items = new List<OrderItem>();

            Book book = new Book("123456789", "XML Programming", 49.99);
            OrderItem item = new OrderItem(book, 2);
            items.Add(item);

            book = new Book("789023456", "C# Programming", 39.99);
            item = new OrderItem(book, 1);
            items.Add(item);

            book = new Book("abcdefghij", "Java Programming", 39.99);
            item = new OrderItem(book, 3);
            items.Add(item);

            Address billingAddress = new Address("193 Walden Drive", "", "Kanata", "Ontario", "Canada");
            Address shippingAddress = new Address("193 Walden Drive", "", "Kanata", "Ontario", "Canada");

            Customer customer = new Customer("Wei Gong", billingAddress, shippingAddress);

            return new BookOrder(items, customer, DateTime.Now);
        }

        static public List<BookOrder> GetAListOfBookOrder()
        {
            List<BookOrder> orders = new List<BookOrder>();

            List<OrderItem> items = new List<OrderItem>();

            Book book = new Book("123456789", "XML Programming", 49.99);
            OrderItem item = new OrderItem(book, 2);
            items.Add(item);

            book = new Book("789023456", "C# Programming", 39.99);
            item = new OrderItem(book, 1);
            items.Add(item);

            book = new Book("abcdefghij", "Java Programming", 39.99);
            item = new OrderItem(book, 3);
            items.Add(item);

            Address billingAddress = new Address("193 Walden Drive", "", "Kanata", "Ontario", "Canada");
            Address shippingAddress = new Address("193 Walden Drive", "", "Kanata", "Ontario", "Canada");

            Customer customer = new Customer("Wei Gong", billingAddress, shippingAddress);

            BookOrder order = new BookOrder(items, customer, DateTime.Now);

            orders.Add(order);

            book = new Book("789023456", "C# Programming", 39.99);
            item = new OrderItem(book, 1);
            items.Add(item);

            book = new Book("abcdefghij", "Java Programming", 39.99);
            item = new OrderItem(book, 1);
            items.Add(item);

            billingAddress = new Address("100 Woodroff Avenue", "", "Nepean", "Ontario", "Canada");

            customer = new Customer("Wei Gong", billingAddress, shippingAddress);

            order = new BookOrder(items, customer, DateTime.Now);

            orders.Add(order);

            return orders;

        }
    }
}
