using System;
using System.Collections.Generic;
using RFAddressBook.Domain;
using RFAddressBook.Models.Requests;


namespace RFAddressBook.Services
{
    public interface IAddressService
    {
        Guid Create(AddressCreateRequest model);
        void Delete(int userId, Guid id);
        List<Address> Get(int userId);
        Address Get(int userId, Guid id);
        void Update(AddressUpdateRequest model);
    }
}