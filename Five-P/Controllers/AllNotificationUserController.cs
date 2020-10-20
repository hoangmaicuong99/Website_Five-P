using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AllNotificationUserController : Controller
    {
        // GET: AllNotificationUser
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            List<Notification> notification = db.Notifications.Where(n => n.user_id == user.user_id).ToList();
            return View(notification);
        }
    }
}