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
    public class CampaignController : Controller
    {
        // GET: /<controller>/
        public IActionResult CampaignDetails()
        {
            return View("CampaignDetails");
        }
    }
}
