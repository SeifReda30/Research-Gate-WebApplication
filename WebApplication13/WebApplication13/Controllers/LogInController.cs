using WebApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication13.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        public ActionResult Check(Account acc)
        {
            var context = new ResearchGateEntities();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                if (author.Email == acc.Email && author.Password == acc.Password)
                {
                    Session["userid"] = Convert.ToString(author.ID);
                    return RedirectToAction("MainIndex", "Home", new { id = author.ID });
                }
            }
            Session["userid"] = "0";
            return View("Error404");
        }
    }
}