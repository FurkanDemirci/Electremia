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
        private Factory _factory;
        private AccountServices _accountServices;

        [TestInitialize]
        public void TestInitialize()
        {
            _factory = new Factory();
            _accountServices = _factory.AccountService();
        }

        [TestMethod]
        public void GetUser()
        {
            if (!CreateUser())
                Assert.Fail();

            var user = _accountServices.GetUser(2);
            Assert.AreEqual(user.UserId, 2);
        }

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
    }
}
