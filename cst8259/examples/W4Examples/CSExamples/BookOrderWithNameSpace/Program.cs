using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BookOrderBusinessEntity;
using BookOrderUtility;


namespace BookOrderWithNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlRootAttribute ra = new XmlRootAttribute();
                ra.ElementName = "AlgonquinBookStoreBookOrder";
                ra.Namespace = "hppt://www.algonquincollege.com/onlineservice";

                XmlSerializer serializor = new XmlSerializer(typeof(BookOrder), ra);

                BookOrder order = OrderUtility.GetABookOrder();

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
