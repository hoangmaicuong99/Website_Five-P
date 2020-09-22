using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers.testController
{
    public class Reply_PostController : Controller
    {
        private FivePEntities db = new FivePEntities();

        // GET: Reply_Post
        public ActionResult Index()
        {
            var reply_Post = db.Reply_Post.Include(r => r.Like_Reply_Post).Include(r => r.Post).Include(r => r.User);
            return View(reply_Post.ToList());
        }

        // GET: Reply_Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply_Post reply_Post = db.Reply_Post.Find(id);
            if (reply_Post == null)
            {
                return HttpNotFound();
            }
            return View(reply_Post);
        }

        // GET: Reply_Post/Create
        public ActionResult Create()
        {
            ViewBag.like_reply_post_id = new SelectList(db.Like_Reply_Post, "like_reply_post_id", "like_reply_post_id");
            ViewBag.post_id = new SelectList(db.Posts, "post_id", "post_content");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass");
            return View();
        }

        // POST: Reply_Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reply_post_id,reply_post_content,reply_post_datecreated,reply_post_dateedit,user_id,reply_post_activate,like_reply_post_id,post_id,reply_post_title")] Reply_Post reply_Post)
        {
            if (ModelState.IsValid)
            {
                db.Reply_Post.Add(reply_Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.like_reply_post_id = new SelectList(db.Like_Reply_Post, "like_reply_post_id", "like_reply_post_id", reply_Post.like_reply_post_id);
            ViewBag.post_id = new SelectList(db.Posts, "post_id", "post_content", reply_Post.post_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", reply_Post.user_id);
            return View(reply_Post);
        }

        // GET: Reply_Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply_Post reply_Post = db.Reply_Post.Find(id);
            if (reply_Post == null)
            {
                return HttpNotFound();
            }
            ViewBag.like_reply_post_id = new SelectList(db.Like_Reply_Post, "like_reply_post_id", "like_reply_post_id", reply_Post.like_reply_post_id);
            ViewBag.post_id = new SelectList(db.Posts, "post_id", "post_content", reply_Post.post_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", reply_Post.user_id);
            return View(reply_Post);
        }

        // POST: Reply_Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reply_post_id,reply_post_content,reply_post_datecreated,reply_post_dateedit,user_id,reply_post_activate,like_reply_post_id,post_id,reply_post_title")] Reply_Post reply_Post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply_Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.like_reply_post_id = new SelectList(db.Like_Reply_Post, "like_reply_post_id", "like_reply_post_id", reply_Post.like_reply_post_id);
            ViewBag.post_id = new SelectList(db.Posts, "post_id", "post_content", reply_Post.post_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", reply_Post.user_id);
            return View(reply_Post);
        }

        // GET: Reply_Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply_Post reply_Post = db.Reply_Post.Find(id);
            if (reply_Post == null)
            {
                return HttpNotFound();
            }
            return View(reply_Post);
        }

        // POST: Reply_Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply_Post reply_Post = db.Reply_Post.Find(id);
            db.Reply_Post.Remove(reply_Post);
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
