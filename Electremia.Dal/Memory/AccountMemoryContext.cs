using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class AccountMemoryContext : IAccountRepository
    {
        private readonly List<User> _users;

        public AccountMemoryContext()
        {
            _users = new List<User>();
            var user1 = new User
            {
                UserId = 1,
                Firstname = "Furkan",
                Lastname = "Demirci",
                Username = "FurkanDemirci",
                Password = "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=",
                ProfilePicture = "Blank-profile.png",
                CoverPicture = "Blank-cover.png",
                Certificate = "Software engineer",
                Active = true,
                Admin = true,
            };

            var user2 = new User
            {
                UserId = 2,
                Firstname = "Emirhan",
                Lastname = "Demirci",
                Username = "EmirhanDemirci",
                Password = "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=",
                ProfilePicture = "Blank-profile.png",
                CoverPicture = "Blank-cover.png",
                Certificate = "MBO applicatieontwikkelaar",
                Active = true,
                Admin = true,
            };

            var user3 = new User
            {
                UserId = 3,
                Firstname = "Asuman",
                Lastname = "Demirci",
                Username = "AsumanDemirci",
                Password = "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=",
                ProfilePicture = "Blank-profile.png",
                CoverPicture = "Blank-cover.png",
                Certificate = "HBO ",
                Active = true,
                Admin = true,
            };

            var user4 = new User
            {
                UserId = 4,
                Firstname = "IhsanDemirci",
                Lastname = "Demirci",
                Username = "IhsanDemirci",
                Password = "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=",
                ProfilePicture = "Blank-profile.png",
                CoverPicture = "Blank-cover.png",
                Certificate = "HBO ",
                Active = true,
                Admin = true,
            };

            _users.Add(user1);
            _users.Add(user2);
            _users.Add(user3);
            _users.Add(user4);
        }

        public User GetById(int id)
        {
            foreach (var user in _users)
            {
                if (id == user.UserId)
                    return user;
            }
            return null;
        }

        public bool Add(User entity)
        {
            entity.Active = true;
            entity.Admin = false;
            entity.ProfilePicture = "Blank-profile.png";
            entity.CoverPicture = "Blank-cover.png";

            var id = 1;
            foreach (var user in _users)
            {
                if (id <= user.UserId)
                    id = user.UserId + 1;
            }

            entity.UserId = id;
            _users.Add(entity);
            return true;
        }

        public bool Update(User entity)
        {
            foreach (var user in _users)
            {
                if (entity.UserId != user.UserId) continue;
                user.Firstname = entity.Firstname;
                user.Lastname = entity.Lastname;
                user.Username = entity.Username;
                user.Password = entity.Password;
                user.ProfilePicture = entity.ProfilePicture;
                user.CoverPicture = entity.CoverPicture;
                user.Certificate = entity.Certificate;
                user.Active = entity.Active;
                user.Admin = entity.Admin;
                return true;
            }
            return false;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            foreach (var user in _users)
            {
                if (username == user.Username)
                    return user;
            }
            return null;
        }

        public User GetByLogin(string username, string password)
        {
            foreach (var user in _users)
            {
                if ((username == user.Username) && (password == user.Password))
                    return user;
            }
            return null;
        }

        public User GetFullUser(int id)
        {
            var jobs = new List<Job>();
            var schools = new List<School>();

            var job = new Job
            {
                JobId = 1,
                UserId = 1,
                Name = "Dominos",
                Position = "Driver",
                Description = "I diliver pizzas",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Active = true
            };
            jobs.Add(job);

            var school = new School
            {
                SchoolId = 1,
                UserId = 1,
                Name = "ROC ter AA",
                Years = 3,
                AttendedFor = "Applicatieontwikkelaar"
            };
            schools.Add(school);

            foreach (var user in _users)
            {
                if (user.UserId != id) continue;
                user.Jobs = jobs;
                user.Schools = schools;
                return user;
            }

            return null;
        }
    }
}
