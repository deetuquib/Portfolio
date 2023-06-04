using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BookOrderBusinessEntity;
using BookOrderUtility;


namespace BookOrderWithNamespacePrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); 
	            ns.Add("alg", "http://www.algonquincollege.com/onlineservice"); 

                XmlSerializer serializor = new XmlSerializer(typeof(BookOrder));

                BookOrder order = OrderUtility.GetABookOrder();

                serializor.Serialize(Console.Out, order, ns);
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
