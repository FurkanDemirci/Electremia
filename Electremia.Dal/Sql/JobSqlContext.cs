using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class JobSqlContext : Connection, IJobRepository
    {
        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Job entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Job entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Job entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAll(int id)
        {
            const string query =
                "SELECT JobID, Name, Position, Description, StartDate, EndDate FROM [Job] WHERE UserID = {0} AND Active = 1";
            var queryFull = string.Format(query, id);
            List<Job> jobs = new List<Job>();
            Job job = null;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        job = new Job
                        {
                            JobId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Position = reader.GetString(2),
                            Description = reader.GetString(3),
                            StartDate = reader.GetDateTime(4),
                            EndDate = reader.GetDateTime(5)
                        };
                        jobs.Add(job);
                    }
                }
            }
            return jobs;
        }
    }
}