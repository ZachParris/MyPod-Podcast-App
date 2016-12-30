using Microsoft.AspNet.Identity;
using MyPod.DAL;
using MyPod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPod.Controllers
{
    public class BlogController : ApiController
    {
        [HttpGet]
        [Route("api/blog")]
        // GET: api/Blog
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blog/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        [Route("api/blog")]
        // POST: api/Blog
        public void Post([FromBody]string value)
        {
            MyPodRepository repo = new MyPodRepository();
            var userId = User.Identity.GetUserId();
            repo.AddBlogPost(userId, value);
        }

        // PUT: api/Blog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Blog/5
        public void Delete(int id)
        {
        }
    }
}
