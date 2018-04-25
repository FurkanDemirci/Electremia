using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class ProductServices
    {
        private readonly Repository<Product> _repo;

        public ProductServices(string context)
        {
            //switch (context)
            //{
            //    case "MSSQL":
            //        _repo = new Repository<Product>();
            //        break;
            //    default:
            //        _repo = new Repository<Product>();
            //        break;
            //}
        }

        // GetProduct(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}