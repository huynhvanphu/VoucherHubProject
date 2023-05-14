using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Campaign> GetAllCampaigns()
        {
            var random = new Random();

            var campaigns = new List<Campaign>();

            campaigns.AddRange(new List<Campaign>() {
                new Campaign() {name = "Campaign 1", createdAt = DateTime.Now, description = "description 1", startDate = DateTime.Now, endDate = DateTime.Now.AddDays(random.Next(1,10))},
                new Campaign() {name = "Campaign 2", createdAt = DateTime.Now, description = "description 2", startDate = DateTime.Now, endDate = DateTime.Now.AddDays(random.Next(1,10))},
                new Campaign() {name = "Campaign 3", createdAt = DateTime.Now, description = "description 3", startDate = DateTime.Now, endDate = DateTime.Now.AddDays(random.Next(1,10))},
                new Campaign() {name = "Campaign 4", createdAt = DateTime.Now, description = "description 4", startDate = DateTime.Now, endDate = DateTime.Now.AddDays(random.Next(1,10))},
                new Campaign() {name = "Campaign 5", createdAt = DateTime.Now, description = "description 5", startDate = DateTime.Now, endDate = DateTime.Now.AddDays(random.Next(1,10))}
            });

            return campaigns;
        }
    }
}
