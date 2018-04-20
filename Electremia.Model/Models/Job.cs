using System;

namespace Electremia.Model.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }
}