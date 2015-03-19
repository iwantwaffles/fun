using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMvcSite.DAL;
using MyMvcSite.Models;
using PagedList;

namespace MyMvcSite.Controllers
{
    public class PostCrudController : Controller
    {
        private MessageBoardContext db = new MessageBoardContext();
        private static int ThisID = 0;

        // GET: PostCrud
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PostSortParm = String.IsNullOrEmpty(sortOrder) ? "post_desc" : "";
            ViewBag.UserSortParm = String.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var posts = from p in db.Posts
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(p => p.Message.Contains(searchString)
                                       || p.Username.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "post_desc":
                    posts = posts.OrderByDescending(p => p.Message);
                    break;
                case "user_desc":
                    posts = posts.OrderByDescending(p => p.Username);
                    break;
                case "Date":
                    posts = posts.OrderBy(p => p.DatePosted);
                    break;
                default:
                    posts = posts.OrderByDescending(p => p.DatePosted);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        // GET: PostCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            PostViewModel postVM = new PostViewModel();
            postVM.Comments = new List<Comment>();

            postVM.Username = post.Username;
            postVM.Message = post.Message;
            postVM.DatePosted = post.DatePosted;
            foreach (Comment c in post.Comments)
                postVM.Comments.Add(c);

            /*var AllComments = db.Comments.ToList();

            foreach (var thisPostComment in AllComments)
                if (thisPostComment.PostId == post.PostId)
                    post.Comments.Add(thisPostComment);*/
            return View(postVM);

            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);*/
        }

        // GET: PostCrud/Create
        public ActionResult Create()
        {
            var users = new List<string>();
            var userQuery = from u in db.Members
                              orderby u.Username
                              select u.Username;

            users.AddRange(userQuery);
            ViewBag.userList = new SelectList(users);

            return View();
        }

        // POST: PostCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Message,Username,DatePosted")] PostViewModel postVM, string user)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                //Comment message = new Comment();
                post.Message = postVM.Message;
                post.Username = user;
             
                post.DatePosted=DateTime.Now;

                /*var comment = (from c in db.Comments
                               where c.PostId == post.PostId
                               select c);*/

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postVM);
        }

        public ActionResult Reply(int? id)
        {

            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            Comment comment = db.Comments.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ThisID = post.PostId;
            ViewBag.PostMessage = post.Message;
            ViewBag.Poster = post.Username;
            if (comment == null)
            {
            
            }
            else
            {
                ViewBag.CommentMessage = comment.Message;
                ViewBag.CommentPoster = comment.Username;
            }
            

            var users = new List<string>();
            var userQuery = from u in db.Members
                            orderby u.Username
                            select u.Username;

            users.AddRange(userQuery);
            ViewBag.userList = new SelectList(users);


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply([Bind(Include = "Message,Username")] Comment comment, string user)  
        {

            if (ModelState.IsValid)
            {
                PostViewModel postVM = new PostViewModel();
                postVM.Comments = new List<Comment>();

                Post post = db.Posts.Find(ThisID);
                comment.PostId = ThisID;
                comment.DatePosted = DateTime.Now;
                comment.Username = user;

                foreach (Comment c in post.Comments)
                    postVM.Comments.Add(c);

                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", new { Id = ThisID });
                //return RedirectToAction("Detail", car.CarID);
            }

            return View(comment);
        }

        // GET: PostCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: PostCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Message,Username,DatePosted")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: PostCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: PostCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
