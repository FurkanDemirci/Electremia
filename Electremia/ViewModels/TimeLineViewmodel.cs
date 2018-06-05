using Electremia.Model.Models;
using System.Collections.Generic;

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