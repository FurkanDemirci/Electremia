using Electremia.Model.Models;
using System.Collections.Generic;

namespace Electremia.ViewModels
{
    public class ProfileViewModel
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public string CoverPicture { get; set; }
        public string Certificate { get; set; }
        public bool Admin { get; set; }
        public List<Job> Jobs { get; set; }
        public List<School> Schools { get; set; }
        public bool IsFriendsWith { get; set; }
        public int Posts { get; set; }
        public int Products { get; set; }
    }
}