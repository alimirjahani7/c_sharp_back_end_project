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
        public Guid Name { get; set; }
        public string Context { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual IList<Like> Likes { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public string FileName { get; set; }
        public DateTime SendPostTime { get; set; }
    }
}
