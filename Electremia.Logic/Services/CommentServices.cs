using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class CommentServices
    {
        private readonly CommentRepository _repo;

        public CommentServices(CommentRepository repo)
        {
            _repo = repo;
        }

        public List<Comment> GetAll(int id, int type)
        {
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.GetAll(id, type);
        }

        // GetComments(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}