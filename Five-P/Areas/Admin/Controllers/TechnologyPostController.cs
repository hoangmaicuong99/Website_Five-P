using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class TechnologyPostController : Controller
    {
        // GET: Admin/TechnologyPost
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Technology_Post> technology_Post = db.Technology_Post.OrderBy(n => n.Post.post_title).ToList();
            return View(technology_Post);
        }
    }
}