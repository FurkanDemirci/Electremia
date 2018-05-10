using System;
using System.Data;
using System.Data.SqlClient;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class ProductSqlContext : Connection, IProductRepository
    {
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IProductRepository.Add(Product entity)
        {
            var productId = -1;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spProduct_Add", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.UserId;
                command.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = entity.Title;
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = entity.Description;
                command.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = entity.Price;

                try
                {
                    productId = Convert.ToInt32(command.ExecuteScalar());
                    MSSQLConnectionString.Close();
                }
                catch
                {
                    MSSQLConnectionString.Close();
                }
            }
            return productId;
        }

        public bool Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}