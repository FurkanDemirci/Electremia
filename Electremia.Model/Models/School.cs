namespace Electremia.Model.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }
        public string AttendedFor { get; set; }
    }
}