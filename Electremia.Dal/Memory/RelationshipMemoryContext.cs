using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class RelationshipMemoryContext : IRelationshipRepository
    {
        public Relationship GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Relationship> GetPending(int id)
        {
            var relationship1 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 2,
                Status = 0,
                ActionUserId = 2
            };
            var username1 = "EmirhanDemirci";
            var relationship2 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 3,
                Status = 0,
                ActionUserId = 3
            };
            var username2 = "IhsanDemirci";

            var relationshipsUsr = new Dictionary<string, Relationship>();
            relationshipsUsr.Add(username1, relationship1);
            relationshipsUsr.Add(username2, relationship2);
            return relationshipsUsr;
        }

        public Dictionary<string, Relationship> GetSended(int id)
        {
            var relationship1 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 2,
                Status = 0,
                ActionUserId = 1
            };
            var username1 = "EmirhanDemirci";
            var relationship2 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 3,
                Status = 0,
                ActionUserId = 1
            };
            var username2 = "IhsanDemirci";

            var relationshipsUsr = new Dictionary<string, Relationship>();
            relationshipsUsr.Add(username1, relationship1);
            relationshipsUsr.Add(username2, relationship2);
            return relationshipsUsr;
        }

        public Dictionary<string, Relationship> GetFriends(int id)
        {
            var relationship1 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 2,
                Status = 1,
                ActionUserId = 1
            };
            var username1 = "EmirhanDemirci";
            var relationship2 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 3,
                Status = 1,
                ActionUserId = 3
            };
            var username2 = "IhsanDemirci";

            var relationshipsUsr = new Dictionary<string, Relationship>();
            relationshipsUsr.Add(username1, relationship1);
            relationshipsUsr.Add(username2, relationship2);
            return relationshipsUsr;
        }

        public bool CheckRelationship(Relationship relationship)
        {
            throw new NotImplementedException();
        }
    }
}