using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;
using Microsoft.Ajax.Utilities;

namespace Five_P.Controllers
{
    public class HomeController : Controller
    {
        String strHome = "Index";
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BackRegistration()
        {
            Session["NotRegistration"] = "Đăng ký để đăng câu hỏi ^_^";
            return RedirectToAction(strHome);
        }
        public ActionResult BackLogin()
        {
            Session["NotLogin"] = "Nhập tài khoản mật khẩu";
            return RedirectToAction("Index");
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
            db.Posts.Find(idpost).post_popular++;
            db.SaveChanges();
            Post post = db.Posts.FirstOrDefault(n => n.post_id == idpost);
            return View(post);
        }
        //Đánh giấu bài viết tick post
        [HttpPost]
        public ActionResult SaveTickPost(Tick_Post tick_Post)
        {
            User user = (User)Session["user"];
            Tick_Post tickPost = db.Tick_Post.Where(n => n.post_id == tick_Post.post_id && n.user_id == user.user_id).FirstOrDefault();
            if(tickPost == null)
            {
                db.Posts.Find(tick_Post.post_id).post_popular++;
                tick_Post.user_id = user.user_id;
                tick_Post.tick_post_datetime = DateTime.Now;
                db.Tick_Post.Add(tick_Post);
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Posts.Find(tick_Post.post_id).post_popular--;
                db.Tick_Post.Remove(db.Tick_Post.Find(tickPost.tick_post_id));
                db.SaveChanges();
                return View();
            }
        }
        //Hiển thị hoạt động của bài viết
        [HttpPost]
        public ActionResult SaveShowActivatePost(Show_Activate_Post show_Activate_Post)
        {
            User user = (User)Session["user"];
            Show_Activate_Post showActivatePost = db.Show_Activate_Post.FirstOrDefault(n => n.post_id == show_Activate_Post.post_id && n.user_id == user.user_id);
            if(showActivatePost == null)
            {
                db.Posts.Find(show_Activate_Post.post_id).post_popular++;
                show_Activate_Post.user_id = user.user_id;
                show_Activate_Post.show_activate_post_datetime = DateTime.Now;
                show_Activate_Post.show_activate_post_Readed = true;
                db.Show_Activate_Post.Add(show_Activate_Post);
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Posts.Find(show_Activate_Post.post_id).post_popular--;
                db.Show_Activate_Post.Remove(db.Show_Activate_Post.Find(showActivatePost.show_activate_post_id));
                db.SaveChanges();
                return View();
            }
            
        }
        //vow post trong chi tiết bài post
        [HttpPost]
        public ActionResult RatePostT(Rate_Post rate_Post)
        {
            User user = (User)Session["user"];
            Rate_Post ratePost = db.Rate_Post.Where(n => n.post_id == rate_Post.post_id && n.user_id == user.user_id).SingleOrDefault();
            if(ratePost == null)
            {
                db.Posts.Find(rate_Post.post_id).post_popular++;
                db.Posts.Find(rate_Post.post_id).post_calculate_medal++;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if (postCalulateMedal == 4)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 8)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 15)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                }
                else if(postCalulateMedal == 30)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                }
                //Lưu đánh giá của bài viết
                rate_Post.user_id = user.user_id;
                rate_Post.rate_post1 = true;
                rate_Post.rate_post_datetime = DateTime.Now;
                db.Rate_Post.Add(rate_Post);
                db.SaveChanges();
                return View();
            }
            else if(ratePost.rate_post1 == true)
            {
                db.Posts.Find(rate_Post.post_id).post_calculate_medal--;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if (postCalulateMedal == 3)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if (postCalulateMedal == 7)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 14)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                }
                else if(postCalulateMedal == 29)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal--;
                }
                //Đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular--;
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = null;
                db.SaveChanges();
                return View();
            }
            else if(ratePost.rate_post1 == null)
            {
                db.Posts.Find(rate_Post.post_id).post_calculate_medal++;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if (postCalulateMedal == 4)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if (postCalulateMedal == 8)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if (postCalulateMedal == 15)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                }
                else if (postCalulateMedal == 30)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                }
                // lưu đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular++;
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = true;
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Posts.Find(rate_Post.post_id).post_calculate_medal +=2;
                db.SaveChanges();
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if(postCalulateMedal == 4 || postCalulateMedal == 5)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 8 || postCalulateMedal == 9)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 15 || postCalulateMedal == 16)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                }
                else if(postCalulateMedal == 30 || postCalulateMedal == 31)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal++;
                }
                db.Posts.Find(rate_Post.post_id).post_popular +=2;
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
                //tính huy chương user
                db.Posts.Find(rate_Post.post_id).post_calculate_medal--;
                db.SaveChanges();
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if(postCalulateMedal == 3)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 7)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 14)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                }
                else if(postCalulateMedal == 29)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                }
                //Lưu đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular--;
                rate_Post.user_id = user.user_id;
                rate_Post.rate_post1 = false;
                rate_Post.rate_post_datetime = DateTime.Now;
                db.Rate_Post.Add(rate_Post);
                db.SaveChanges();
                return View();
            }
            else if (ratePost.rate_post1 == false)
            {
                //Tính huy chương cho user
                db.Posts.Find(rate_Post.post_id).post_calculate_medal++;
                db.SaveChanges();
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if(postCalulateMedal == 4)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 8)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 15)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                }
                else if(postCalulateMedal == 30)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                }
                //Lưu đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular++;
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = null;
                db.SaveChanges();
                return View();
            }
            else if(ratePost.rate_post1 == null)
            {
                //Lưu Huy chương user
                db.Posts.Find(rate_Post.post_id).post_calculate_medal--;
                db.SaveChanges();
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if(postCalulateMedal == 3)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 7)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 14)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                }
                else if(postCalulateMedal == 29)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                }
                //Lưu đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular--;
                db.Rate_Post.Find(ratePost.rate_post_id).rate_post1 = false;
                db.SaveChanges();
                return View();
            }
            else
            {
                //tính huy chương user
                db.Posts.Find(rate_Post.post_id).post_calculate_medal -= 2;
                db.SaveChanges();
                var postCalulateMedal = db.Posts.Find(rate_Post.post_id).post_calculate_medal;
                if(postCalulateMedal == 3 || postCalulateMedal == 2)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal--;
                }
                else if(postCalulateMedal == 7 || postCalulateMedal == 6)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_bronze_medal++;
                }
                else if(postCalulateMedal == 14 || postCalulateMedal == 13)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_silver_medal++;
                }
                else if(postCalulateMedal == 29 || postCalulateMedal == 28)
                {
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Posts.Find(rate_Post.post_id).user_id).user_gold_medal++;
                }
                //Luu đánh giá
                db.Posts.Find(rate_Post.post_id).post_popular -=2;
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
                //Lưu đánh giá huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal++;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 4)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 8)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 15)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                }
                else if (replyPostCalculateMedal == 30)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                }
                //lưu đánh giá bài trả lời
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular++;
                rate_Reply_Post.user_id = user.user_id;
                rate_Reply_Post.rate_reply_post1 = true;
                rate_Reply_Post.rate_reply_post_datetime = DateTime.Now;
                db.Rate_Reply_Post.Add(rate_Reply_Post);
                db.SaveChanges();
                return View();
            }
            else if (rateReplyPost.rate_reply_post1 == true)
            {
                //Lưu huy chương người dùng
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal--;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 3)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 7)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 14)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                }
                else if (replyPostCalculateMedal == 29)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal--;
                }
                //Lưu đánh giá trả lời bài viết
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular--;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = null;
                db.SaveChanges();
                return View();
            }
            else if(rateReplyPost.rate_reply_post1 == null)
            {
                //Lưu huy chương người dùng
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal++;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 4)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 8)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 15)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                }
                else if (replyPostCalculateMedal == 30)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                }
                //Lưu đánh giá bài viết
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular++;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = true;
                db.SaveChanges();
                return View();
            }
            else
            {
                //Lưu huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal +=2;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 4 || replyPostCalculateMedal == 5)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 8 || replyPostCalculateMedal == 9)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 15 || replyPostCalculateMedal == 16)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                }
                else if (replyPostCalculateMedal == 30 || replyPostCalculateMedal == 31)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal++;
                }
                //Lưu đánh giá 
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular +=2;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = true;
                db.SaveChanges();
                return View();
            }
        }
        [HttpPost]
        public ActionResult RateReplyPostF(Rate_Reply_Post rate_Reply_Post)
        {
            User user = (User)Session["user"];
            Rate_Reply_Post rateReplyPost = db.Rate_Reply_Post.Where(n => n.reply_post_id == rate_Reply_Post.reply_post_id && n.user_id == user.user_id).SingleOrDefault();
            if (rateReplyPost == null)
            {
                //Lưu huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal--;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 3)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 7)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 14)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                }
                else if (replyPostCalculateMedal == 29)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                }
                //Lưu đánh giá
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular--;
                rate_Reply_Post.user_id = user.user_id;
                rate_Reply_Post.rate_reply_post1 = false;
                rate_Reply_Post.rate_reply_post_datetime = DateTime.Now;
                db.Rate_Reply_Post.Add(rate_Reply_Post);
                db.SaveChanges();
                return View();
            }
            else if (rateReplyPost.rate_reply_post1 == false)
            {
                //Lưu huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal++;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 4)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 8)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 15)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                }
                else if (replyPostCalculateMedal == 30)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal++;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                }
                //Lưu đánh giá
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular++;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = null;
                db.SaveChanges();
                return View();
            }
            else if(rateReplyPost.rate_reply_post1 == null)
            {
                //Lưu huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal--;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 3)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 7)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 14)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                }
                else if (replyPostCalculateMedal == 29)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                }
                //Lưu đánh giá
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular--;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = false;
                db.SaveChanges();
                return View();
            }
            else
            {
                //Lưu huy chương
                db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal -=2;
                db.SaveChanges();
                var replyPostCalculateMedal = db.Reply_Post.Find(rate_Reply_Post.reply_post_id).reply_post__calculate_medal;
                if (replyPostCalculateMedal == 3 || replyPostCalculateMedal == 2)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal--;
                }
                else if (replyPostCalculateMedal == 7 || replyPostCalculateMedal == 6)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_bronze_medal++;
                }
                else if (replyPostCalculateMedal == 14 || replyPostCalculateMedal == 13)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_silver_medal++;
                }
                else if (replyPostCalculateMedal == 29 || replyPostCalculateMedal == 28)
                {
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_vip_medal--;
                    db.Users.Find(db.Reply_Post.Find(rate_Reply_Post.reply_post_id).user_id).user_gold_medal++;
                }
                //Lưu đánh giá
                var idRepLyPost = rate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idRepLyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular -= 2;
                db.Rate_Reply_Post.Find(rateReplyPost.rate_reply_post_id).rate_reply_post1 = false;
                db.SaveChanges();
                return View();
            }
        }
        [HttpPost]
        public ActionResult ShowActivateReplyPost(Show_Activate_Reply_Post show_Activate_Reply_Post)
        {
            User user = (User)Session["user"];
            Show_Activate_Reply_Post showActivateReplyPost = db.Show_Activate_Reply_Post.Where(n => n.reply_post_id == show_Activate_Reply_Post.reply_post_id && n.user_id == user.user_id).FirstOrDefault();
            if(showActivateReplyPost == null)
            {
                var idReplyPost = show_Activate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idReplyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular++;
                show_Activate_Reply_Post.show_activate_reply_post_datetime = DateTime.Now;
                show_Activate_Reply_Post.show_activate_reply_post_readed = true;
                show_Activate_Reply_Post.user_id = user.user_id;
                db.Show_Activate_Reply_Post.Add(show_Activate_Reply_Post);
                db.SaveChanges();
                return View();
            }
            else
            {
                var idReplyPost = show_Activate_Reply_Post.reply_post_id;
                var idPost = db.Reply_Post.Find(idReplyPost).post_id.Value;
                db.Posts.Find(idPost).post_popular--;
                db.Show_Activate_Reply_Post.Remove(db.Show_Activate_Reply_Post.Find(showActivateReplyPost.show_activate_reply_post_id));
                db.SaveChanges();
                return View();
            }
            
        }
        //comment
        [HttpPost]
        public ActionResult CommentHttpost(Comment comment)
        {
            User user = (User)Session["user"];
            comment.comment_datecreated = DateTime.Now;
            comment.comment_dateedit = DateTime.Now;
            comment.comment_option = 0;
            comment.user_id = user.user_id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return View();
        }
        public PartialViewResult Notification()
        {
            return PartialView();
        }
        public ActionResult FalseNotification(int? idNotification)
        {
            db.Notifications.Find(idNotification).notification_status = false;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
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