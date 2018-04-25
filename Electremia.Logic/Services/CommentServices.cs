using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class CommentServices
    {
        private readonly Repository<Comment> _repo;

        public CommentServices(string context)
        {
            //switch (context)
            //{
            //    case "MSSQL":
            //        _repo = new Repository<Comment>();
            //        break;
            //    default:
            //        _repo = new Repository<Comment>();
            //        break;
            //}
        }

        // GetComments(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}