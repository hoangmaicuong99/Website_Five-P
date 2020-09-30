using Five_P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Five_P.Controllers
{
    public class CommentReplyPostController : Controller
    {
        // GET: CommentReplyPost
        FivePEntities db = new FivePEntities();
        public PartialViewResult Comment(int? idReplyPost)
        {
            List<Comment> comment = db.Comments.Where(n => n.reply_post_id == idReplyPost).ToList();
            return PartialView(comment);
        }
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            //sum comment
            var idReplyPost = comment.reply_post_id;
            var idPost = db.Reply_Post.Find(idReplyPost).post_id.Value;
            db.Posts.Find(idPost).post_sum_comment++;
            db.Posts.Find(idPost).post_popular++;
            //comment
            User user = (User)Session["user"];
            comment.comment_datecreated = DateTime.Now;
            comment.comment_dateedit = DateTime.Now;
            comment.comment_option = 0;
            comment.user_id = user.user_id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return View(comment);
        }
    }
}