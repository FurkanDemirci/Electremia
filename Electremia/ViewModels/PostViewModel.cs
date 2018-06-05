using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Electremia.ViewModels
{
    public class PostViewModel : ContentViewModel
    {
        public List<IFormFile> Picture { get; set; }
        // Extra possibilities.
    }
}