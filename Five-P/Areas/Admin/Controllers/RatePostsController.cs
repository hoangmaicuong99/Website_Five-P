using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class RatePostsController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/RatePosts
        public ActionResult Index()
        {
            List<Rate_Post> rate_Posts = db.Rate_Post.OrderBy(n => n.Post.post_title).ToList();
            return View(rate_Posts);
        }
    }
}