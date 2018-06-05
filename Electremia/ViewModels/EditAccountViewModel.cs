using Electremia.Model.Models;
using Microsoft.AspNetCore.Http;

namespace Electremia.ViewModels
{
    public class EditAccountViewModel
    {
        public User User { get; set; }
        public IFormFile ProfileFormFile { get; set; }
        public IFormFile CoverFormFile { get; set; }

        public EditAccountViewModel() { }

        public EditAccountViewModel(User user)
        {
            User = user;
        }
    }
}
