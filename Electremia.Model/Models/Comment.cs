namespace Electremia.Model.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        private string _text;

        public Comment(string text)
        {
            _text = text;
        }
    }
}