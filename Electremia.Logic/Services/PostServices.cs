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

        /// <summary>
        /// Create a post.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="title">Post title</param>
        /// <param name="description">Post description</param>
        /// <returns>Created PostId int</returns>
        public int CreatePost(int userId, string title, string description)
        {
            // Check for empty values.
            if (title == null || description == null)
                throw new ExceptionHandler("NotImplemented", "Not all fields are implemented");

            var id =_repo.Add(new Post { UserId = userId, Title = title, Description = description });
            if (id == -1)
                throw new ExceptionHandler("Database", "Could not upload to database");
            return id;
        }

        /// <summary>
        /// Get all posts of your friends.
        /// </summary>
        /// <param name="friendsId">List of Friend UserId</param>
        /// <returns>List of Posts</returns>
        public List<Post> GetFriendsPosts(List<int> friendsId)
        {
            // Check for empty values.
            if (friendsId.Count == 0)
                throw new ExceptionHandler("Friends", "It seems like you have no friend's.");

            var allPosts = new List<Post>();
            foreach (var id in friendsId)
            {
                var posts = _repo.GetAllByUserId(id);
                allPosts.AddRange(posts);
            }

            // Sorts the post by new to old.
            allPosts.Sort((y, x) => DateTime.Compare(x.DateTime, y.DateTime));
            return allPosts;
        }

        /// <summary>
        /// Get post by id.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post model</returns>
        public Post GetById(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetById(id);
        }

        /// <summary>
        /// Delete post by id.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Boolean</returns>
        public bool DeleteById(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.Delete(new Post {PostId = id});
        }

        /// <summary>
        /// Get the count of posts from user.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>value of posts as int</returns>
        public int GetCountByUserId(int id)
        {
            // Check for empty values.
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Id parameter not given");

            return _repo.GetCountByUserId(id);
        }
    }
}