using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class ShowActivatePostController : Controller
    {
        // GET: Admin/ShowActivatePost
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Show_Activate_Post> show_Activate_Posts = db.Show_Activate_Post.OrderBy(n => n.Post.post_title).ToList();
            ViewBag.SumShowAP = show_Activate_Posts.Count();
            return View(show_Activate_Posts);
        }
    }
}