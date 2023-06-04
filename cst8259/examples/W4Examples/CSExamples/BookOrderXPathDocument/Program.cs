using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;

namespace BookOrderXPathDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            FileStream xs = new FileStream("C:/temp/BookOrder.xml", FileMode.Open);

            XPathDocument xp = new XPathDocument(xs);
            XPathNavigator docNavigation = xp.CreateNavigator();

            foreach(XPathNavigator node in docNavigation.Select("//BookOrder/Items/Book/Title"))
            {
                Console.WriteLine(node.Value.ToString());
            }

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
