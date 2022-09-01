using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class SearchBarController : Controller
    {
        ResearchGateEntities context = new ResearchGateEntities();
        // GET: SearchBar
        [HttpPost]
        public ActionResult GetAuthorbyName(string authorname)
        {
            List<Author> authors = context.Authors.ToList();
            string nametolower = authorname.ToLower();
            string author;
            bool flag = false;
            foreach (var item in authors)
            {
                author = item.FirstName +" "+ item.LastName;
                
                if (String.Equals(author.ToLower(), nametolower))
                {
                    flag = true;
                    return Json(new {result=true, redirectToUrl = Url.Action("Author", "Profile",new { id=item.ID}) });

                }

            }
            return Json(new { result = false });
        }
        [HttpPost]
        public ActionResult GetAuthorbyEmail(string authoremail)
        {
            List<Author> authors = context.Authors.ToList();
            string emailtolower = authoremail.ToLower();
            string author;
            bool flag = false;
            foreach (var item in authors)
            {
                author = item.Email;

                if (String.Equals(author.ToLower(), emailtolower))
                {
                    flag = true;
                    return Json(new { result = true, redirectToUrl = Url.Action("Author", "Profile", new { id = item.ID }) });

                }

            }
            return Json(new { result = false });
        }
        [HttpPost]
        public ActionResult GetAuthorbyUniversity(string authoruniversity,string authorname)
        {
            var authors = context.Authors.ToList().Where(s=>s.University==(authoruniversity));
            string nametolower = authorname.ToLower();
            string author;
            bool flag = false;
            foreach (var item in authors)
            {
                author = item.FirstName + " " + item.LastName;

                if (String.Equals(author.ToLower(), nametolower))
                {
                    flag = true;
                    return Json(new { result = true, redirectToUrl = Url.Action("Author", "Profile", new { id = item.ID }) });

                }

            }
            return Json(new { result = false });
        }
    }
}