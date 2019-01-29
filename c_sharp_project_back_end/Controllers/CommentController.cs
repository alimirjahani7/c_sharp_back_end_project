using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_project_back_end.Controllers
{
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
        public async Task<ActionResult<Comment>> GetComment(long id)
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/comment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
