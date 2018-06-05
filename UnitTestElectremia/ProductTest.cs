using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestElectremia
{
    [TestClass]
    public class ProductTest
    {
        private ProductServices _productServices;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new Factory();
            _productServices = factory.ProductService();
        }

        /// <summary>
        /// Creating a post.
        /// </summary>
        [TestMethod]
        public void CreateProductTest()
        {
            var product = new Product
            {
                ProductId = 3,
                UserId = 1,
                Title = "Beautiful Title",
                Description = "A very long description",
                Price = 130
            };
            var added = _productServices.CreateProduct(product.UserId, product.Title, product.Description, product.Price);
            Assert.AreEqual(added, product.ProductId);
        }

        /// <summary>
        /// Creating post without the needed requirements.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreateProductFailTest()
        {
            var product = new Product
            {
                ProductId = 3,
                UserId = 1,
                Description = "A very long description",
            };
            _productServices.CreateProduct(product.UserId, product.Title, product.Description, product.Price);
        }

        /// <summary>
        /// Deleting post by id.
        /// </summary>
        [TestMethod]
        public void DeleteByIdTest()
        {
            // Gets deleted.
            var deleted = _productServices.DeleteById(2);
            Assert.IsTrue(deleted);
        }

        /// <summary>
        /// Getting all posts from user and friends.
        /// </summary>
        [TestMethod]
        public void GetFriendsProductsTest()
        {
            // Own userId and friends id
            var friendsId = new List<int> { 1, 2 };

            var posts = _productServices.GetFriendsProducts(friendsId);
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
            var count = _productServices.GetCountByUserId(userId);

            Assert.AreEqual(count, 1);
        }
    }
}