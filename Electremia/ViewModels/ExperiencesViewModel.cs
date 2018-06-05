using Electremia.Model.Models;
using System.Collections.Generic;

namespace Electremia.ViewModels
{
    public class ExperiencesViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<School> Schools { get; set; }
        public ExperiencesViewModel()
        {
            Jobs = new List<Job>();
            Schools = new List<School>();
        }
    }
}