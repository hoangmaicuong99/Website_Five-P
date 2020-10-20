using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Friend friend1 = db.Friends.FirstOrDefault(n => n.user_id == user.user_id && n.user_friend_id == friend.user_friend_id);
            Friend friend2 = db.Friends.FirstOrDefault(n => n.user_id == friend.user_friend_id && n.user_friend_id == user.user_id);
            Friend friend3 = db.Friends.FirstOrDefault(n => n.user_id == user.user_id && n.user_friend_id == friend.user_friend_id && n.friend_status == null);
            Friend friend4 = db.Friends.FirstOrDefault(n => n.user_id == friend.user_friend_id && n.user_friend_id == user.user_id && n.friend_status == true);
            Friend friend5 = db.Friends.FirstOrDefault(n => n.user_id == friend.user_friend_id && n.user_friend_id == user.user_id && n.friend_status == null);
            
            if(friend5 != null)
            {
                db.Friends.Find(friend5.friend_id).friend_id = friend5.friend_id;
                db.Friends.Find(friend5.friend_id).user_id = user.user_id;
                db.Friends.Find(friend5.friend_id).user_friend_id = friend.user_friend_id;
                db.Friends.Find(friend5.friend_id).friend_status = false;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            if (friend4 != null)
            {
                db.Friends.Find(friend4.friend_id).friend_status = null;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (friend3 != null)
            {
                db.Friends.Find(friend3.friend_id).friend_status = false;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (friend1 != null)
            {
                db.Friends.Find(friend1.friend_id).friend_status = null;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(friend2 != null)
            {
                friend.friend_status = true;
                db.Friends.Find(friend2.friend_id).friend_status = true;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                friend.user_id = user.user_id;
                friend.friend_status = false;
                db.Friends.Add(friend);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            
        }
        public ActionResult FriendUser()
        {
            User user = (User)Session["user"];
            if(user == null)
            {
                return Redirect("/Home/Index");
            }
            List<Friend> friend = db.Friends.Where(n => n.user_id == user.user_id && n.friend_status == true || n.user_friend_id == user.user_id && n.friend_status == true).ToList();
            ViewBag.SumFriend = friend.Count();
            return View(friend);
        }
        public PartialViewResult FriendConFirm()
        {
            User user = (User)Session["user"];
            List<Friend> friends = db.Friends.Where(n => n.user_friend_id == user.user_id && n.friend_status == false).ToList();
            return PartialView(friends);
        }
        public PartialViewResult SendFriend()
        {
            User user = (User)Session["user"];
            List<Friend> friends = db.Friends.Where(n => n.user_id == user.user_id && n.friend_status == false).ToList();
            return PartialView(friends);
        }
    }
}