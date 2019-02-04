using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_project_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_project_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController
    {

        private readonly DataContext context;
        public ImageController(DataContext _context)
        {
            context = _context;
        }


        //gereftan e hameie post ha
        // psot: api/image
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Post>>> GetPosts()//IFormFile file
        //{

        //    return null;
        //    //return context.Posts.ToList();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> asdsadaasd()
        {
            return context.Users.ToList();
        }

    }
}

