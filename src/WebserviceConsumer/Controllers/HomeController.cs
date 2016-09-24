﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebserviceConsumer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        public IActionResult Calculator()
        {
            ViewData["Message"] = "Your Calculator page.";

            return View();
        }

        public IActionResult Docker()
        {
            ViewData["Message"] = "Your Docker page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
