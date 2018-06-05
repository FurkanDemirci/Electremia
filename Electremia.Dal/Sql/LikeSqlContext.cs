using Electremia.Dal.Interfaces;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Electremia.Dal.Sql
{
    public class LikeSqlContext : Connection, ILikeRepository
    {
        public Like GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Like entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spLike_Add", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.Id;
                command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = entity.UserId;
                command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = entity.Type;

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

        public bool Update(Like entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Like entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spLike_DeleteByIdAndType", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.Id;
                command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = entity.UserId;
                command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = entity.Type;

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

        public List<int> GetAll(int id, int type)
        {
            var likes = new List<int>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spLike_GetAllByIdAndType", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = type;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var like = new Like
                        {
                            LikeId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Id = reader.GetInt32(2),
                            Type = reader.GetInt32(3),
                        };
                        likes.Add(like.UserId);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return likes;
        }
    }
}