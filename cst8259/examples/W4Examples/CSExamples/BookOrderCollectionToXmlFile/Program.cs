using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BookOrderBusinessEntity;
using BookOrderUtility;


namespace BookOrderToXmlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlSerializer serializor = new XmlSerializer(typeof(BookOrder));

                BookOrder order = OrderUtility.GetABookOrder();

                XmlTextWriter tw = new XmlTextWriter("C:/Temp/BookOrder.xml", Encoding.UTF8);
                serializor.Serialize(tw, order);
                tw.Close();

                Console.WriteLine("Book Order XML Serialization Complete");
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
