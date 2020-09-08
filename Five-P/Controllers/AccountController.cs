using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        FivePEntities db = new FivePEntities();
        String Viewhome = "/";
        String strRegisterPersonalInformation = "/Account/RegisterPersonalInformation";
        // GET: TaiKhoan
        public ActionResult UserPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            String sEmail = f["user_email"].ToString();
            String sPass = f["user_pass"].ToString();
            User user = db.Users.Where(n => n.user_activate == true && n.user_role == 0 && n.user_activate_admin == true).SingleOrDefault(n => n.user_email == sEmail && n.user_pass == sPass);
            if (user != null)
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
                Session["NotRegistration"] = null;
                Session["NotLogin"] = "<i class='fas fa-times-circle'>&nbsp;</i> Sai tài khoản hoặc mật khẩu!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        [HttpPost]
        public ActionResult Registration([Bind(Include = "user_id,user_pass,user_nicename,user_email,user_datecreated,user_token,user_role,user_datelogin,user_activate,user_phone,user_address,user_img,user_sex,user_link_facebok,user_link_github,user_hobby_work,user_hobby,user_activate_admin,user_date_born")] User user)
        {
            User ruser = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
            if (ruser == null)
            {
                user.user_activate_admin = true;
                user.user_datecreated = DateTime.Now;
                user.user_token = Guid.NewGuid().ToString();
                user.user_datelogin = DateTime.Now;
                user.user_role = 0;
                user.user_activate = true;
                db.Users.Add(user);
                db.SaveChanges();
                Session["NotRegistration"] = null;
                Session["user"] = user;
                return Redirect(strRegisterPersonalInformation);
            }
            else
            {
                Session["NotLogin"] = null;
                Session["NotRegistration"] = "<i class='fas fa-times-circle'>&nbsp;</i> Emai đã được đăng ký !";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return Redirect(Viewhome);
        }
        public ActionResult RegisterPersonalInformation()
        {
            User sesUser = (User)Session["user"];
            User user = db.Users.Find(sesUser.user_id);
            return View(user);
        }
        [HttpPost]
        public ActionResult RegisterPersonalInformation([Bind(Include = "user_id,user_pass,user_nicename,user_email,user_datecreated,user_token,user_role,user_datelogin,user_activate,user_phone,user_address,user_img,user_sex,user_link_facebok,user_link_github,user_hobby_work,user_hobby,user_activate_admin,user_date_born")] User user,HttpPostedFileBase fileImg)
        {
            User sesUser = (User)Session["user"];
            if (fileImg == null)
            {
                user.user_id = sesUser.user_id;
                user.user_pass = sesUser.user_pass;
                user.user_datecreated = sesUser.user_datecreated;
                user.user_token = sesUser.user_token;
                user.user_role = sesUser.user_role;
                user.user_datelogin = sesUser.user_datelogin;
                user.user_activate = sesUser.user_activate;
                user.user_activate_admin = sesUser.user_activate_admin;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Viewhome);
            }
            var fileimg = Path.GetFileName(fileImg.FileName);
            var pa = Path.Combine(Server.MapPath("~/Content/LayoutNguoiDung/ImgUser"), fileimg);
            if (System.IO.File.Exists(pa))
            {
                ViewBag.tbImg = "Hình ảnh đã tồn tại!";
            }
            else
            {
                fileImg.SaveAs(pa);
                user.user_img = fileImg.FileName;
                user.user_id = sesUser.user_id;
                user.user_pass = sesUser.user_pass;
                user.user_datecreated = sesUser.user_datecreated;
                user.user_token = sesUser.user_token;
                user.user_role = sesUser.user_role;
                user.user_datelogin = sesUser.user_datelogin;
                user.user_activate = sesUser.user_activate;
                user.user_activate_admin = sesUser.user_activate_admin;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Viewhome);
            }
            return View(user);
        }
        public ActionResult ManageUser()
        {
            return View();
        }
    }
}