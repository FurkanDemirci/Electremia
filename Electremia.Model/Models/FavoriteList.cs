using System;
using System.Collections.Generic;

namespace Electremia.Model.Models
{
    public class FavoriteList
    {
        public int FavoriteListId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}