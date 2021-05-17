using System;
using System.Collections.Generic;

namespace Posts.API.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public virtual ICollection<PostTag> tagList { get; set; }
    }
}
