using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class PostSqlContext : Connection, IPostRepository
    {
        public Post GetById(int id)
        {
            var post = new Post();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPost_GetById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        post = new Post
                        {
                            PostId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            DateTime = reader.GetDateTime(4),
                            Active = reader.GetBoolean(5)
                        };
                    }
                }
            }
            MSSQLConnectionString.Close();
            return post;
        }

        int IPostRepository.Add(Post entity)
        {
            var postId = -1;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPost_Add", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.UserId;
                command.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = entity.Title;
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = entity.Description;

                try
                {
                    postId = Convert.ToInt32(command.ExecuteScalar());
                    MSSQLConnectionString.Close();
                }
                catch
                {
                    MSSQLConnectionString.Close();
                }
            }
            return postId;
        }

        public List<Post> GetAllByUserId(int id)
        {
            var posts = new List<Post>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPost_GetAllByUserId", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var post = new Post
                        {
                            PostId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            DateTime = reader.GetDateTime(4),
                            Active = reader.GetBoolean(5)
                        };
                        post.Pictures.Add(new Picture { Url = reader.GetString(6)});
                        posts.Add(post);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return posts;
        }

        public int GetCountByUserId(int id)
        {
            var count = 0;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPost_GetCountByUserId", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return count;
        }

        public bool Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Post entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPost_DeleteById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.PostId;

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
