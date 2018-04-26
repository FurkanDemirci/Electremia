using System;
using System.Security.Cryptography;
using System.Text;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using Microsoft.AspNetCore.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Electremia.Logic.Services
{
    public class AccountServices
    {
        private readonly AccountRepository _repo;

        public AccountServices(AccountRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Login method to gain access to the website. 
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>User</returns>
        public User Login(User model)
        {
            //TODO password hashen en controleren of alles goed is ingevuld.
            return _repo.GetByLogin(model.Username, model.Password = PasswordHasher(model.Password));
        }

        /// <summary>
        /// Register method to add an account.
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>Bool</returns>
        public bool Register(User model)
        {
            //TODO Password hashen en controleren of de username niet bestaat.
            model.Password = PasswordHasher(model.Password);
            return _repo.Add(model);
        }

        /// <summary>
        /// Edit account and updates it again.
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>Bool</returns>
        public bool Edit(User model)
        {
            var user = _repo.GetById(model.UserId);
            if (model.Password == null)
            {
                model.Password = user.Password;
            }
            return _repo.Update(model);
        }

        /// <summary>
        /// Get account by username.
        /// </summary>
        /// <param name="username">string username</param>
        /// <returns>User</returns>
        public User GetAccount(string username)
        {
            var user = _repo.GetByUsername(username);
            return user ?? null;
        }
        
        /// <summary>
        /// Get account by id.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>User</returns>
        public User GetAccount(int id)
        {
            var user = _repo.GetById(id);
            return user ?? null;
        }

        /// <summary>
        /// Password hasher without the use of salt.
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>string hashed password</returns>
        private string PasswordHasher(string password)
        {
            byte[] passwordData = Encoding.UTF8.GetBytes(password);
            SHA256Managed sha = new SHA256Managed();
            var hashed = sha.ComputeHash(passwordData);
            return Convert.ToBase64String(hashed);
        }
    }
}