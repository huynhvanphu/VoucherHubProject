using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessAPI.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        // GET: api/values
        [HttpGet]
        public Account Get()
        {
            var account = new Account() { username = "admin", password = "admin" };

            return account;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetAdminAccount(string admin)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return Ok();
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
