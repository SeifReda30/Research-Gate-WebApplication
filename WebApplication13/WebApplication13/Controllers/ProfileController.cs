using WebApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication13.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Author(int id)
        {
            var context = new ResearchGateEntities();
            var author = context.Authors.Find(id);
            return View(author);
        }
    }
}