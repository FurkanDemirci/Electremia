using Electremia.Dal.Repositories;
using Electremia.Model.Models;
using System.Collections.Generic;

namespace Electremia.Logic.Services
{
    public class PictureServices
    {
        private readonly PictureRepository _repo;

        public PictureServices(PictureRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Add picture to content.
        /// </summary>
        /// <param name="model">Picture model</param>
        /// <returns>Boolean</returns>
        public bool AddPicture(Picture model)
        {
            // Check for empty values.
            if (model.Url == null)
                throw new ExceptionHandler("NotImplemented", "Not all parameters are filled");

            return _repo.Add(model);
        }

        /// <summary>
        /// Get all pictures from the content.
        /// </summary>
        /// <param name="id">Content Id</param>
        /// <param name="type">Content Type</param>
        /// <returns>List of pictures</returns>
        public List<Picture> GetAll(int id, int type)
        {
            // Check for empty values.
            if ((id <= 0) && (type < 0))
                throw new ExceptionHandler("NotImplemented", "Not all parameterd are filled");

            return _repo.GetAll(id, type);
        }
    }
}