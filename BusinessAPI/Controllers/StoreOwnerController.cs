using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessAPI.Controllers
{
    [Route("api/[controller]")]
    public class StoreOwnerController : Controller
    {
        private readonly IConfiguration _configuration;

        public StoreOwnerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(StoreOwner storeOwner)
        {
            if (storeOwner != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetConnectionString("DataAccessApi"));

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<StoreOwner>("StoreOwner/SignUp", storeOwner);

                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return Ok();
                    }
                }
            }
            return NotFound();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
