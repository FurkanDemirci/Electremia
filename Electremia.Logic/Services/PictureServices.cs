using System;
using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class PictureServices
    {
        private readonly PictureRepository _repo;

        public PictureServices(PictureRepository repo)
        {
            _repo = repo;
        }

        public bool AddPicture(Picture model)
        {
            return _repo.Add(model);
        }

        public List<Picture> GetAll(int id, int type)
        {
            //TODO Krijg alle pictures van de type content.
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.GetAll(id, type);
        }

        // Create new picture
        // Delete picture
    }
}