using System;
using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestElectremia
{
    [TestClass]
    public class AccountTest
    {
        private AccountServices _accountServices;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new Factory();
            _accountServices = factory.AccountService();
        }

        /// <summary>
        /// Creates user and gets the user by id.
        /// </summary>
        [TestMethod]
        public void GetUserTest()
        {
            if (!CreateUser())
                Assert.Fail();

            var user = _accountServices.GetUser(5);
            Assert.AreEqual(user.UserId, 5);
        }

        /// <summary>
        /// Creating user method.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool CreateUser()
        {
            var user = new User
            {
                Username = "WillieWortel",
                Firstname = "Willie",
                Lastname = "Wortel",
                Password = "DuckCity1234",
                Certificate = "Duckschool engineer degree"
            };

            try
            {
                _accountServices.Register(user.Firstname, user.Lastname, user.Username, user.Password, user.Certificate);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// No capital letter in password.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void RegisterTest()
        {
            var user = new User
            {
                Username = "WillieWortel",
                Firstname = "Willie",
                Lastname = "Wortel",
                Password = "duckcity1234",
                Certificate = "Duckschool engineer degree"
            };
            _accountServices.Register(user.Firstname, user.Lastname, user.Username, user.Password, user.Certificate);
        }

        /// <summary>
        /// No capital letter in password.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void RegisterUsrTakenTest()
        {
            var user = new User
            {
                Username = "FurkanDemirci",
                Firstname = "Furkan",
                Lastname = "Demirci",
                Password = "Admin1234",
                Certificate = "Software engineer degree"
            };
            _accountServices.Register(user.Firstname, user.Lastname, user.Username, user.Password, user.Certificate);
        }

        /// <summary>
        /// Testing user login.
        /// </summary>
        [TestMethod]
        public void LoginTest()
        {
            const string username = "FurkanDemirci";
            const string password = "Admin123";

            var user = _accountServices.Login(username, password);
            Assert.AreEqual(user.UserId, 1);
        }

        /// <summary>
        /// Testing wrong password input.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void LoginWrongTest()
        {
            const string username = "FurkanDemirci";
            const string password = "Abcde1234";

            var user = _accountServices.Login(username, password);
        }

        /// <summary>
        /// Testing editable account.
        /// </summary>
        [TestMethod]
        public void EditAccountTest()
        {
            var user = new User
            {
                UserId = 1,
                Username = "FurkanDemirci",
                Firstname = "Furkan",
                Lastname = "Demirci",
                Password = "Admin1234",
                Certificate = "Software engineer degree"
            };
            var edited = _accountServices.Edit(user);
            Assert.IsTrue(edited);
        }

        /// <summary>
        /// Testing editable account.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void EditAccountWrongUserTest()
        {
            var user = new User
            {
                UserId = 0,
                Username = "FurkanDemirci",
                Firstname = "Furkan",
                Lastname = "Demirci",
                Password = "Admin1234",
                Certificate = "Software engineer degree"
            };
            _accountServices.Edit(user);
        }
    }
}
