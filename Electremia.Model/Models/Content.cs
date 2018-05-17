using System;
using System.Collections.Generic;

namespace Electremia.Model.Models
{
    /// <summary>
    /// Content abstract class is needed for all types of content for the application.
    /// </summary>
    public abstract class Content
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
        public List<int> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }

        protected Content()
        {
            Likes = new List<int>();
            Comments = new List<Comment>();
            Pictures = new List<Picture>();
        }
    }
}