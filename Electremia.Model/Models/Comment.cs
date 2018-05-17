using System.Collections.Generic;

namespace Electremia.Model.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }
        public List<int> Likes { get; set; }


        public Comment()
        {
            Likes = new List<int>();
        }
    }
}