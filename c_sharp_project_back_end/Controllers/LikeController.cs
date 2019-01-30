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
        [HttpGet("{id}/likes")]
        public async Task<ActionResult<IEnumerable<Like>>> GetPostLikes(int id)
        {
            return context.Likes.Where(x => x.PostId == id).ToList();
        }

        // post api/like
        [HttpPost]
        public async Task<ActionResult<Like>> LikePost(Like like)
        {
            var like2 = context.Likes.Where(x => x.PostId == like.PostId).Where(x => x.UserId == like.UserId);
            if (like2.ToList().Count != 0)
            {
                System.Diagnostics.Debug.WriteLine("goddamn " + like2 + " goddamn");

                foreach (var item in like2)
                    context.Likes.Remove(item);
            }
            else
            {
                context.Likes.Add(like);
            }
            await context.SaveChangesAsync();
            return like;

        }

    }
}
