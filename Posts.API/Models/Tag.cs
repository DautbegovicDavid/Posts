using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.API.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string title { get; set; }
        public ICollection<PostTag> postList { get; set; }
    }
}
