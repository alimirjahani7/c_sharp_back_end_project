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
        }

        //gereftan tamame user ha
        // GET api/user/
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

        [HttpPost("login")]
        public ActionResult<int> Login(User user)
        {
            var users = context.Users.Where(x => x.Username == user.Username);
            if (users.ToList().Count == 0)
            {
                return -1;//no user with this username
            }
            if (users.ToList().Count == 1)
            {
                users = users.Where(x => x.Password == user.Password);
                if (users.ToList().Count == 0)
                {
                    return -2; // password wrong
                }
                return users.ToList().ElementAt(0).Id;
            }
            return -3;   // more than one user with this username
        }


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
