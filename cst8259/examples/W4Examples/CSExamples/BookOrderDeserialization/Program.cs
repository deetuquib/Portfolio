using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using BookOrderBusinessEntity;
using BookOrderUtility;

namespace BookOrderDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileStream xs = new FileStream("C:/temp/BookOrder.xml", FileMode.Open);

                XmlSerializer serializor = new XmlSerializer(typeof(BookOrder));

                BookOrder order = (BookOrder)serializor.Deserialize(xs);

                Console.WriteLine("Customer {0}", order.Buyer.Name);
                foreach (OrderItem item in order.Items)
                {
                    Console.WriteLine("     Book title : {0}, Copies {1}", item.Book.Title, item.Quantity);
                }

                xs.Close();
                Console.ReadLine();

            }
            catch (System.Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Console.ReadLine();
            }

        }
    }
}
