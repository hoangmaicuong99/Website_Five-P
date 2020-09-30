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
        String Viewhome = "/Home/Index";
        String AllQuestion = "/Home/AllQuestion";
        String strRegisterPersonalInformation = "/Account/RegisterPersonalInformation";
        // GET: TaiKhoan
        public ActionResult UserPage(int? idUser)
        {
            User user = db.Users.Where(n=>n.user_activate == true && n.user_activate_admin == true).FirstOrDefault(n => n.user_id == idUser);
            return View(user);
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
                Session["NotRegistration"] = null;
                Session["user"] = user;
                db.Users.Find(user.user_id).user_datelogin = DateTime.Now;
                db.Users.Find(user.user_id).user_token = Guid.NewGuid().ToString();
                db.SaveChanges();
                return Redirect(AllQuestion);
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
                Session["NotLogin"] = null;
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
        public PartialViewResult ShowAllPostOneUser(int? idUser)
        {
            List<Post> listPost = db.Posts.Where(n => n.user_id == idUser && n.post_activate_admin == true && n.post_activate == true).ToList();
            return PartialView(listPost);
        }
        public ActionResult ManageUser()
        {
            int coutViewPost = 0;
            User user = (User)Session["user"];
            if(user == null)
            {
                return View("/Home/Index");
            }
            else
            {
                List<Reply_Post> replyPost = db.Reply_Post.Where(n => n.user_id == user.user_id).ToList();
                List<Comment> comment = db.Comments.Where(n => n.user_id == user.user_id).ToList();
                List<Post> ViewPost = db.Posts.Where(n => n.user_id == user.user_id).ToList();
                List<Post> coutMyPost = db.Posts.Where(n => n.user_id == user.user_id).ToList();
                List<Reply_Post> replyMyPost = db.Reply_Post.Where(n => n.Post.user_id == user.user_id).ToList();
                List<Comment> coutCommentMyPost = db.Comments.Where(n => n.Reply_Post.user_id == user.user_id).ToList();
                List<Rate_Post> ratePost = db.Rate_Post.Where(n => n.Post.user_id == user.user_id).ToList();
                List<Tick_Post> tickMyPost = db.Tick_Post.Where(n => n.user_id == user.user_id).ToList();
                List<Show_Activate_Post> showActivatePost = db.Show_Activate_Post.Where(n => n.user_id == user.user_id).ToList();
                List<Show_Activate_Reply_Post> showActivateReplyPost = db.Show_Activate_Reply_Post.Where(n => n.user_id == user.user_id).ToList();
                List<Reply_Post> replyMyPostUnder10 = db.Reply_Post.Where(n => n.Post.user_id == user.user_id && n.reply_post_popular < 10).ToList();
                List<Reply_Post> replyMyPostUnder20 = db.Reply_Post.Where(n => n.Post.user_id == user.user_id && n.reply_post_popular < 20 && n.reply_post_popular > 10).ToList();
                List<Reply_Post> replyMyPostUnder40 = db.Reply_Post.Where(n => n.Post.user_id == user.user_id && n.reply_post_popular < 40 && n.reply_post_popular > 20).ToList();
                List<Reply_Post> replyMyPostAbove70 = db.Reply_Post.Where(n => n.Post.user_id == user.user_id && n.reply_post_popular > 70).ToList();
                List<Reply_Post> replyMyPostUnder1 = db.Reply_Post.Where(n => n.Post.user_id == user.user_id && n.reply_post_popular < 1).ToList();
                List<Post> postUnder10 = db.Posts.Where(n => n.user_id == user.user_id && n.post_popular < 10).ToList();
                List<Post> postUnder20 = db.Posts.Where(n => n.user_id == user.user_id && n.post_popular < 20 && n.post_popular > 10).ToList();
                List<Post> postAbove40 = db.Posts.Where(n => n.user_id == user.user_id && n.post_popular > 40).ToList();
                List<Post> postUnder1 = db.Posts.Where(n => n.user_id == user.user_id && n.post_popular < 1).ToList();

                foreach (var item in ViewPost)
                {
                    coutViewPost += (int)item.post_view;
                }
                // [ Bài viết bạn đã quan tâm ]
                ViewBag.CoutReplyPost = replyPost.Count();
                ViewBag.CoutMyComment = comment.Count();
                // [ Bài viết của bạn ]
                ViewBag.coutViewPost = coutViewPost;
                ViewBag.CoutMyPost = coutMyPost.Count();
                ViewBag.coutRepyMyPost = replyMyPost.Count();
                ViewBag.coutCommentMyPost = coutCommentMyPost.Count();
                ViewBag.postUnder10 = postUnder10.Count();
                ViewBag.postUnder20 = postUnder20.Count();
                ViewBag.postAbove40 = postAbove40.Count();
                ViewBag.postUnder1 = postUnder1.Count();
                //[ Bài viết ]
                ViewBag.ratePost = ratePost.Count();
                // [ Bài viết đã đánh dấu ]
                ViewBag.tickMyPost = tickMyPost.Count();
                // Hoạt động bài viết bạn đã đánh giấu ]
                ViewBag.showActivatePost = showActivatePost.Count();
                ViewBag.showActivateReplyPost = showActivateReplyPost.Count();
                //[ Trả lời bài viết của bạn được đề xuất cao]
                ViewBag.replyMyPostUnder10 = replyMyPostUnder10.Count();
                ViewBag.replyMyPostUnder20 = replyMyPostUnder20.Count();
                ViewBag.replyMyPostUnder40 = replyMyPostUnder40.Count();
                ViewBag.replyMyPostAbove70 = replyMyPostAbove70.Count();
                ViewBag.replyMyPostUnder1 = replyMyPostUnder1.Count();
                return View(db.Users.Find(user.user_id));
            }
        }
    }
}