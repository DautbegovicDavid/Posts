using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Model
{
    public class PostTag
    {
        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}
