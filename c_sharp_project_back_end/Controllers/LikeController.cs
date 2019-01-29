using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController
    {

        private readonly DataContext context;
        public LikeController(DataContext _context)
        {
            context = _context;
        }

        // POST api/like/numberOflikes
        [HttpGet("numberOfLikes")]
        public void Post(int PostId)
        {

        }

        // Post api/likeUnlike
        [HttpGet("like")]
        public void Put(int PostId,int UserId)
        {

        }

    }
}
