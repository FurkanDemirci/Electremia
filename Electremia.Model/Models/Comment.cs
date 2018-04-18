namespace Electremia.Model.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int[] Likes { get; set; }
        public string Text { get; }

        public Comment(string text)
        {
            Text = text;
        }
    }
}