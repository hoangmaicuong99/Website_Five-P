using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class TaiKhoanController : Controller
    {
        FivePEntities db = new FivePEntities();
        String Viewhome = "/";
        // GET: TaiKhoan
        public ActionResult TrangCaNhan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            String sEmail = f["user_email"].ToString();
            String sPass = f["user_pass"].ToString();
            User user = db.Users.Where(n => n.user_activate == true && n.user_role == 0).SingleOrDefault(n => n.user_email == sEmail && n.user_pass == sPass);
            if(user != null)
            {
                Session["NotLogin"] = null;
                Session["user"] = user;
                db.Users.Find(user.user_id).user_datelogin = DateTime.Now;
                db.Users.Find(user.user_id).user_token = Guid.NewGuid().ToString();
                db.SaveChanges();
                return Redirect(Viewhome);
            }
            else
            {
                Session["NotLogin"] = "<i class='fas fa-times-circle'>&nbsp;</i> Sai tài khoản hoặc mật khẩu!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        [HttpPost]
        public ActionResult Registration([Bind(Include = "user_id,user_pass,user_nicename,user_email,user_datecreated,user_token,user_role,user_datelogin,user_activate,user_phone,user_address,user_img")] User user)
        {
            user.user_nicename = null;
            user.user_datecreated = DateTime.Now;
            user.user_token = Guid.NewGuid().ToString();
            user.user_datelogin = DateTime.Now;
            user.user_role = 0;
            user.user_activate = true;
            user.user_phone = null;
            user.user_address = null;
            user.user_img = null;
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect(Request.Url.ToString());
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return Redirect(Viewhome);
        }
    }
}