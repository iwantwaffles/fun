using MyMvcSite.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcSite.Domain.Controllers
{
    public class AnimeSubForumController : Controller
    {
        private ForumContext db = new ForumContext();
        // GET: AnimeSubForum
        public ActionResult Index()
        {
            return View();
        }
    }
}