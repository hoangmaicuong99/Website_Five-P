using System;
using System.Collections.Generic;
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
            Post post = db.Posts.FirstOrDefault(n => n.post_id == idpost);
            //Thêm view
            db.Posts.Find(idpost).post_view++;
            db.SaveChanges();
            return View(post);
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