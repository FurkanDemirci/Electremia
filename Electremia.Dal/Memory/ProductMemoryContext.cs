﻿using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class ProductMemoryContext : IProductRepository
    {
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IProductRepository.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}