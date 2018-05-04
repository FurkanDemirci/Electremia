using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class RelationshipSqlContext : Connection, IRelationshipRepository
    {
        public Relationship GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Relationship entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_Add", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID_one", SqlDbType.Int).Value = entity.UserID_one;
                command.Parameters.AddWithValue("@UserID_two", SqlDbType.Int).Value = entity.UserID_two;
                command.Parameters.AddWithValue("@Action_userId", SqlDbType.Int).Value = entity.ActionUserId;

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

        public bool Update(Relationship entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_UpdateById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id1", SqlDbType.Int).Value = entity.UserID_one;
                command.Parameters.AddWithValue("@Id2", SqlDbType.Int).Value = entity.UserID_two;
                command.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = entity.Status;

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

        public bool Delete(Relationship entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_DeleteById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id1", SqlDbType.Int).Value = entity.UserID_one;
                command.Parameters.AddWithValue("@Id2", SqlDbType.Int).Value = entity.UserID_two;

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

        public Dictionary<string, Relationship> GetPending(int id)
        {
            var relationshipsUsr = new Dictionary<string, Relationship>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_GetPendingById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var relationship = new Relationship
                        {
                            UserID_one = reader.GetInt32(0),
                            UserID_two = reader.GetInt32(1),
                            Status = reader.GetInt32(2),
                            ActionUserId = reader.GetInt32(3)
                        };
                        var username = reader.GetString(4);
                        relationshipsUsr.Add(username, relationship);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return relationshipsUsr;
        }

        public Dictionary<string, Relationship> GetSended(int id)
        {
            var relationshipsUsr = new Dictionary<string, Relationship>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_GetSendedById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var relationship = new Relationship
                        {
                            UserID_one = reader.GetInt32(0),
                            UserID_two = reader.GetInt32(1),
                            Status = reader.GetInt32(2),
                            ActionUserId = reader.GetInt32(3)
                        };
                        var username = reader.GetString(4);
                        relationshipsUsr.Add(username, relationship);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return relationshipsUsr;
        }

        public Dictionary<string, Relationship> GetFriends(int id)
        {
            var relationshipsUsr = new Dictionary<string, Relationship>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spRelationship_GetFriendsById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var relationship = new Relationship
                        {
                            UserID_one = reader.GetInt32(0),
                            UserID_two = reader.GetInt32(1),
                            Status = reader.GetInt32(2),
                            ActionUserId = reader.GetInt32(3)
                        };
                        var username = reader.GetString(4);
                        relationshipsUsr.Add(username, relationship);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return relationshipsUsr;
        }
    }
}