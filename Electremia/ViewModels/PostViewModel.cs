using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Electremia.ViewModels
{
    public class PostViewModel : ContentViewModel
    {
        public List<IFormFile> Picture { get; set; }
        // Extra possibilities.
    }
}