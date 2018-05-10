using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        new int Add(Product entity);
    }
}