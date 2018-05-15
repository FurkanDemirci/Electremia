using System;
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

        public List<Post> GetFriendsPosts(List<int> friendsId)
        {
            if (friendsId.Count == 0)
                throw new ExceptionHandler("Friends", "It seems like you have no friend's.");

            var allPosts = new List<Post>();
            foreach (var id in friendsId)
            {
                var posts = _repo.GetAllByUserId(id);
                allPosts.AddRange(posts);
            }

            allPosts.Sort((y, x) => DateTime.Compare(x.DateTime, y.DateTime));
            return allPosts;
        }

        // GetPost(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}