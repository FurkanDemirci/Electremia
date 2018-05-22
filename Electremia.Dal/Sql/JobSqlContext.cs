using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            const string query =
                "INSERT INTO [Job](UserId, Name, Position, Description, StartDate, EndDate, Active) VALUES({0}, '{1}', '{2}', '{3}', {4}, {5}, 1)";
            var queryFull = string.Format(query, entity.UserId, entity.Name, entity.Position, entity.Description, entity.StartDate, entity.EndDate);
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

        public bool Update(Job entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spJob_UpdateById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.JobId;
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = entity.Name;
                command.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = entity.Position;
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = entity.Description;
                command.Parameters.AddWithValue("@StartDate", SqlDbType.DateTime).Value = entity.StartDate;
                command.Parameters.AddWithValue("@EndDate", SqlDbType.DateTime).Value = entity.EndDate;

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

        public bool Delete(Job entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spJob_DeleteById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.JobId;

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

        public IEnumerable<Job> GetAll(int id)
        {
            const string query =
                "SELECT * FROM [Job] WHERE UserID = {0}";
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
                            UserId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Position = reader.GetString(3),
                            Description = reader.GetString(4),
                            StartDate = reader.GetDateTime(5),
                            EndDate = reader.GetDateTime(6)
                        };
                        jobs.Add(job);
                    }
                }
            }
            return jobs;
        }

        public bool DeleteAll(int id)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spJob_DeleteByUserId", MSSQLConnectionString))
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