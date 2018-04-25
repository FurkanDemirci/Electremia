using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PostServices
    {
        private readonly Repository<Post> _repo;

        public PostServices(string context)
        {
            switch (context)
            {
                case "MSSQL":
                    _repo = new Repository<Post>(new PostSqlContext());
                    break;
                default:
                    _repo = new Repository<Post>(new PostMemoryContext());
                    break;
            } 
        }

        // GetPost(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}