namespace Electremia.Model.Models
{
    public class Relationship
    {
        public int UserID_one { get; set; }
        public int UserID_two { get; set; }
        public int Status { get; set; }
        public int ActionUserId { get; set; }
    }
}