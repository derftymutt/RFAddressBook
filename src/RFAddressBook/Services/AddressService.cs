using RFAddressBook.Domain;
using RFAddressBook.Models.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider;
using WikiDataProvider.Data.Extensions;

namespace RFAddressBook.Services
{
    public class AddressService : BaseService, IAddressService
    {

        public Address MapAddress(IDataReader reader)
        {
            Address currentAddress = new Address();
            int startingIndex = 0;

            currentAddress.Id = reader.GetSafeGuid(startingIndex++);
            currentAddress.UserId = reader.GetSafeInt32(startingIndex++);
            currentAddress.Name = reader.GetSafeString(startingIndex++);
            currentAddress.Street = reader.GetSafeString(startingIndex++);
            currentAddress.Street2 = reader.GetSafeString(startingIndex++);
            currentAddress.City = reader.GetSafeString(startingIndex++);
            currentAddress.State = reader.GetSafeString(startingIndex++);
            currentAddress.PostalCode = reader.GetSafeString(startingIndex++);
            currentAddress.CreationDateTime = reader.GetSafeDateTime(startingIndex++);

            return currentAddress;
        }

        public Guid Create(AddressCreateRequest model)
        {
            Guid createId = Guid.Empty;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Addresses_Insert",
                inputParamMapper: delegate (SqlParameterCollection parameters)
                {

                    parameters.AddWithValue("@UserId", model.UserId);
                    parameters.AddWithValue("@Name", model.Name);

                    if (model.Street == null)
                    {
                        parameters.AddWithValue("@Street", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@Street", model.Street);
                    }

                    if (model.Street2 == null)
                    {
                        parameters.AddWithValue("@Street2", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@Street2", model.Street2);
                    }

                    if (model.City == null)
                    {
                        parameters.AddWithValue("@City", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@City", model.City);
                    }

                    if (model.State == null)
                    {
                        parameters.AddWithValue("@State", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@State", model.State);
                    }

                    if (model.PostalCode == null)
                    {
                        parameters.AddWithValue("@PostalCode", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@PostalCode", model.PostalCode);
                    }

                    parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Guid,
                        Direction = ParameterDirection.Output,
                        ParameterName = "@Id"
                    });
                },
                  returnParameters: delegate (SqlParameterCollection parameters)
                  {
                      createId = Guid.Parse(parameters["@Id"].Value.ToString());
                  }
                );

            return createId;
        }

        public void Update(AddressUpdateRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Addresses_Update",
                inputParamMapper: delegate (SqlParameterCollection parameters)
                {

                    parameters.AddWithValue("@Id", model.Id);
                    parameters.AddWithValue("@UserId", model.UserId);
                    parameters.AddWithValue("@Name", model.Name);

                    if (model.Street == null)
                    {
                        parameters.AddWithValue("@Street", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@Street", model.Street);
                    }

                    if (model.Street2 == null)
                    {
                        parameters.AddWithValue("@Street2", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@Street2", model.Street2);
                    }

                    if (model.City == null)
                    {
                        parameters.AddWithValue("@City", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@City", model.City);
                    }

                    if (model.State == null)
                    {
                        parameters.AddWithValue("@State", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@State", model.State);
                    }

                    if (model.PostalCode == null)
                    {
                        parameters.AddWithValue("@PostalCode", DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue("@PostalCode", model.PostalCode);
                    }

                });
        }

        public List<Address> Get(int userId)
        {
            List<Address> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Addresses_Select"
            , inputParamMapper: delegate (SqlParameterCollection parameters)
            {
                parameters.AddWithValue("@UserId", userId);
            }
             , map: delegate (IDataReader reader, short set)
             {
                 Address address = MapAddress(reader);

                 if (list == null)
                 {
                     list = new List<Address>();
                 }

                 list.Add(address);
             }
             );

            return list;

        }

        public Address Get(int userId, Guid id)
        {
            Address address = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Addresses_SelectById",
               inputParamMapper: delegate (SqlParameterCollection parameters)
               {
                   parameters.AddWithValue("@UserId", userId);
                   parameters.AddWithValue("@Id", id);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   address = MapAddress(reader);
               });

            return address;
        }

        public void Delete(int userId, Guid id)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Addresses_Delete",
                inputParamMapper: delegate (SqlParameterCollection parameters)
                {
                    parameters.AddWithValue("@UserId", userId);
                    parameters.AddWithValue("@Id", id);
                });

        }

    }

}
