using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Posts.Model.Requests
{
    public class PostInsertRequest
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string body { get; set; }
        public List<string> tagsList { get; set; }
    }
}
