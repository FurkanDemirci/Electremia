using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        new int Add(Product entity);
        List<Product> GetAllByUserId(int id);
        int GetCountByUserId(int id);
    }
}