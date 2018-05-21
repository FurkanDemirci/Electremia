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

        /// <summary>
        /// Get all likes form the content.
        /// </summary>
        /// <param name="id">Content Id</param>
        /// <param name="type">Content type</param>
        /// <returns>List of int's (UserId)</returns>
        public List<int> GetAll(int id, int type)
        {
            // Check for empty values.
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.GetAll(id, type);
        }

        /// <summary>
        /// Add like to content.
        /// </summary>
        /// <param name="id">Content Id</param>
        /// <param name="userId">UserId</param>
        /// <param name="type">Content Type</param>
        /// <returns>Boolean</returns>
        public bool Add(int id, int userId, int type)
        {
            // Check for empty values.
            if ((id <= 0) && (userId <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.Add(new Like {Id = id, UserId = userId, Type = type});
        }

        /// <summary>
        /// Delete Like from content.
        /// </summary>
        /// <param name="id">Content Id</param>
        /// <param name="userId">UserId</param>
        /// <param name="type">Content Type</param>
        /// <returns>Boolean</returns>
        public bool Delete(int id, int userId, int type)
        {
            // Check for empty values.
            if ((id <= 0) && (userId <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.Delete(new Like {Id = id, UserId = userId, Type = type});
        }
    }
}