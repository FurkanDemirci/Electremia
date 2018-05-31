using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class PostMemoryContext : IPostRepository
    {
        private readonly List<Post> _posts;

        public PostMemoryContext()
        {
            _posts = new List<Post>();

            var post1 = new Post
            {
                PostId = 1,
                UserId = 1,
                Title = "Another post",
                Description = "Some ugly description",
                Active = true,
            };

            var post2 = new Post
            {
                PostId = 2,
                UserId = 2,
                Title = "Cool post",
                Description = "Very cool description",
                Active = true,
            };

            _posts.Add(post1);
            _posts.Add(post2);
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IPostRepository.Add(Post entity)
        {
            var id = 1;
            foreach (var post in _posts)
            {
                if (id <= post.PostId)
                    id = post.PostId + 1;
            }
            entity.PostId = id;

            _posts.Add(entity);
            return entity.PostId;
        }

        public List<Post> GetAllByUserId(int id)
        {
            var friendsPosts = new List<Post>();

            foreach (var post in _posts)
            {
                if (post.UserId == id)
                    friendsPosts.Add(post);
            }
            return friendsPosts;
        }

        public int GetCountByUserId(int id)
        {
            var counter = 0;

            foreach (var post in _posts)
            {
                if (post.UserId == id)
                    counter++;
            }

            return counter;
        }

        public bool Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Post entity)
        {
            foreach (var post in _posts)
            {
                if (post.PostId == entity.PostId)
                    return _posts.Remove(post);
            }
            return false;
        }
    }
}
