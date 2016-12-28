using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPod.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.IsLandingPage = true;
            ViewBag.IsPlaying = false;
            return View();
        }

      
    }
}