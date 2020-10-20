using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AllActivatePostUserController : Controller
    {
        // GET: AllActivatePostUser
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            List<Show_Activate_Post> show_Activate_Post = db.Show_Activate_Post.Where(n => n.user_id == user.user_id).ToList();
            return View(show_Activate_Post);
        }
    }
}