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

        // GetFriends(id)
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

        // Add(model)

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
                ActionUserId = id1
            };

            return _repo.Add(relationship);
        }

        // Edit(model)
        public bool SetAccept(int id1, int id2, int type)
        {
            //TODO Nog niet klaar.
            Relationship relationship = new Relationship
            {

            };
            return _repo.Update(relationship);
        }
        // Delete(model)

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