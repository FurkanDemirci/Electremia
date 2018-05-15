using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.ViewModels
{
    public class TimeLineViewmodel
    {
        public List<Post> Posts { get; set; }
        public List<Product> Products { get; set; }

        public TimeLineViewmodel()
        {
            Posts = new List<Post>();
            Products = new List<Product>();
        }
    }
}