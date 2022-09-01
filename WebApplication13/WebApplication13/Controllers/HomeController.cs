using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MainIndex()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = "0";
            return RedirectToAction("MainIndex");
        }
        public ActionResult About()
        {
            return View();
        }

    }
}