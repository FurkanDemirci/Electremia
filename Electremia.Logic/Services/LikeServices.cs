using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class LikeServices
    {
        private readonly LikeRepository _repo;

        public LikeServices(LikeRepository repo)
        {
            _repo = repo;
        }

        public List<int> GetAll(int id, int type)
        {
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.GetAll(id, type);
        }

        public bool Add(int id, int userId, int type)
        {
            if ((id <= 0) && (userId <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.Add(new Like {Id = id, UserId = userId, Type = type});
        }
        // GetLikes(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}