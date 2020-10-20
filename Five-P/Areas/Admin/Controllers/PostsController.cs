using Five_P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            List<Post> post = db.Posts.ToList();
            ViewBag.SumPost = post.Count();
            return View(post);
        }
    }
}