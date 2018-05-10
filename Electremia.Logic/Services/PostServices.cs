using System.Collections.Generic;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PostServices
    {
        private readonly PostRepository _repo;

        public PostServices(PostRepository repo)
        {
            _repo = repo;
        }

        public int CreatePost(int userId, string title, string description)
        {
            if (title == null || description == null)
                throw new ExceptionHandler("NotImplemented", "Not all fields are implemented");

            var id =_repo.Add(new Post { UserId = userId, Title = title, Description = description });
            if (id == -1)
                throw new ExceptionHandler("Database", "Could not upload to database");
            return id;
        }
        // GetPost(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}