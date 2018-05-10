using System;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PictureServices
    {
        private readonly Repository<Picture> _repo;

        public PictureServices(Repository<Picture> repo)
        {
            _repo = repo;
        }

        public bool AddPicture(Picture model)
        {
            return _repo.Add(model);
        }
        // Create new picture
        // Delete picture
    }
}