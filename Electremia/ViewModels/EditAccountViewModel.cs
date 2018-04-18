using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Logic.Services;
using Electremia.Model.Models;

namespace Electremia.ViewModels
{
    public class EditAccountViewModel
    {
        public User User { get; set; }

        public EditAccountViewModel() { }

        public EditAccountViewModel(User user, IEnumerable<Job> jobs)

        {
            User = user;
            User.Jobs = (List<Job>)jobs;
        }
    }
}
