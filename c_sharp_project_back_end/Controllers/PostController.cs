using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController
    {
        private readonly DataContext context;
        public PostController(DataContext _context)
        {
            context = _context;
        }


        //gereftan e hameie post ha
        // GET: api/post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return context.Posts.ToList();
            //return context.Posts.ToList();
        }


        //gereftane ye post e khas
        // GET api/post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post == null)
            {
                return null;
            }
            return post;
        }


        //ezafe kardane post e jadid
        // POST api/post
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.SendPostTime = DateTime.Now;
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }

        // comment haie ye post
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            return post.Comments.ToList();
        }


        //yek comment e khas
        [HttpGet("{id}/comments/{id2}")]
        public async Task<ActionResult<Comment>> GetPostComment(int id, int id2)
        {
            var comment = await context.Comments.FindAsync(id2);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }

    }
}
