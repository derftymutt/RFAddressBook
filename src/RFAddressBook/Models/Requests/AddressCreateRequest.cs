using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RFAddressBook.Models.Requests
{
    public class AddressCreateRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

    }
}