namespace Electremia.Model.Models
{
    public class Admin : User
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }
}