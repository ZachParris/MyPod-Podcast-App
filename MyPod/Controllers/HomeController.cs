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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a place to share podcasts as well as thoughts and ideas!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us anytime!";

            return View();
        }
    }
}