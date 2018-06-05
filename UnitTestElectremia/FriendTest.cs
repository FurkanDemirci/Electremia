using Electremia.Logic;
using Electremia.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestElectremia
{
    [TestClass]
    public class FriendTest
    {
        private FriendServices _friendServices;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new Factory();
            _friendServices = factory.FriendService();
        }

        /// <summary>
        /// Adding friend.
        /// </summary>
        [TestMethod]
        public void AddFriendTest()
        {
            var added = _friendServices.AddFriend(1, 5);
            Assert.IsTrue(added);
        }

        /// <summary>
        /// Adding friend with 0 value.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void AddFriendExceptionTest()
        {
            var added = _friendServices.AddFriend(1, 0);
        }

        /// <summary>
        /// Deletes the selected relationship.
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            // Try's to delete the friend.
            _friendServices.Delete(1, 4);
            // Try's to get Friend.
            var friendsId = _friendServices.GetFriendsId(1);

            Assert.IsFalse(friendsId.Contains(4));
        }

        /// <summary>
        /// Get all pending.
        /// </summary>
        [TestMethod]
        public void GetPendingTest()
        {
            int userId = 1;
            var pending = _friendServices.GetPending(userId);

            Assert.AreEqual(pending.Count, 2);
        }

        /// <summary>
        /// Get all friends.
        /// </summary>
        [TestMethod]
        public void GetFriendsTest()
        {
            int userId = 1;
            var friends = _friendServices.GetAllFriends(userId);

            Assert.AreEqual(friends.Count, 1);
        }

        /// <summary>
        /// Get the sended requists.
        /// </summary>
        [TestMethod]
        public void GetSendedTest()
        {
            int userId = 1;
            var sended = _friendServices.GetSended(userId);

            Assert.AreEqual(sended.Count, 2);
        }

        /// <summary>
        /// Sets the pending relationship to accepted.
        /// </summary>
        [TestMethod]
        public void SetAccept()
        {
            // Sets the accept.
            _friendServices.SetAccept(1, 2);
            // Check if accepted.
            var friendsId = _friendServices.GetFriendsId(1);

            Assert.IsTrue(friendsId.Contains(2));
        }

        /// <summary>
        /// Checks if relationship exsits.
        /// </summary>
        [TestMethod]
        public void CheckRelationShip()
        {
            // Returns bool if exists.
            var isFriend = _friendServices.CheckRelationship(1, 3);
            Assert.IsTrue(isFriend);
        }
    }
}