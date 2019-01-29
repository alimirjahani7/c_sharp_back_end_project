using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Controllers
{
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
            return null;
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
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return null;
        }


        //no idea
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(long id, Post post)
        {
            if (id != post.Id)
            {
                return null;
            }
            context.Entry(post).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return null;
        }

        //delete kardan yek post
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(long id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            //TODO delete kardan e comment ha
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
            return post;
        }

        // comment haie ye post
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(long id)
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
        public async Task<ActionResult<Comment>> GetPostComment(long id, long id2)
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
