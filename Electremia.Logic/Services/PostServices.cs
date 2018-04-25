using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PostServices
    {
        private readonly Repository<Post> _repo;

        public PostServices(Repository<Post> repo)
        {
            _repo = repo;
        }

        // GetPost(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}