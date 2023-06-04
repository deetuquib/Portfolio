using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookOrderBusinessEntity
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string street1, string street2, string city, string province, string country)
        {
            StreetAddress1 = street1;
            StreetAddress2 = street2;
            City = city;
            Province = province;
            Country = country;
        }

        public string StreetAddress1
        {
            get;
            set;
        }
        public string StreetAddress2
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Province
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
    }
}
