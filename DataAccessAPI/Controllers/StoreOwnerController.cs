using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Models.ClientModels;
using DataAccessAPI.Data;
using DataAccessAPI.Data.ClientModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAccessAPI.Controllers
{
    [Route("api/[controller]")]
    public class StoreOwnerController : Controller
    {
        private readonly VoucherHubDbContext _context;

        public StoreOwnerController(VoucherHubDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        [Route("IsUsernameExisted")]
        public bool GetIsUsernameExisted(string username)
        {
            return _context.StoreOwners.Any(user => user.account.Username == username);
        }

        // GET api/values/5
        [HttpGet("GetAccountIdByUsername")]
        public string GetAccountIdByUsername(string username)
        {
            var account = _context.StoreOwners
                            .FirstOrDefault(user => user.account.Username == username
                            && user.account.Role == AccountRole.StoreOwner);

            if (account != null)
            {
                return account.AccountId.ToString();
            }
            return string.Empty;
        }
        
        // POST api/values
        [HttpPost]
        [Route("SignUp")]
        public IActionResult Post([FromBody]StoreOwnerAccount storeOwnerAccount)
        {
            var accountDb = new Account()
            {
                Id = Guid.NewGuid(),
                Username = storeOwnerAccount.Username,
                Password = storeOwnerAccount.Password,
                Role = AccountRole.StoreOwner
            };

            var storeOwnerDb = new StoreOwner()
            {
                Id = Guid.NewGuid(),
                Name = storeOwnerAccount.Name,
                Address = storeOwnerAccount.Address,
                Phone = storeOwnerAccount.Phone,
                Website = storeOwnerAccount.Website,
                ImagePath = storeOwnerAccount.ImagePath,
                Email = storeOwnerAccount.Email,
                CreatedAt = DateTime.Now,
                AccountId = accountDb.Id,
                account = accountDb

            };
            _context.StoreOwners.Add(storeOwnerDb);
            _context.SaveChanges();
            return Ok();
        }

        [Route("AccountLogin")]
        public IActionResult PostAccountLogin(Account account)
        {
            var storeOwner = _context.StoreOwners.FirstOrDefault(user => user.account.Username == account.Username
                                                            && user.account.Password == account.Password);
            var storeOwnerAccount = _context.Accounts.FirstOrDefault(account => account.Id == storeOwner.AccountId && account.Role == AccountRole.StoreOwner);

            storeOwner.account = new Account()
            {
                Id = storeOwnerAccount.Id,
                Username = storeOwnerAccount.Username,
                Password = storeOwnerAccount.Password,
                Role = storeOwnerAccount.Role
            };

            return Json(storeOwner);
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
