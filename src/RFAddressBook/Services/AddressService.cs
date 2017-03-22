using RFAddressBook.Domain;
using RFAddressBook.Models.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RFAddressBook.Services
{
    public class AddressService
    {

        public static Guid Create(AddressCreateRequest model)
        {
            Guid createId;

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Addresses_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Street", model.Street);
                    cmd.Parameters.AddWithValue("@Street2", model.Street2);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@PostalCode", model.PostalCode);

                    SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputIdParam);

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    createId = Guid.Parse(outputIdParam.Value.ToString());
                }
            }

            return createId;

        }

        public static void Update(AddressUpdateRequest model)
        {

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Addresses_Update";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Street", model.Street);
                    cmd.Parameters.AddWithValue("@Street2", model.Street2);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@PostalCode", model.PostalCode);

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Address> Get(int userId)
        {
            List<Address> list = null;

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Addresses_Select";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (list == null)
                                {
                                    list = new List<Address>();
                                }

                                Address a = new Address();
                                int startingIndex = 0;

                                a.Id = reader.GetGuid(startingIndex++);
                                a.UserId = reader.GetInt32(startingIndex++);
                                a.Name = reader.GetString(startingIndex++);
                                a.Street = reader.GetString(startingIndex++);
                                a.Street2 = reader.GetString(startingIndex++);
                                a.City = reader.GetString(startingIndex++);
                                a.State = reader.GetString(startingIndex++);
                                a.PostalCode = reader.GetString(startingIndex++);
                                a.CreationDateTime = reader.GetDateTime(startingIndex++);

                                list.Add(a);
                            }
                        }
                    }
                }
            }

            return list;
        }

        public static Address Get(int userId, Guid id)
        {
            Address a = null;

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Addresses_SelectById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@UserId", userId);


                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                               if (a == null)
                                {
                                    a = new Address();
                                }
                                
                                int startingIndex = 0;

                                a.Id = reader.GetGuid(startingIndex++);
                                a.UserId = reader.GetInt32(startingIndex++);
                                a.Name = reader.GetString(startingIndex++);
                                a.Street = reader.GetString(startingIndex++);
                                a.Street2 = reader.GetString(startingIndex++);
                                a.City = reader.GetString(startingIndex++);
                                a.State = reader.GetString(startingIndex++);
                                a.PostalCode = reader.GetString(startingIndex++);
                                a.CreationDateTime = reader.GetDateTime(startingIndex++);
                              
                            }
                        }
                    }
                }
            }
            return a;     
        }

        public static void Delete(int userId, Guid id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Addresses_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
