using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antlr.Runtime;
using Domain.Model;

namespace EasyLift.Areas.API.Controllers
{
    public class IndividualController : ApiController
    {
        // GET: api/Individual
        public IEnumerable<Individual> Get()
        {
            return new List<Individual>();
        }

        // GET: api/Individual/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Individual
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Individual/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Individual/5
        public void Delete(int id)
        {
        }
    }
}
