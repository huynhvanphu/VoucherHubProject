using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientAPI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;

        [TempData]
        public string Message { set; get; }

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Login");
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Index([FromForm] string username, string password)
        {
            Account account = new Account();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetConnectionString("BusinessApi"));

                //HTTP GET
                var responseTask = client.GetAsync("Admin");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Account>();

                    readTask.Wait();

                    account = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Wrong username or password");
                }
            }
            if (account != null && (username == account.username && password == account.password))
            {
                return View();

            } else
            {
                Message = "Wrong username or passoword";

                return RedirectToAction("Login", "Admin");
            }
        }

        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
