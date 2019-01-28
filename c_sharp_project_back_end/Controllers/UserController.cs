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

        // POST api/user/login
        [Route("login")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [Route("signup")]
        public void Put([FromBody] string value)
        {

        }


    }
}
