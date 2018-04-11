using System;
using System.Collections.Generic;

namespace Electremia.Model.Models
{
    /// <summary>
    /// IContent is needed for all types of content for the application.
    /// </summary>
    public interface IContent
    {
        string Title { get; set; }
        string Description { get; set; }
        string Picture { get; set; }
        DateTime DateTime { get; set; }
        bool Active { get; set; }
        List<Like> Likes { get; set; }
        List<Comment> Comments { get; set; }
    }
}