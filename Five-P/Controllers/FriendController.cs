using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        FivePEntities db = new FivePEntities();
        [HttpPost]
        public ActionResult AddFriend([Bind(Include = "friend_id,user_id,user_friend_id,friend_status")] Friend friend)
        {
            User user = (User)Session["user"];
            Friend sfriend = db.Friends.Where(n => n.user_id == user.user_id || n.user_id == friend.user_id && n.user_friend_id == friend.user_id || n.user_friend_id == user.user_id).FirstOrDefault();
            if(sfriend == null)
            {
                friend.user_id = user.user_id;
                friend.friend_status = false;
                db.Friends.Add(friend);
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Friends.Remove(db.Friends.Find(sfriend.friend_id));
                db.SaveChanges();
                return View();
            }
            
        }
    }
}