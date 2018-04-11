using System;
using System.Collections.Generic;

namespace Electremia.Model.Models
{
    public class Post : IContent
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}