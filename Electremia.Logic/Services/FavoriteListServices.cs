using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class FavoriteListServices
    {
        private readonly Repository<FavoriteList> _repo;

        public FavoriteListServices(string context)
        {
            //switch (context)
            //{
            //    case "MSSQL":
            //        _repo = new Repository<FavoriteList>();
            //        break;
            //    default:
            //        _repo = new Repository<FavoriteList>();
            //        break;
            //}
        }

        // GetList(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}