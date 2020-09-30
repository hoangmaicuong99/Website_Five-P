using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class PostController : Controller
    {
        String pageManageUser = "/Account/ManageUser";
        String pageHome = "/Home/Index";
        // GET: Post
        FivePEntities db = new FivePEntities();
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ReplyPost([Bind(Include = "reply_post_id,reply_post_content,reply_post_datecreated,reply_post_dateedit,user_id,reply_post_activate,like_reply_post_id,post_id,reply_post_title")] Reply_Post reply_Post)
        {
            User user = (User)Session["user"];
            Reply_Post userReplyPost = db.Reply_Post.FirstOrDefault(n => n.user_id == user.user_id && n.post_id == reply_Post.post_id);
            //user
            if(userReplyPost == null)
            {
                db.Users.Find(user.user_id).user_popular += db.Posts.Find(reply_Post.post_id).post_popular;
            }
            //Bài viết
            db.Posts.Find(reply_Post.post_id).post_sum_reply++;
            db.Posts.Find(reply_Post.post_id).post_popular++;
            //Trả lời bài viết
            reply_Post.reply_post_datecreated = DateTime.Now;
            reply_Post.reply_post_dateedit = DateTime.Now;
            reply_Post.user_id = user.user_id;
            reply_Post.reply_post_activate = true;
            db.Reply_Post.Add(reply_Post);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Post()
        {
            ViewBag.dataTechnologys = db.Technologies.ToList();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Post([Bind(Include = "post_id,post_content,post_img,post_datecreated,post_dateedit,user_id,post_activate,post_activate_admin,post_title,post_sum_reply,post_sum_comment,post_view,post_popular,post_calculate_medal")] Post post, int[] postTechnology)
        {
            User user = (User)Session["user"];
            foreach(var item in postTechnology)
            {
                Technology_Post tp = new Technology_Post()
                {
                    post_id = post.post_id,
                    technology_id = item
                };
                db.Technology_Post.Add(tp);
            }
            post.post_img = null;
            post.post_datecreated = DateTime.Now;
            post.post_dateedit = DateTime.Now;
            post.user_id = user.user_id;
            post.post_activate = true;
            post.post_activate_admin = true;
            post.post_sum_reply = 0;
            post.post_sum_comment = 0;
            post.post_view = 0;
            post.post_popular = 0;
            post.post_calculate_medal = 0;
            db.Posts.Add(post);
            db.SaveChanges();
            return Redirect(pageManageUser);
        }
        //quản lý bài viết
        public ActionResult PostManagement()
        {
            User user = (User)Session["user"];
            List<Post> post = db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).ToList(); 
            return View(post);
        }
    }
}