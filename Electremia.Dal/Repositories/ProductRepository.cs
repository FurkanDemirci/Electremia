using System;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Dal.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IRepository<Product> context) : base(context)
        {
        }

        private IProductRepository RightContext()
        {
            switch (Context)
            {
                case ProductSqlContext context:
                    return context;
                case ProductMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public new int Add(Product entity)
        {
            return RightContext().Add(entity);
        }


    }
}