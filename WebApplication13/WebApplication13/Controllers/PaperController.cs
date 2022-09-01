using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class PaperController : Controller
    {
        public List<Author> GetAuthors()
        {
            var context = new ResearchGateEntities();
            var authors = context.Authors.ToList();
            return authors;
        }
        public List<Paper> GetPapers()
        {
            var context = new ResearchGateEntities();
            var papers = context.Papers.ToList();
            return papers;
        }
        // GET: Paper
        [HttpGet]
        public ActionResult CreatePaper()
        {
            List<Author> authors = GetAuthors();
            return View(authors);
        }
        public ActionResult DeletePaper(int id)
        {
           var userid= Convert.ToInt32(Session["userid"]); 
        var context = new ResearchGateEntities();
            var currentauthor = context.Authors.Find(userid);
            foreach (var item in currentauthor.Papers)
            {
                if (item.ID==id)
                {
                    currentauthor.Papers.Remove(item);
                    context.SaveChanges();
                    break;
                }
            }
             var paper= context.Papers.Find(id);
            if (paper.Authors.Count.Equals(0))
            {
                context.Papers.Remove(paper);
                context.SaveChanges();
            }
            return RedirectToAction("Author", "Profile", new { id= Convert.ToInt32(Session["userid"]) });
        }
        [HttpPost]
        public ActionResult AddPaper(int[] Authors, HttpPostedFileBase PaperFile, string Title, string Category, int PublichYear)
        {
            var context = new ResearchGateEntities();
            byte[] fileBinaryData = new byte[PaperFile.ContentLength];
            int readresult = PaperFile.InputStream.Read(fileBinaryData, 0, PaperFile.ContentLength);
            ICollection<int> ids = Authors.ToList();
            ICollection<Author> authors = new List<Author>();

            foreach (var item in ids)
            {
                var authorobj = context.Authors.Find(item);
                authors.Add(authorobj);
            }
            Paper paper = new Paper
            {
                PaperFile = fileBinaryData,
                Category = Category,
                PublichYear = PublichYear,
                Title = Title,
                Authors = authors
            };
            context.Papers.Add(paper);
            context.SaveChanges();
            List<Paper> paperdata = GetPapers();
            int paperid = paperdata[(paperdata.Count) - 1].ID;

            return RedirectToAction("PaperProfile", new { id = paperid });
        }


        public ActionResult PaperProfile(int id)
        {
            ViewBag.PaperID = id;
            var context = new ResearchGateEntities();
            var paper = context.Papers.Find(id);
            return View(paper);
        }
        public void AddComment(string comment,int ID)
        {
            
            var context = new ResearchGateEntities();
            Comment newcomment = new Comment
            {
                AuthorID = Convert.ToInt32(Session["userid"]),
                Comment1 = comment,
                PaperID = ID

            };

            context.Comments.Add(newcomment);
            context.SaveChanges();
        }
        [HttpPost]

        public void AddLike(int ID)
        {

            var context = new ResearchGateEntities();
            Reaction newreact = new Reaction
            {
                AuthorID = Convert.ToInt32(Session["userid"]),
                ReactionType = true,
                PaperID = ID

            };

            context.Reactions.Add(newreact);
            context.SaveChanges();
        }
        [HttpPost]

        public void AddDislike(int ID)
        {

            var context = new ResearchGateEntities();
            Reaction newreact = new Reaction
            {
                AuthorID = Convert.ToInt32(Session["userid"]),
                ReactionType = false,
                PaperID = ID

            };

            context.Reactions.Add(newreact);
            context.SaveChanges();
        }
        [HttpPost]
        public void RemoveReaction(int ID)
        {
            var context = new ResearchGateEntities();
            var reactions=context.Reactions.ToList();
            Reaction reaction = new Reaction();
            foreach(var item in reactions)
            {
                if (item.AuthorID== Convert.ToInt32(Session["userid"]) && item.PaperID==ID)
                {
                    reaction = item;
                    break;
                }
            }
            context.Reactions.Remove(reaction);
            context.SaveChanges();
        }


    }
}