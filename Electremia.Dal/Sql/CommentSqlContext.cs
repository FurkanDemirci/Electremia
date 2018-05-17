using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class CommentSqlContext : Connection, ICommentRepository
    {
        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(int id, int type)
        {
            var comments = new List<Comment>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spComment_GetAllByIdAndType", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = type;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = new Comment
                        {
                            CommentId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Id = reader.GetInt32(2),
                            Type = reader.GetInt32(3),
                            Text = reader.GetString(4)
                        };
                        comments.Add(comment);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return comments;
        }
    }
}