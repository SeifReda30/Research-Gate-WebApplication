using WebApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication13.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        public ActionResult Edit()
        {
            var context = new ResearchGateEntities();
            var author = context.Authors.Find(Convert.ToInt32(Session["userid"]));
            return View(author);
        }

        [HttpPost]
        public ActionResult ApplyEdit([Bind(Exclude = "ProfileImage")]Author author, HttpPostedFileBase ProfileImage)
        {
            var context = new ResearchGateEntities();
            var currentauthor = context.Authors.Find(Convert.ToInt32(Session["userid"]));
            if (ProfileImage != null)
            {

                byte[] imgBinaryData = new byte[ProfileImage.ContentLength];
                int readresult = ProfileImage.InputStream.Read(imgBinaryData, 0, ProfileImage.ContentLength);
                author.ProfileImage = imgBinaryData;
                currentauthor.ProfileImage = author.ProfileImage;
            }


            currentauthor.FirstName = author.FirstName;
            currentauthor.LastName = author.LastName;
            currentauthor.Mobile = author.Mobile;
            currentauthor.Password = author.Password;
            currentauthor.University = author.University;
            currentauthor.Email = author.Email;
            currentauthor.Department = author.Department;
            context.SaveChanges();
            return RedirectToAction("Author", "Profile", new { id = currentauthor.ID });
        }
    }
}