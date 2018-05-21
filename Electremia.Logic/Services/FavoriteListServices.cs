using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class FavoriteListServices
    {
        private readonly Repository<FavoriteList> _repo;

        public FavoriteListServices(Repository<FavoriteList> repo)
        {
            _repo = repo;
        }

        // GetList(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}