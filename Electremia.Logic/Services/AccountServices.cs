using System;
using System.Linq;
using System.Reflection.Metadata;
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
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <returns>User</returns>
        public User Login(string username, string password)
        {
            // Checking for null values.
            if ((username == null) || (password == null))
                throw new ExceptionHandler("NotImplemented", "Not all fields are inserted");
            // Checking if user exists.
            var user = _repo.GetByLogin(username, password = PasswordHasher(password));
            if (user == null)
                throw new ExceptionHandler("User", "User not found");
            return user;
        }

        /// <summary>
        /// Creating new user.
        /// </summary>
        /// <param name="firstname">string firstname</param>
        /// <param name="lastname">string lastname</param>
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <param name="certificate">string certificate</param>
        public void Register(string firstname, string lastname, string username, string password, string certificate)
        {
            // Checking for null values.
            if ((firstname == null) || (lastname == null) || (username == null) || (password == null) || (certificate == null))
                throw new ExceptionHandler("NotImplemented", "Not all fields are inserted");
            
            // Creating User model.
            var model = new User
            {
                Firstname = firstname,
                Lastname = lastname,
                Username = username,
                Password = password,
                Certificate = certificate,
            };

            // Check if username exists.
            if (GetUser(model.Username) != null)
                throw new ExceptionHandler("Exist", "Username already exists");

            var count = 0;
            foreach (var c in model.Password)
            {
                if (char.IsDigit(c))
                {
                    count++;
                }
            }

            // Password validation.
            if (!model.Password.Any(char.IsUpper))
                throw new ExceptionHandler("Password", "Password must contain atleast one uppercase");
            if (count < 4)
                throw new ExceptionHandler("Password", "Password must contain atleast 4 numbers");

            // Password hashing.
            model.Password = PasswordHasher(model.Password);

            // Update to database.
            if (!_repo.Add(model))
                throw new ExceptionHandler("Database", "Couldn't add to the database");
        }

        /// <summary>
        /// Edit account and updates it again.
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>Bool</returns>
        public bool Edit(User model)
        {
            // Checking for null values.
            if (model == null)
                throw new ExceptionHandler("NotImplemented", "User model not implemented");
            var user = _repo.GetById(model.UserId);
            if (user == null)
                throw new ExceptionHandler("Database", "User not found");

            if (model.Password != null)
                model.Password = PasswordHasher(model.Password);
            if (model.ProfilePicture == null)
                model.ProfilePicture = user.ProfilePicture;
            if (model.CoverPicture == null)
                model.CoverPicture = user.CoverPicture;

            // Admin and Active values.
            model.Admin = user.Admin;
            model.Active = user.Active;

            model.Password = user.Password;
            return _repo.Update(model);
        }

        /// <summary>
        /// Get account by username.
        /// </summary>
        /// <param name="username">string username</param>
        /// <returns>User</returns>
        public User GetUser(string username)
        {
            // Checking for null values.
            if (username == null)
                throw new ExceptionHandler("NotImplemented", "Username not implemented");

            var user = _repo.GetByUsername(username);
            return user ?? null;
        }
        
        /// <summary>
        /// Get account by id.
        /// </summary>
        /// <param name="id">int userId</param>
        /// <returns>User</returns>
        public User GetUser(int id)
        {
            // Checking for null values.
            if (id == 0)
                throw new ExceptionHandler("NotImplemented", "Id not implemented");

            var user = _repo.GetById(id);
            return user ?? null;
        }

        /// <summary>
        /// Get the user with jobs and schools.
        /// </summary>
        /// <param name="id">int userId</param>
        /// <returns>User filled with jobs and schools</returns>
        public User GetFullUser(int id)
        {
            // Checking for null values.
            if (id == 0)
                throw new ExceptionHandler("NotImplemented", "Id not implemented");

            return _repo.GetFullUser(id);
        }

        /// <summary>
        /// Password hasher without the use of salt.
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>string hashed password</returns>
        private string PasswordHasher(string password)
        {
            var passwordData = Encoding.UTF8.GetBytes(password);
            var sha = new SHA256Managed();
            var hashed = sha.ComputeHash(passwordData);
            return Convert.ToBase64String(hashed);
        }
    }
}