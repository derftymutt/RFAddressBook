using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFAddressBook.Domain
{
    public class Address
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}