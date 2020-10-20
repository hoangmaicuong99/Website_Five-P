using Five_P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class ShowActivateReplyPostController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/ShowActivateReplyPost
        public ActionResult Index()
        {
            List<Show_Activate_Reply_Post> show_Activate_Reply_Post = db.Show_Activate_Reply_Post.OrderBy(n => n.Reply_Post.reply_post_title).ToList();
            ViewBag.SumShowARP = show_Activate_Reply_Post.Count();
            return View(show_Activate_Reply_Post);
        }
    }
}