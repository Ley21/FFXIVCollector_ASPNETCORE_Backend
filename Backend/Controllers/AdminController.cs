using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        // GET: api/Admin
        [HttpGet("mounts")]
        public Mount[] AddAndUpdateMounts()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://api.xivdb.com/mount/").Result;
                var json = result.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<JArray>(json.Result);
                using (var db = new CollectorContext())
                {
                    foreach (var mountJsonObject in jsonObject)
                    {
                        var id = mountJsonObject.Value<int>("id");
                        var name = mountJsonObject.Value<string>("name");
                        var mount  = new Mount{Id = id,Name = name};
                        db.Mount.AddOrUpdate(mount, m => m.Id == id);
                        db.SaveChanges();
                    }

                    return db.Mount.ToArray();
                }

                
            }
            
        }

        
    }
}
