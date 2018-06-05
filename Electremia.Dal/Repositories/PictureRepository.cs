using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Repositories
{
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        public PictureRepository(IRepository<Picture> context) : base(context)
        {
        }

        private IPictureRepository RightContext()
        {
            switch (Context)
            {
                case PictureSqlContext context:
                    return context;
                case PictureMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public List<Picture> GetAll(int id, int type)
        {
            return RightContext().GetAll(id, type);
        }
    }
}