using System.Collections.Generic;

namespace Posts.API.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string title { get; set; }
        public ICollection<PostTag> postList { get; set; }
    }
}
