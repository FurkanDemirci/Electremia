using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class FriendServices
    {
        private readonly Repository<Relationship> _repo;

        public FriendServices(string context)
        {
            //switch (context)
            //{
            //    case "MSSQL":
            //        _repo = new Repository<Relationship>();
            //        break;
            //    default:
            //        _repo = new Repository<Relationship>();
            //        break;
            //}
        }

        // GetFriends(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}