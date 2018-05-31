using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class RelationshipMemoryContext : IRelationshipRepository
    {
        private readonly List<Relationship> _relationships;
        private readonly List<string> _username;

        public RelationshipMemoryContext()
        {
            _relationships = new List<Relationship>();
            _username = new List<string>();

            var relationship1 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 2,
                Status = 0,
                ActionUserId = 1
            };
            const string username1 = "EmirhanDemirci";

            var relationship2 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 3,
                Status = 1,
                ActionUserId = 3
            };
            const string username2 = "AsumanDemirci";

            var relationship3 = new Relationship
            {
                UserID_one = 1,
                UserID_two = 4,
                Status = 0,
                ActionUserId = 1
            };
            const string username3 = "IhsanDemirci";

            _relationships.Add(relationship1);
            _username.Add(username1);

            _relationships.Add(relationship2);
            _username.Add(username2);

            _relationships.Add(relationship3);
            _username.Add(username3);
        }

        public Relationship GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Relationship entity)
        {
            _relationships.Add(entity);
            return true;
        }

        public bool Update(Relationship entity)
        {
            foreach (var relationship in _relationships)
            {
                if (relationship.UserID_one != entity.UserID_one || relationship.UserID_two != entity.UserID_two ||
                    relationship.Status != 0) continue;
                relationship.Status = 1;
                return true;
            }

            return false;
        }

        public bool Delete(Relationship entity)
        {
            foreach (var relationship in _relationships)
            {
                if ((relationship.UserID_one == entity.UserID_one) && (relationship.UserID_two == entity.UserID_two))
                    return _relationships.Remove(relationship);
            }
            return false;
        }

        public Dictionary<string, Relationship> GetPending(int id)
        {
            var relationships = new Dictionary<string, Relationship>();

            for (int i = 0; i < _relationships.Count; i++)
            {
                if ((_relationships[i].UserID_one == id || _relationships[i].UserID_two == id) && _relationships[i].Status == 0)
                    relationships.Add(_username[i], _relationships[i]);
            }
            return relationships;
        }

        public Dictionary<string, Relationship> GetSended(int id)
        {
            var relationships = new Dictionary<string, Relationship>();

            for (int i = 0; i < _relationships.Count; i++)
            {
                if (_relationships[i].ActionUserId == id && _relationships[i].Status == 0)
                    relationships.Add(_username[i], _relationships[i]);
            }
            return relationships;
        }

        public Dictionary<string, Relationship> GetFriends(int id)
        {
            var relationships = new Dictionary<string, Relationship>();

            for (int i = 0; i < _relationships.Count; i++)
            {
                if ((_relationships[i].UserID_one == id || _relationships[i].UserID_two == id) && _relationships[i].Status == 1)
                    relationships.Add(_username[i], _relationships[i]);
            }
            return relationships;
        }

        public bool CheckRelationship(Relationship relationship)
        {
            foreach (var model in _relationships)
            {
                if (relationship.UserID_one == model.UserID_one && relationship.UserID_two == model.UserID_two &&
                    model.Status == 1)
                    return true;
            }
            return false;
        }
    }
}