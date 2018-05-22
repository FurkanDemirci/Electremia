using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class SchoolSqlContext : Connection, ISchoolRepository
    {
        public School GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(School entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(School entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spSchool_UpdateById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.SchoolId;
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = entity.Name;
                command.Parameters.AddWithValue("@Years", SqlDbType.Int).Value = entity.Years;
                command.Parameters.AddWithValue("@AttendedFor", SqlDbType.VarChar).Value = entity.AttendedFor;
                
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

        public bool Delete(School entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spSchool_DeleteById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.SchoolId;

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

        public IEnumerable<School> GetAll(int id)
        {
            const string query =
                "SELECT * FROM [School] WHERE UserID = {0}";
            var queryFull = string.Format(query, id);
            List<School> schools = new List<School>();
            School school = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        school = new School
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
            return schools;
        }

        public bool DeleteAll(int id)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spSchool_DeleteByUserId", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

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
    }
}