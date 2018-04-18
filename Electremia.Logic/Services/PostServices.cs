using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PostServices
    {
        private readonly Repository<Post> _repo;

        public PostServices()
        {
            _repo = new Repository<Post>(new PostSqlContext());   
        }

        // GetPost(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}