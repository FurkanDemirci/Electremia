using System.Collections.Generic;
using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestElectremia
{
    [TestClass]
    public class PostTest
    {
        private PostServices _postServices;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new Factory();
            _postServices = factory.PostService();
        }

        /// <summary>
        /// Creating a post.
        /// </summary>
        [TestMethod]
        public void CreatePostTest()
        {
            var post = new Post
            {
                PostId = 3,
                UserId = 1,
                Title = "Beautiful Title",
                Description = "A very long description",
            };
            var added = _postServices.CreatePost(post.UserId, post.Title, post.Description);
            Assert.AreEqual(added, post.PostId);
        }

        /// <summary>
        /// Creating post without the needed requirements.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreatePostFailTest()
        {
            var post = new Post
            {
                PostId = 3,
                UserId = 1,
                Description = "A very long description",
            };
            _postServices.CreatePost(post.UserId, post.Title, post.Description);
        }

        /// <summary>
        /// Deleting post by id.
        /// </summary>
        [TestMethod]
        public void DeleteByIdTest()
        {
            // Gets deleted.
            var deleted = _postServices.DeleteById(2);
            Assert.IsTrue(deleted);
        }

        /// <summary>
        /// Getting all posts from user and friends.
        /// </summary>
        [TestMethod]
        public void GetFriendsPostsTest()
        {
            // Own userId and friends id
            var friendsId = new List<int> {1, 2};

            var posts = _postServices.GetFriendsPosts(friendsId);
            Assert.AreEqual(posts.Count, 2);
        }

        /// <summary>
        /// Counts all post of the user.
        /// </summary>
        [TestMethod]
        public void GetCountByUserIdTest()
        {
            var userId = 1;
            // Counts the post of user.
            var count = _postServices.GetCountByUserId(userId);

            Assert.AreEqual(count, 1);
        }
    }
}