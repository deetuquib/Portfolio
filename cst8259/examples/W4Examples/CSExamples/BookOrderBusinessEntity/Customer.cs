using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookOrderBusinessEntity
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name, Address billing, Address shipping)
        {
            Name = name;
            BillingAddress = billing;
            ShippingAddress = shipping;
        }

        public string Name
        { 
            get; 
            set; 
        }
        public Address BillingAddress
        {
            get;
            set;
        }
        public Address ShippingAddress
        {
            get;
            set;
        }
    }
}
