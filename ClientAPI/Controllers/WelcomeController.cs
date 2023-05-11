using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientAPI.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly CustomerService customerService;

        public WelcomeController(CustomerService _customerService)
        {
            customerService = _customerService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public string Greeting() => "Xin chao cac ban";

        public IActionResult Bird()
        {
            string path = Path.Combine(Startup.RootPath, "MediaFiles", "bird.jpeg");

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "image/jpeg");
        }

        public IActionResult ViewCustomers()
        {
            TempData["SuccessMessage"] = $"So luong khach hang la {customerService.Count()}";

            return View(customerService);
        }
    }
}
