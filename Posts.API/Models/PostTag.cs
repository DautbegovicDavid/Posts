using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.API.Models
{
    public class PostTag
    {
        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }  
    }
}
