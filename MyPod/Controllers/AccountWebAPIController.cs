using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPod.Controllers
{
    public class AccountWebAPIController : ApiController
    {
        // GET: api/AccountWebAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AccountWebAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccountWebAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccountWebAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccountWebAPI/5
        public void Delete(int id)
        {
        }
    }
}
