using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime SignUpTime { get; set; }
        public virtual IList<Post> Posts { get; set; }

    }
}
