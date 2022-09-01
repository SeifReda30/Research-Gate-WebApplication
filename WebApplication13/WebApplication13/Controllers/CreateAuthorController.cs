using WebApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication13.Controllers
{
    public class CreateAuthorController : Controller
    {
        // GET: CreateAuthor
        [HttpGet]
        public ActionResult createAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor([Bind(Exclude = "ProfileImage")]Author author, HttpPostedFileBase ProfileImage)
        {
            ResearchGateEntities context = new ResearchGateEntities();
            byte[] imgBinaryData = new byte[ProfileImage.ContentLength];
            int readresult = ProfileImage.InputStream.Read(imgBinaryData, 0, ProfileImage.ContentLength);
            author.ProfileImage = imgBinaryData;
            var authors = context.Authors.ToList();
            foreach (var item in authors)
            {
                if (item.Email == author.Email)
                {
                    return RedirectToAction("Check");
                }
            }
            context.Authors.Add(author);
            context.SaveChanges();
            var users = context.Authors.ToList();
            int id = users[users.Count() - 1].ID;
            Session["userid"] = Convert.ToString(id);
            return RedirectToAction("Author", "Profile", new { id });

        }
        public ActionResult Check()
        {
            return View();
        }
    }
}
