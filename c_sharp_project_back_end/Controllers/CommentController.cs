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
    public class CommentController
    {
        private readonly DataContext context;
        public CommentController(DataContext _context)
        {
            context = _context;
        }

        // GET: api/comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return context.Comments.ToList();
        }

        // GET api/comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }
            return comment;
        }

        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<Comment>> Post(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
