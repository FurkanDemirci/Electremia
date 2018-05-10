﻿using System;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
