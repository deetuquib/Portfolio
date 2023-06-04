using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BookOrderBusinessEntity
{
    //[XmlRoot( Namespace = "http://www.algonquincollege.com/onlineservice")] 
    public class BookOrder
    {
 
        public BookOrder() { }
        
        public BookOrder(List<OrderItem> items, Customer buyer, DateTime orderDate)
        {
            Items = items;
            Buyer = buyer;
            OrderDate = orderDate;
        }

        public List<OrderItem> Items
        {
            get; 
            set;
        }

        public Customer Buyer
        {
            get; set;
        }

       [XmlElement(Namespace = "http://www.algonquincollege.com/onlineservice", DataType = "date")]
        public DateTime OrderDate
        {
            get; set;
        }

    }
}
