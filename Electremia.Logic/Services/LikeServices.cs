using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class LikeServices
    {
        private readonly Repository<Like> _repo;

        public LikeServices(string context)
        {
            //switch (context)
            //{
            //    case "MSSQL":
            //        _repo = new Repository<Like>();
            //        break;
            //    default:
            //        _repo = new Repository<Like>();
            //        break;
            //}
        }

        // GetLikes(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}