using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class AccountSqlContext : Connection, IAccountRepository
    {
        public User GetByUsername(string username)
        {
            const string query =
                "SELECT UserID, Firstname, Lastname, Username, Password FROM [User] WHERE Username = '{0}' AND Active = 1";
            var queryFull = string.Format(query, username);
            User user = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
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

        public User GetById(int id)
        {
            const string query = "SELECT * FROM [User] WHERE UserID = {0} AND Active = 1";
            var queryFull = string.Format(query, id);
            User user = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
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

        public bool Add(User entity)
        {
            const string query =
                "INSERT INTO [User](Firstname, Lastname, Username, Password, Active, Admin) VALUES('{0}', '{1}', '{2}', '{3}', 1, 0)";
            var queryFull = string.Format(query, entity.Firstname, entity.Lastname, entity.Username, entity.Password);
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Update(User entity)
        {
            const string query =
                "UPDATE [User] SET Firstname = '{0}', Lastname = '{1}', Username = '{2}', Password = '{3}', ProfilePicture = '{4}', CoverPicture = '{5}', Certificate = '{6}', Active = 1, Admin = 0 WHERE UserID = {7} ";
            var queryFull =
                string.Format(query, entity.Firstname, entity.Lastname, entity.Username, entity.Password,
                    entity.ProfilePicture, entity.CoverPicture, entity.Certificate, entity.UserId);
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(User entity)
        {
            const string query = "DELETE FROM [User] WHERE UserID = 6";
            var queryFull = string.Format(query, entity.UserId);
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
