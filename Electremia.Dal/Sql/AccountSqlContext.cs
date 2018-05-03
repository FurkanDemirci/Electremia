using System;
using System.Collections.Generic;
using System.Data;
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
            User user = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_GetByUsername", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
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
                            ProfilePicture = reader.GetString(5),
                            CoverPicture = reader.GetString(6),
                            Certificate = reader.GetString(7),
                            Active = reader.GetBoolean(8),
                            Admin = reader.GetBoolean(9)
                        };
                    }
                }
            }
            MSSQLConnectionString.Close();
            return user;
        }

        public User GetByLogin(string username, string password)
        {
            User user = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_CheckUsrAndPass", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username" , SqlDbType.VarChar).Value = username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
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
                            ProfilePicture = reader.GetString(5),
                            CoverPicture = reader.GetString(6),
                            Certificate = reader.GetString(7),
                            Active = reader.GetBoolean(8),
                            Admin = reader.GetBoolean(9)
                        };
                    }
                }
            }
            MSSQLConnectionString.Close();
            return user;
        }

        public User GetById(int id)
        {
            User user = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_GetById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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
                            ProfilePicture = reader.GetString(5),
                            CoverPicture = reader.GetString(6),
                            Certificate = reader.GetString(7),
                            Active = reader.GetBoolean(8),
                            Admin = reader.GetBoolean(9)
                        };
                    }
                }
            }
            MSSQLConnectionString.Close();
            return user;
        }

        public bool Add(User entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_AddUser", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = entity.Firstname;
                command.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = entity.Lastname;
                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = entity.Username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = entity.Password;
                command.Parameters.AddWithValue("@ProfilePicture", SqlDbType.VarChar).Value = "Blank-profile.png";
                command.Parameters.AddWithValue("@CoverPicture", SqlDbType.VarChar).Value = "Blank-cover.png";
                command.Parameters.AddWithValue("@Certificate", SqlDbType.VarChar).Value = entity.Certificate;
                command.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = 1;
                command.Parameters.AddWithValue("@Admin", SqlDbType.Bit).Value = 0;

                try
                {
                    command.ExecuteNonQuery();
                    MSSQLConnectionString.Close();
                    return true;
                }
                catch
                {
                    MSSQLConnectionString.Close();
                    return false;
                }
            }
        }

        public bool Update(User entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_UpdateById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.UserId;
                command.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = entity.Firstname;
                command.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = entity.Lastname;
                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = entity.Username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = entity.Password;
                command.Parameters.AddWithValue("@ProfilePicture", SqlDbType.VarChar).Value = entity.ProfilePicture;
                command.Parameters.AddWithValue("@CoverPicture", SqlDbType.VarChar).Value = entity.CoverPicture;
                command.Parameters.AddWithValue("@Certificate", SqlDbType.VarChar).Value = entity.Certificate;
                //TODO Active en Admin moet verandert kunnen worden.
                command.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = entity.Active;
                command.Parameters.AddWithValue("@Admin", SqlDbType.Bit).Value = entity.Admin;

                try
                {
                    command.ExecuteNonQuery();
                    MSSQLConnectionString.Close();
                    return true;
                }
                catch
                {
                    MSSQLConnectionString.Close();
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
                    MSSQLConnectionString.Close();
                    return true;
                }
                catch
                {
                    MSSQLConnectionString.Close();
                    return false;
                }
            }
        }

        public User GetFullUser(int id)
        {
            User user = null;
            var jobs = new List<Job>();
            var schools = new List<School>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spUser_GetFullUser", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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
                            ProfilePicture = reader.GetString(5),
                            CoverPicture = reader.GetString(6),
                            Certificate = reader.GetString(7),
                            Active = reader.GetBoolean(8),
                            Admin = reader.GetBoolean(9)
                        };
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        var job = new Job
                        {
                            JobId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Position = reader.GetString(3),
                            Description = reader.GetString(4),
                            StartDate = reader.GetDateTime(5),
                            EndDate = reader.GetDateTime(6)
                        };
                        jobs.Add(job);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        var school = new School
                        {
                            SchoolId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Years = reader.GetInt32(3),
                            AttendedFor = reader.GetString(4)
                        };
                        schools.Add(school);
                    }
                }
            }

            if (user == null) return null;
            user.Jobs = jobs;
            user.Schools = schools;
            MSSQLConnectionString.Close();
            return user;
        }
    }
}
