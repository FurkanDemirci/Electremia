using System;
using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _repo;

        public ProductServices(ProductRepository repo)
        {
            _repo = repo;
        }

        public int CreateProduct(int userId, string title, string description, decimal price)
        {
            if (title == null || description == null)
                throw new ExceptionHandler("NotImplemented", "Not all fields are implemented");

            var id = _repo.Add(new Product { UserId = userId, Title = title, Description = description, Price = price });
            if (id == -1)
                throw new ExceptionHandler("Database", "Could not upload to database");
            return id;
        }

        public List<Product> GetFriendsProducts(List<int> friendsId)
        {
            if (friendsId.Count == 0)
                throw new ExceptionHandler("Friends", "It seems like you have no friend's.");

            var allProducts = new List<Product>();
            foreach (var id in friendsId)
            {
                var products = _repo.GetAllByUserId(id);
                allProducts.AddRange(products);
            }

            allProducts.Sort((y, x) => DateTime.Compare(x.DateTime, y.DateTime));
            return allProducts;
        }

        public Product GetById(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetById(id);
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.Delete(new Product { ProductId = id });
        }

        public int GetCountByUserId(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetCountByUserId(id);
        }
        // GetProduct(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}