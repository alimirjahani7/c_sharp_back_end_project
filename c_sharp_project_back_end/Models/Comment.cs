using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Message { get; set; }
    }
}
