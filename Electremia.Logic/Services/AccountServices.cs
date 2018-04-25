﻿using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using Microsoft.Extensions.Configuration;

namespace Electremia.Logic.Services
{
    public class AccountServices
    {
        private readonly AccountRepository _repo;

        public AccountServices(string context)
        {
            switch (context)
            {
                case "MSSQL":
                    _repo = new AccountRepository(new AccountSqlContext());
                    break;
                default:
                    _repo = new AccountRepository(new AccountMemoryContext());
                    break;
            }
        }

        public User Login(User model)
        {
            var user = _repo.GetByUsername(model.Username);
            if (user == null)
            {
                return null;
            }
            return user.Password != model.Password ? null : user;
        }

        public bool Register(User model)
        {
            return _repo.Add(model);
        }

        public bool Edit(User model)
        {
            var user = _repo.GetById(model.UserId);
            if (model.Password == null)
            {
                model.Password = user.Password;
            }
            return _repo.Update(model);
        }

        public User GetAccount(string username)
        {
            var user = _repo.GetByUsername(username);
            return user ?? null;
        }

        public User GetAccount(int id)
        {
            var user = _repo.GetById(id);
            return user ?? null;
        }
    }
}