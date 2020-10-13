using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class RateReplyPostsController : Controller
    {
        // GET: Admin/RateReplyPosts
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Rate_Reply_Post> rate_Reply_Post = db.Rate_Reply_Post.OrderBy(n => n.Reply_Post.reply_post_title).ToList();
            return View(rate_Reply_Post);
        }
    }
}