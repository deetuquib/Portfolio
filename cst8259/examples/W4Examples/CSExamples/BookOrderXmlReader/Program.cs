using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace BookOrderXmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;
                settings.CheckCharacters = true;

                FileStream xs = new FileStream(@"..\..\..\BookOrder.xml", FileMode.Open);

                XmlReader xr = XmlReader.Create(xs, settings);

                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "CustomerContact")
                    {
                        Console.WriteLine(xr.Name + " " + xr.ReadElementContentAsString());
                    }
                    if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "First")
                    {
                        Console.WriteLine(xr.Name + ": " + xr.ReadElementContentAsString());
                    }
                    if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "Last")
                    {
                        Console.WriteLine(xr.Name + ": " + xr.ReadElementContentAsString());
                    }

                    if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "Title")
                    {
                        Console.WriteLine(xr.Name + " " + xr.ReadElementContentAsString());
                    }

                }

                xr.Close();
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
