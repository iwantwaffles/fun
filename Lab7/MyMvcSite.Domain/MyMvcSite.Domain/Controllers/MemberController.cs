using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMvcSite.Domain.DAL;
using MyMvcSite.Domain.Models;

namespace MyMvcSite.Domain.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository repo;

      public MemberController()
      {
          repo = new MemberRepository(new ForumContext());
      }

        private ForumContext db = new ForumContext();

        // GET: Member
        public ActionResult Index()
        {
            return View(repo.GetMembers());
        }

        // GET: Member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = repo.GetMemberByID((int)id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,UserName,Password,Name,Email")] Member member)
        {
            if (ModelState.IsValid)
            {
                repo.InsertMember(member);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = repo.GetMemberByID((int)id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,UserName,Password,Name,Email")] Member member)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateMember(member);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteMember(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
