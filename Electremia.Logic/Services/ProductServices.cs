using Electremia.Dal.Repositories;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Logic.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _repo;

        public ProductServices(ProductRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Create product.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="title">Product title</param>
        /// <param name="description">Product description</param>
        /// <param name="price">Product price</param>
        /// <returns>Created productId int</returns>
        public int CreateProduct(int userId, string title, string description, decimal price)
        {
            // Check for empty values.
            if (title == null || description == null)
                throw new ExceptionHandler("NotImplemented", "Not all fields are implemented");

            var id = _repo.Add(new Product { UserId = userId, Title = title, Description = description, Price = price });
            if (id == -1)
                throw new ExceptionHandler("Database", "Could not upload to database");
            return id;
        }

        /// <summary>
        /// Get all products of your friends.
        /// </summary>
        /// <param name="friendsId">List of Friend UserId</param>
        /// <returns>List of products</returns>
        public List<Product> GetFriendsProducts(List<int> friendsId)
        {
            // Check for empty values.
            if (friendsId.Count == 0)
                throw new ExceptionHandler("Friends", "It seems like you have no friend's.");

            var allProducts = new List<Product>();
            foreach (var id in friendsId)
            {
                var products = _repo.GetAllByUserId(id);
                allProducts.AddRange(products);
            }

            // Sorts the product by new to old.
            allProducts.Sort((y, x) => DateTime.Compare(x.DateTime, y.DateTime));
            return allProducts;
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product model</returns>
        public Product GetById(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetById(id);
        }

        /// <summary>
        /// Delete product by id.
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Boolean</returns>
        public bool DeleteById(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.Delete(new Product { ProductId = id });
        }

        /// <summary>
        /// Get the count of products from user.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>value of products as int</returns>
        public int GetCountByUserId(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetCountByUserId(id);
        }
    }
}