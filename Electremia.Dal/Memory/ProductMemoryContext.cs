using Electremia.Dal.Interfaces;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Memory
{
    public class ProductMemoryContext : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductMemoryContext()
        {
            _products = new List<Product>();

            var product1 = new Product
            {
                ProductId = 1,
                UserId = 1,
                Title = "Another product",
                Description = "Some ugly description",
                Price = 260,
                Active = true,
            };

            var product2 = new Product
            {
                ProductId = 2,
                UserId = 2,
                Title = "Cool product",
                Description = "Very cool description",
                Price = 140,
                Active = true,
            };

            _products.Add(product1);
            _products.Add(product2);
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IProductRepository.Add(Product entity)
        {
            var id = 1;
            foreach (var product in _products)
            {
                if (id <= product.ProductId)
                    id = product.ProductId + 1;
            }
            entity.ProductId = id;

            _products.Add(entity);
            return entity.ProductId;
        }

        public List<Product> GetAllByUserId(int id)
        {
            var friendsProducts = new List<Product>();

            foreach (var product in _products)
            {
                if (product.UserId == id)
                    friendsProducts.Add(product);
            }
            return friendsProducts;
        }

        public int GetCountByUserId(int id)
        {
            var counter = 0;

            foreach (var product in _products)
            {
                if (product.UserId == id)
                    counter++;
            }

            return counter;
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
            foreach (var product in _products)
            {
                if (product.ProductId == entity.ProductId)
                    return _products.Remove(product);
            }
            return false;
        }
    }
}