using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class ReplyPostsController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/ReplyPosts
        public ActionResult Index()
        {
            List<Reply_Post> reply_Post = db.Reply_Post.OrderBy(n => n.Post.post_title).ToList();
            ViewBag.SumReplyPost = reply_Post.Count();
            return View(reply_Post);
        }
    }
}