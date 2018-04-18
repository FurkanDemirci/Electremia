using System;
using System.Collections.Generic;

namespace Electremia.Model.Models
{
    public class Product : Content
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}