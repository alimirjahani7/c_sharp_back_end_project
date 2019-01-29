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
    public class UserController
    {

        private readonly DataContext context;
        public UserController(DataContext _context)
        {
            context = _context;
            //User u = new User();
            //u.SignUpTime = DateTime.Now;
            //u.Username = "Admin";
            //u.Password = "asdfasdf";
            //context.Users.Add(u);
            //context.SaveChanges();
        }

        //gereftan tamame user ha
        // POST api/user/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return context.Users.ToList();
        }


        //peida kardan user ba id
        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        //[HttpGet("id")]
        //public async Task<ActionResult<User>> GetUser()
        //{
        //    var user = await context.Users.FindAsync(4);
        //    Console.WriteLine("asdaasd");
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    return user;
        //}


        //sakhte user e jadid
        //POST api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.SignUpTime = DateTime.Now;
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

    }
}
