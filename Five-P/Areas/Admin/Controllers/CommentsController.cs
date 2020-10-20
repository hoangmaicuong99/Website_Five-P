using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/Comments
        public ActionResult Index()
        {
            List<Comment> commnet = db.Comments.OrderBy(n => n.Reply_Post.reply_post_title).ToList();
            ViewBag.SumComment = commnet.Count();
            return View(commnet);
        }
    }
}