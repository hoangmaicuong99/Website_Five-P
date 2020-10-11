using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Post(int? idPost)
        {
            if(idPost == null)
            {
                ViewBag.dataTechnologys = db.Technologies.ToList();
                return View();
            }
            else
            {
                ViewBag.dataTechnologys = db.Technologies.ToList();
                Post post = db.Posts.FirstOrDefault(n => n.post_id == idPost);
                return View(post);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Post([Bind(Include = "post_id,post_content,post_img,post_datecreated,post_dateedit,user_id,post_activate,post_activate_admin,post_title,post_sum_reply,post_sum_comment,post_view,post_popular,post_calculate_medal")] Post post, int[] postTechnology)
        {
            User user = (User)Session["user"];
            if(post.post_datecreated != null && user != null)
            {
                List<Technology_Post> listRemove = db.Technology_Post.Where(n => n.post_id == post.post_id).ToList();
                foreach (var item in listRemove)
                {
                    db.Technology_Post.Remove(db.Technology_Post.Find(item.post_technology_id));
                }
                foreach (var item in postTechnology)
                {
                    Technology_Post tp = new Technology_Post()
                    {
                        post_id = post.post_id,
                        technology_id = item
                    };
                    db.Technology_Post.Add(tp);
                }
                post.post_img = null;
                post.post_datecreated = post.post_datecreated;
                post.post_dateedit = DateTime.Now;
                post.user_id = user.user_id;
                post.post_activate = post.post_activate;
                post.post_activate_admin = post.post_activate_admin;
                post.post_sum_reply = post.post_sum_reply;
                post.post_sum_comment = post.post_sum_comment;
                post.post_view = post.post_view;
                post.post_popular = post.post_popular;
                post.post_calculate_medal = post.post_calculate_medal;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(pageManageUser);
            }
            else if(post.post_datecreated == null && user != null)
            {
                foreach (var item in postTechnology)
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
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }
        //quản lý bài viết
        public ActionResult PostManagement()
        {
            User user = (User)Session["user"];
            if(user == null)
            {
                return Redirect(pageHome);
            }
            List<Post> post = db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).ToList(); 
            return View(post);
        }
        [HttpPost]
        public ActionResult ActivatePost(Post post)
        {
            if(post.post_activate == true)
            {
                db.Posts.Find(post.post_id).post_activate = false;
                db.SaveChanges();
            }
            else if(post.post_activate == false)
            {
                db.Posts.Find(post.post_id).post_activate = true;
                db.SaveChanges();
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpDelete]
        public ActionResult DeletePost(int idPost)
        {
            List<Rate_Post> deleteRatePost = db.Rate_Post.Where(n => n.post_id == idPost).ToList();
            foreach(var item in deleteRatePost)
            {
                db.Rate_Post.Remove(db.Rate_Post.Find(item.rate_post_id));
            }
            List<Technology_Post> deleteTechnologyPost = db.Technology_Post.Where(n => n.post_id == idPost).ToList();
            foreach(var item in deleteTechnologyPost)
            {
                db.Technology_Post.Remove(db.Technology_Post.Find(item.post_technology_id));
            }
            List<Tick_Post> deleteTickPost = db.Tick_Post.Where(n => n.post_id == idPost).ToList();
            foreach(var item in deleteTickPost)
            {
                db.Tick_Post.Remove(db.Tick_Post.Find(item.tick_post_id));
            }
            List<Show_Activate_Post> deleteActivatePost = db.Show_Activate_Post.Where(n => n.post_id == idPost).ToList();
            foreach(var item in deleteActivatePost)
            {
                db.Show_Activate_Post.Remove(db.Show_Activate_Post.Find(item.show_activate_post_id));
            }
            //Xóa trả lời bài viết phải xóa các bảng mà có replypost
            List<Reply_Post> deleteRepLyPost = db.Reply_Post.Where(n => n.post_id == idPost).ToList();
            foreach(var item in deleteRepLyPost)
            {
                List<Comment> deleteComment = db.Comments.Where(n => n.reply_post_id == item.reply_post_id).ToList();
                foreach(var item2 in deleteComment)
                {
                    db.Comments.Remove(db.Comments.Find(item2.comment_id));
                }
                List<Show_Activate_Reply_Post> deleteActivateReplyPost = db.Show_Activate_Reply_Post.Where(n => n.reply_post_id == item.reply_post_id).ToList();
                foreach(var item2 in deleteActivateReplyPost)
                {
                    db.Show_Activate_Reply_Post.Remove(db.Show_Activate_Reply_Post.Find(item2.show_activate_reply_post_id));
                }
                List<Rate_Reply_Post> deleteRateReplyPost = db.Rate_Reply_Post.Where(n => n.reply_post_id == item.reply_post_id).ToList();
                foreach(var item2 in deleteRateReplyPost)
                {
                    db.Rate_Reply_Post.Remove(db.Rate_Reply_Post.Find(item2.rate_reply_post_id));
                }
                db.Reply_Post.Remove(db.Reply_Post.Find(item.reply_post_id));
            }
            db.SaveChanges();
            Post post = db.Posts.Find(idPost);
            if(post!= null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
            return View();
        }
        //Sắp xếp
        public PartialViewResult New()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement",db.Posts.Where(n=>n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n=>n.post_datecreated).ToList());
        }
        public PartialViewResult Popular()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n => n.post_popular).ToList());
        }
        public PartialViewResult NotFamous()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_popular).ToList());
        }
        public PartialViewResult ReplyAlot()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n => n.post_sum_reply).ToList());
        }
        public PartialViewResult LittleReply()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_sum_reply).ToList());
        }
        public PartialViewResult CommentAlot()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n => n.post_sum_comment).ToList());
        }
        public PartialViewResult LittleComment()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_sum_comment).ToList());
        }
        public PartialViewResult ViewAlot()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n => n.post_view).ToList());
        }
        public PartialViewResult LittleView()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_view).ToList());
        }
        public PartialViewResult StatusTurnOn()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true && n.post_activate == true).OrderByDescending(n => n.post_datecreated).ToList());
        }
        public PartialViewResult StatusTurnOff()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true && n.post_activate == false).OrderByDescending(n => n.post_datecreated).ToList());
        }
        public PartialViewResult Name()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_title).ToList());
        }
        public PartialViewResult OldDateTime()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderBy(n => n.post_datecreated).ToList());
        }
        public PartialViewResult DateTimeEdit()
        {
            System.Threading.Thread.Sleep(2000);
            User user = (User)Session["user"];
            return PartialView("_SortPostManagement", db.Posts.Where(n => n.user_id == user.user_id && n.post_activate_admin == true).OrderByDescending(n => n.post_dateedit).ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}