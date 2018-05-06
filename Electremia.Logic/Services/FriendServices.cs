using System;
using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class FriendServices
    {
        private readonly RelationshipRepository _repo;

        public FriendServices(RelationshipRepository repo)
        {
            _repo = repo;
        }

        public bool CheckRelationship(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are implementend");

            var model = SetIdOrder(id1, id2);
            return _repo.CheckRelationship(model);
        }

        // GetFriends(id)
        public Dictionary<string, Relationship> GetAllFriends(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetFriends(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");
            return result;
        }

        public Dictionary<string, Relationship> GetPending(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetPending(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");
            return result;
        }

        public Dictionary<string, Relationship> GetSended(int id)
        {
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetSended(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");
            return result;
        }

        /// <summary>
        /// Add friend with status "Pending".
        /// </summary>
        /// <param name="id1">Your own id</param>
        /// <param name="id2">Friend id</param>
        /// <returns>Bool</returns>
        public bool AddFriend(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are implementend");

            var model = SetIdOrder(id1, id2);
            model.ActionUserId = id1;
            return _repo.Add(model);
        }

        // Edit(model)
        public void SetAccept(int id1, int id2)
        {
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are inserted");

            var model = SetIdOrder(id1, id2);
            model.Status = 1;

            if (!_repo.Update(model))
                throw new ExceptionHandler("Database", "Could not update the relationship");
        }

        // Delete(model)
        public void Delete(int id1, int id2)
        {
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are inserted");

            var model = SetIdOrder(id1, id2);

            if (!_repo.Delete(model))
                throw new ExceptionHandler("Database", "Could not delete the relationship");
        }

        private Relationship SetIdOrder(int id1, int id2)
        {
            int userIdOne;
            int userIdTwo;

            // Lowest number must be userIdOne.
            if (id1 < id2)
            {
                userIdOne = id1;
                userIdTwo = id2;
            }
            else
            {
                userIdOne = id2;
                userIdTwo = id1;
            }

            var relationship = new Relationship
            {
                UserID_one = userIdOne,
                UserID_two = userIdTwo,
            };

            return relationship;
        }
    }
}