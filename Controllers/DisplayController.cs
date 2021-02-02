using HitServicesCore.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPosLicense.Controllers
{
    public class DisplayController : Controller
    {
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
