using System.Collections.Generic;
using System.Linq;
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


            var comments = _repo.GetAll(id, type);
            comments.Reverse();
            return comments;
        }

        public bool Add(int id, int userId, int type, string text)
        {
            if ((id <= 0) && (userId <= 0) && (type < 0) && (text == null))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.Add(new Comment { Id = id, UserId = userId, Type = type, Text = text});
        }

        // GetComments(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}