using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPosLicense.Models;

namespace WebPosLicense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginUser loginUser;
 
        public HomeController(LoginUser _loginUser,ILogger<HomeController> logger)
        {
            this.loginUser = _loginUser;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Version = GetType().Assembly.GetName().Version.ToString();
            return View();
        }

        public IActionResult RedirectToDisplay(string username, string password)
        {
            loginUser.name = username;
            loginUser.password = password;
            return RedirectToAction("Index", "Display");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
