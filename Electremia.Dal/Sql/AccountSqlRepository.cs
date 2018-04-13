using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class AccountSqlRepository : IRepository<User>
    {
        public SqlConnection ConnectionString { get; set; }

        public User GetByUsername(string username)
        {
            // SQL eigenlijk
            // SQL code
            var query = "SELECT UserID, Firstname, Lastname, Username, Password FROM [User] WHERE Username = '{0}' AND Active = 1";
            var queryFull = string.Format(query, username);
            User user = null;
            ConnectionString.Open();
            using (var command = new SqlCommand(queryFull, ConnectionString))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User
                        {
                            UserId = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Lastname = reader.GetString(2),
                            Username = reader.GetString(3),
                            Password = reader.GetString(4),
                        };
                    }
                }
            }
            return user;
        }

        

        public object GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(User entity)
        {
            // SQL CODE voor inserten
            // Stuurt Bool terug of het is gelukt.
            return true;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
