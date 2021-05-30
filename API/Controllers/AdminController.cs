using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseAccess;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class AdminController : ApiController
    {
        // GET: api/Admin
        IUser userRepos = new UserRepos();
        [HttpGet]
        [Route("get-list-user")]
        public IEnumerable<User> Get()
        {
            return userRepos.findAll();
        }

        // GET: api/Admin/5
        [HttpGet]
        [Route("get-id-user/{id}")]
        public User Get(int id)
        {
            return userRepos.findIdUser(id);
        }

        // POST: api/Admin
        [HttpPost]
        [Route("insert-user")]
        public Boolean Post([FromBody]User user)
        {
            return userRepos.insertUser(user);
        }

        [HttpPost]
        [Route("delete-user/{id}")]
        public Boolean Post([FromUri] int id)
        {
            return userRepos.deleteUser(id);
        }
    }
}
