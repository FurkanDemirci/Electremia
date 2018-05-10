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
        // GetProduct(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}