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

        /// <summary>
        /// Get's all comments from the content
        /// </summary>
        /// <param name="id">Id of content</param>
        /// <param name="type">Type of content</param>
        /// <returns>List of comments</returns>
        public List<Comment> GetAll(int id, int type)
        {
            // Checking for null values.
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            var comments = _repo.GetAll(id, type);
            comments.Reverse();
            return comments;
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="id">Id of the content</param>
        /// <param name="userId">UserId of the logged in user</param>
        /// <param name="type">Type of content</param>
        /// <param name="text">Comment itself</param>
        /// <returns>Boolean</returns>
        public bool Add(int id, int userId, int type, string text)
        {
            // Checking for null values.
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