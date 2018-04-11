using System.Collections.Generic;

namespace Electremia.Model.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ProfilePicture { get; set; }
		public string CoverPicture { get; set; }
		public string Certificate { get; set; }
		public bool Active { get; set; }
		public List<Job> Jobs { get; set; }
		public List<School> Schools { get; set; }
		public List<Relationship> Relationships { get; set; }
	}
}
