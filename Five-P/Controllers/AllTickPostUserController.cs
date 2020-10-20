using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AllTickPostUserController : Controller
    {
        // GET: AllTickPostUser
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            List<Tick_Post> tick_Post = db.Tick_Post.Where(n => n.user_id == user.user_id).ToList();
            return View(tick_Post);
        }
    }
}