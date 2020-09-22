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
        // GET: Post
        FivePEntities db = new FivePEntities();
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ReplyPost([Bind(Include = "reply_post_id,reply_post_content,reply_post_datecreated,reply_post_dateedit,user_id,reply_post_activate,like_reply_post_id,post_id,reply_post_title")] Reply_Post reply_Post)
        {
            User user = (User)Session["user"];
            reply_Post.reply_post_datecreated = DateTime.Now;
            reply_Post.reply_post_dateedit = DateTime.Now;
            reply_Post.user_id = user.user_id;
            reply_Post.reply_post_activate = true;
            db.Reply_Post.Add(reply_Post);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}