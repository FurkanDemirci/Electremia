using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public bool Delete(School entity)
        {
            throw new NotImplementedException();
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
    }
}