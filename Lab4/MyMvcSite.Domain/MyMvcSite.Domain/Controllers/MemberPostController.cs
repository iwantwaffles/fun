using MyMvcSite.Domain.DAL;
using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcSite.Domain.Controllers
{
    public class MemberPostController : Controller
    {
        // GET: MemberPost
        public ActionResult Index()
        {
            ForumContext db = new ForumContext();
            var members = db.Members.Include("Posts");

            var tmlist = new List<PostViewModel>();
            foreach (Member u in members)
            {
                var aPost = u.Posts.FirstOrDefault();

                tmlist.Add(new PostViewModel()
                {
                    Body = aPost.Body,
                    CreationDate = aPost.CreationDate,
                    MemberID = new MemberViewModel()
                    {
                        UserName = u.UserName
                    }
                });
            }

            return View(tmlist);
        }
    }
}