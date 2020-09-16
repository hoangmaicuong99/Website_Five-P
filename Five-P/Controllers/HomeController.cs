using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class HomeController : Controller
    {
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllQuestion()
        {
            List<Post> post = db.Posts.Where(n => n.post_activate_admin == true && n.post_activate == true).OrderByDescending(n=>n.post_datecreated).ToList();
            ViewBag.demCauHoi = post.Count();
            return View(post);
        }
        public ActionResult DetailQuestion(int? idpost)
        {
            //Thêm view
            db.Posts.Find(idpost).post_view++;
            db.SaveChanges();
            Post post = db.Posts.FirstOrDefault(n => n.post_id == idpost);
            return View(post);
        }
        //vow post trong chi tiết bài post
        [HttpPost]
        public ActionResult RatePostT(Rate_Post rate_Post)
        {
            User user = (User)Session["user"];
            Rate_Post ratePost = db.Rate_Post.Where(n => n.post_id == rate_Post.post_id && n.user_id == user.user_id).SingleOrDefault();
            if(ratePost == null)
            {
                rate_Post.user_id = user.user_id;
                rate_Post.rate_post1 = true;
                rate_Post.rate_post_datetime = DateTime.Now;
                db.Rate_Post.Add(rate_Post);
                db.SaveChanges();
                return View();
            }
            else if(ratePost.rate_post1 == true)
            {
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = null;
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = true;
                db.SaveChanges();
                return View();
            }
        }
        [HttpPost]
        public ActionResult RatePostF(Rate_Post rate_Post)
        {
            User user = (User)Session["user"];
            Rate_Post ratePost = db.Rate_Post.Where(n => n.post_id == rate_Post.post_id && n.user_id == user.user_id).SingleOrDefault();
            if (ratePost == null)
            {
                rate_Post.user_id = user.user_id;
                rate_Post.rate_post1 = false;
                rate_Post.rate_post_datetime = DateTime.Now;
                db.Rate_Post.Add(rate_Post);
                db.SaveChanges();
                return View();
            }
            else if (ratePost.rate_post1 == false)
            {
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = null;
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = false;
                db.SaveChanges();
                return View();
            }

        }
        //Lọc theo các danh mục thiết kế sẵn
        public PartialViewResult NewQuestion() 
        {
            List<Post> post = db.Posts.Where(n => n.post_activate_admin == true && n.post_activate == true).OrderByDescending(n => n.post_datecreated).ToList();
            return PartialView("_ViewQuestion", post);
        }
        public PartialViewResult NoAnswer()
        {
            List<Post> post = db.Posts.Where(n => n.post_activate_admin == true && n.post_activate == true && n.post_sum_reply == 0).OrderByDescending(n => n.post_datecreated).ToList();
            return PartialView("_ViewQuestion", post);
        }
        public PartialViewResult Views()
        {
            List<Post> post = db.Posts.Where(n => n.post_activate_admin == true && n.post_activate == true).OrderByDescending(n => n.post_view).ToList();
            return PartialView("_ViewQuestion", post);
        }
        public PartialViewResult Answer()
        {
            List<Post> post = db.Posts.Where(n => n.post_activate_admin == true && n.post_activate == true).OrderByDescending(n => n.post_sum_reply).ToList();
            return PartialView("_ViewQuestion", post);
        }
        //Hiển thị câu trả lời ở chi tiết câu trả lời
        public PartialViewResult ReplyPost(int? intPostId, int? intUserId)
        {
            ViewBag.userid = intUserId;
            List<Reply_Post> listReplyPost = db.Reply_Post.Where(n => n.post_id == intPostId && n.reply_post_activate == true).ToList();
            return PartialView(listReplyPost);
        }
        //vow post trong trả lời bài post
        [HttpPost]
        public ActionResult RateReplyPostT(Rate_Reply_Post rate_Reply_Post)
        {
            User user = (User)Session["user"];
            Rate_Reply_Post rateReplyPost = db.Rate_Reply_Post.Where(n => n.reply_post_id == rate_Reply_Post.reply_post_id && n.user_id == user.user_id).SingleOrDefault();
            if (rateReplyPost == null)
            {
                rate_Reply_Post.user_id = user.user_id;
                rate_Reply_Post.rate_reply_post1 = true;
                rate_Reply_Post.rate_reply_post_datetime = DateTime.Now;
                db.Rate_Reply_Post.Add(rate_Reply_Post);
                db.SaveChanges();
                return View();
            }
            else if (rateReplyPost.rate_reply_post1 == true)
            {
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = null;
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = true;
                db.SaveChanges();
                return View();
            }
        }






        //---------------------------------------
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}