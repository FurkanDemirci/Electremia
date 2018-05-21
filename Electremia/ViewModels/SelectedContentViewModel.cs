using System;
using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.ViewModels
{
    public class SelectedContentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public List<int> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
        public decimal Price { get; set; }
    }
}