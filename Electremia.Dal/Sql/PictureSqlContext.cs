using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class PictureSqlContext : Connection, IPictureRepository
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

        public List<Picture> GetAll(int id, int type)
        {
            var pictures = new List<Picture>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spPicture_GetAllByIdAndType", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = type;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var picture = new Picture
                        {
                            PictureId = reader.GetInt32(0),
                            Id = reader.GetInt32(1),
                            Type = reader.GetInt32(2),
                            Url = reader.GetString(3)
                        };
                        pictures.Add(picture);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return pictures;
        }
    }
}