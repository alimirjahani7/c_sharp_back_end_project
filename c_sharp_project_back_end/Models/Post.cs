using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public DateTime SendPostTime { get; set; }
        public virtual IList<Like> Likes { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
