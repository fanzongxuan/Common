using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Common.Cache;
using Microsoft.AspNetCore.Mvc;
using SampleMvcWeb.Models;

namespace SampleMvcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheManager _ICacheManager;

        public HomeController(ICacheManager cacheManager)
        {
            _ICacheManager = cacheManager;
        }

        public IActionResult Index()
        {
            _ICacheManager.Set("test","test",500);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
