using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BookOrderBusinessEntity;
using BookOrderUtility;

namespace BookOrderCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlRootAttribute ra = new XmlRootAttribute();
                ra.ElementName = "BookOrders";

                XmlSerializer serializor = new XmlSerializer(typeof(List<BookOrder>), ra);
                //XmlSerializer serializor = new XmlSerializer(typeof(List<BookOrder>));

                List<BookOrder> orders = OrderUtility.GetAListOfBookOrder();

                serializor.Serialize(Console.Out, orders);
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
