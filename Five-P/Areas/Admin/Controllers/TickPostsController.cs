using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class TickPostsController : Controller
    {
        // GET: Admin/TickPosts
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Tick_Post> tick_Post = db.Tick_Post.OrderBy(n => n.Post.post_title).ToList();
            ViewBag.SumTickPost = tick_Post.Count();
            return View(tick_Post);
        }
    }
}