using System;

namespace Electremia.Model.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string AttendedFor { get; set; }
    }
}