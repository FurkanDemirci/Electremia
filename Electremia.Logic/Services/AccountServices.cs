using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using Electremia.Model.ViewModels;

namespace Electremia.Logic.Services
{
    public class AccountServices
    {
        private AccountSqlRepository repo;

        public AccountServices()
        {
            repo = new AccountSqlRepository();
        }

        public User Login(LoginViewModel model)
        {
            var user = repo.GetByUsername(model.Username);

            if (user == null)
            {
                return null;
            }

            return user.Password != model.Password ? null : user;
        }

        public bool Register(RegisterViewModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname
            };
            return repo.Add(user);
        }
    }
}
