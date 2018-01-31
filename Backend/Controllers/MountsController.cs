using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/mounts")]
    public class MountsController : Controller
    {
        // GET: api/mounts
        [HttpGet]
        public IEnumerable<Mount> Get()
        {
            using (var db = new CollectorContext())
            {
                return db.Mount.ToList();
            }
        }

        // GET: api/mounts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/mounts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/mounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
