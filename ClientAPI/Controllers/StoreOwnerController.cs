using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientAPI.Models;
using ClientAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientAPI.Controllers
{
    public class StoreOwnerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly StoreOwnerService _storeOwnerService;
        private readonly SystemService _systemService;

        public StoreOwnerController(IConfiguration configuration,
                                    StoreOwnerService storeOwnerService,
                                    SystemService systemService)
        {
            _configuration = configuration;
            _storeOwnerService = storeOwnerService;
            _systemService = systemService;
        }

        [TempData]
        public string SuccessMessage { set; get; }
        [TempData]
        public string ErrorMessage { set; get; }
        [TempData]
        public string SessionData { set; get; }

        [HttpPost]
        public IActionResult Index(StoreOwnerAccount storeOwnerAccount)
        {
            
            if (storeOwnerAccount != null)
            {
                //Kiem tra username da ton tai
                bool isUsernameExisted = _storeOwnerService.IsStoreOwnerUsernameExisted(storeOwnerAccount.Username);

                if (isUsernameExisted)
                {
                    ErrorMessage = "Store Owner Username already existed";

                    TempData["ErrorMessage"] = ErrorMessage;

                    return View("SignUp");

                }

                var result = _storeOwnerService.AddStoreOwnerApi(storeOwnerAccount);

                if (result.IsSuccessStatusCode)
                {
                    var accountId = _storeOwnerService.GetStoreOwnerAccountIdByUsername(storeOwnerAccount.Username);

                    var sessionAccount = new Account()
                    {
                        Id = accountId,
                        Username = storeOwnerAccount.Username,
                        Role = AccountRole.StoreOwner
                    };

                    setSessionAccount(sessionAccount, storeOwnerAccount.Username, "Your account has been created successfuly!");

                    var storeOwner = _storeOwnerService.AccountLogin(sessionAccount.Username, sessionAccount.Password);

                    return View(storeOwner);
                }
            }
            ErrorMessage = "Sign Up failed. Please try again!";

            TempData["ErrorMessage"] = ErrorMessage;

            return RedirectToAction("SignUp");
        }

        public IActionResult Login()
        {
            TempData["SuccessMessage"] = string.Empty;

            return View("Login");
        }

        [HttpPost]
        public IActionResult StoreOwnerLogin(string username, string password)
        {
            TempData["SuccessMessage"] = string.Empty;

            var storeOwner = _storeOwnerService.AccountLogin(username, password);

            if(storeOwner != null)
            {
                var sessionAccount = new Account()
                {
                    Id = storeOwner.Id.ToString(),
                    Username = storeOwner.account.Username,
                    Role = AccountRole.StoreOwner
                };

                setSessionAccount(sessionAccount, storeOwner.Name, "Login Success");

                return View("Index", storeOwner);
            }
            ErrorMessage = "Wrong username or password";

            TempData["ErrorMessage"] = ErrorMessage;

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sessionAccount = HttpContext.Session.GetString("account");

            if (!string.IsNullOrEmpty(sessionAccount))
            {
                var account = JsonConvert.DeserializeObject<Account>(sessionAccount);

                var storeOwner = _storeOwnerService.AccountLogin(account.Username, account.Password);

                return View(storeOwner);
            }

            return NotFound("YOU HAVE NO RIGHT TO ACCESS THIS PAGE");
        }

        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        public IActionResult CampaignManagement()
        {
            return View("CampaignManagement");
        }
        public IActionResult Information()
        {
            return View("Information");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        private void setSessionAccount(Account account, string name, string successMessage)
        {
            var jsonString = JsonConvert.SerializeObject(account);

            HttpContext.Session.SetString("account", jsonString);

            HttpContext.Session.SetString("accountname", name);

            SuccessMessage = successMessage;

            TempData["SuccessMessage"] = SuccessMessage;

            SessionData = HttpContext.Session.GetString("account");

            TempData["SessionData"] = SessionData;
        }
    }
}
