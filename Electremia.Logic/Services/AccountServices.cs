using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using Electremia.Model.ViewModels;

namespace Electremia.Logic.Services
{
    public class AccountServices
    {
        private readonly AccountRepository _repo;

        public AccountServices()
        {
            _repo = new AccountRepository(new AccountSqlContext());
        }

        public User Login(LoginViewModel model)
        {
            var user = _repo.GetByUsername(model.Username);
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
            return _repo.Add(user);
        }
    }
}
