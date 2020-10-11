using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Five_P.Areas.Admin.Controllers
{
    public class TickPostsController : Controller
    {
        // GET: Admin/TickPosts
        public ActionResult Index()
        {
            return View();
        }
    }
}