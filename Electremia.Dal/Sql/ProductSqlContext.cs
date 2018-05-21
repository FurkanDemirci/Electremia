﻿using System;
using System.Collections.Generic;
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
            var product = new Product();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spProduct_GetById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            Price = reader.GetDecimal(4),
                            DateTime = reader.GetDateTime(5),
                            Active = reader.GetBoolean(6)
                        };
                    }
                }
            }
            MSSQLConnectionString.Close();
            return product;
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

        public List<Product> GetAllByUserId(int id)
        {
            var products = new List<Product>();
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spProduct_GetAllByUserId", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            Price = reader.GetDecimal(4),
                            DateTime = reader.GetDateTime(5),
                            Active = reader.GetBoolean(6)
                        };
                        product.Pictures.Add(new Picture { Url = reader.GetString(7) });
                        products.Add(product);
                    }
                }
            }
            MSSQLConnectionString.Close();
            return products;
        }

        public int GetCountByUserId(int id)
        {
            var count = 0;
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spProduct_GetCountByUserId", MSSQLConnectionString))
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
            MSSQLConnectionString.Open();
            using (var command = new SqlCommand("dbo.spProduct_DeleteById", MSSQLConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = entity.ProductId;

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