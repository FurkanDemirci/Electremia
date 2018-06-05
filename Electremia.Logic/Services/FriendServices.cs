using Electremia.Dal.Repositories;
using Electremia.Model.Models;
using System.Collections.Generic;

namespace Electremia.Logic.Services
{
    public class FriendServices
    {
        private readonly RelationshipRepository _repo;

        public FriendServices(RelationshipRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets all the userId's of friends.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>List of userId's from friends</returns>
        public List<int> GetFriendsId(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetFriends(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");

            var userId = new List<int>();
            foreach (var resultValue in result.Values)
            {
                // Filtering own userId from the friend.
                userId.Add(resultValue.UserID_one == id ? resultValue.UserID_two : resultValue.UserID_one);
            }

            return userId;
        }

        /// <summary>
        /// Checks for relationship connection.
        /// </summary>
        /// <param name="id1">UserId int</param>
        /// <param name="id2">Friend UserId int</param>
        /// <returns>Boolean</returns>
        public bool CheckRelationship(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are implementend");

            // Using SetIdOrder.
            var model = SetIdOrder(id1, id2);
            return _repo.CheckRelationship(model);
        }

        /// <summary>
        /// Get all friend of user.
        /// </summary>
        /// <param name="id">UserId int</param>
        /// <returns>Dictionary with the values (Relationship) and username attached as key (string)</returns>
        public Dictionary<string, Relationship> GetAllFriends(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetFriends(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");
            return result;
        }

        /// <summary>
        /// Get all pending of user.
        /// </summary>
        /// <param name="id">UserId int</param>
        /// <returns>Dictionary with the values (Relationship) and username attached as key (string)</returns>
        public Dictionary<string, Relationship> GetPending(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id is not implemented");
            var result = _repo.GetPending(id);
            if (result.Count == 0)
                throw new ExceptionHandler("Result", "No results found");
            return result;
        }

        /// <summary>
        /// Get all sended of user.
        /// </summary>
        /// <param name="id">UserId int</param>
        /// <returns>Dictionary with the values (Relationship) and username attached as key (string)</returns>
        public Dictionary<string, Relationship> GetSended(int id)
        {
            // Check for empty values.
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
        /// <param name="id1">UserId int</param>
        /// <param name="id2">Friend UserId</param>
        /// <returns>Boolean</returns>
        public bool AddFriend(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are implementend");

            // Using SetIdOrder.
            var model = SetIdOrder(id1, id2);
            model.ActionUserId = id1;
            return _repo.Add(model);
        }

        /// <summary>
        /// Setting the relationship to accept.
        /// </summary>
        /// <param name="id1">UserId int</param>
        /// <param name="id2">Friend UserId</param>
        public void SetAccept(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are inserted");

            // Using SetIdOrder
            var model = SetIdOrder(id1, id2);
            model.Status = 1;

            if (!_repo.Update(model))
                throw new ExceptionHandler("Database", "Could not update the relationship");
        }

        /// <summary>
        /// Deleting the relationship.
        /// </summary>
        /// <param name="id1">UserId int</param>
        /// <param name="id2">Friend UserId</param>
        public void Delete(int id1, int id2)
        {
            // Check for empty values.
            if ((id1 <= 0) || (id2 <= 0))
                throw new ExceptionHandler("NotImplemented", "Not all values are inserted");

            // Using SetIdOrder
            var model = SetIdOrder(id1, id2);

            if (!_repo.Delete(model))
                throw new ExceptionHandler("Database", "Could not delete the relationship");
        }

        /// <summary>
        /// Sets the order of the Id from small (userIdOne) to large (userIdTwo).
        /// </summary>
        /// <param name="id1">UserId int</param>
        /// <param name="id2">Friends UserId</param>
        /// <returns>Relationship in right order.</returns>
        private Relationship SetIdOrder(int id1, int id2)
        {
            int userIdOne;
            int userIdTwo;

            // Setting the lowest number to userIdOne.
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