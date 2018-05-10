using System;
using System.Data;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class PictureSqlContext : Connection, IRepository<Picture>
    {
        public Picture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Picture entity)
        {
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPicture_Add", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.Id;
                command.Parameters.AddWithValue("@Url", SqlDbType.VarChar).Value = entity.Url;
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

        public bool Update(Picture entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Picture entity)
        {
            throw new NotImplementedException();
        }
    }
}