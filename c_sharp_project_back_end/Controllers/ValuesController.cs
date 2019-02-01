﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_project_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext context;
        public ValuesController(DataContext _context)
        {
            context = _context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var likes = context.Likes;
            foreach (var item in likes)
                context.Likes.Remove(item);

            var comments = context.Comments;
            foreach (var item in comments)
                context.Comments.Remove(item);

            var users = context.Users;
            foreach (var item in users)
                context.Users.Remove(item);

            var posts = context.Posts;
            foreach (var item in posts)
                context.Posts.Remove(item);
            await context.SaveChangesAsync();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
