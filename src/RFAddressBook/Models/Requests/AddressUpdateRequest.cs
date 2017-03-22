using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RFAddressBook.Models.Requests
{
    public class AddressUpdateRequest : AddressCreateRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}