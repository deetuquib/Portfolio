using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BookOrderBusinessEntity;
using BookOrderUtility;

namespace BookOrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                BookOrder order = OrderUtility.GetABookOrder();
 
                XmlSerializer serializor = new XmlSerializer(typeof(BookOrder));

                serializor.Serialize(Console.Out, order);
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
