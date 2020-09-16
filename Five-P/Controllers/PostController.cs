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
        [HttpPost]
        public ActionResult RatePostT([Bind(Include = "rate_post_id,user_id,post_id,rate_post1,rate_post_datetime")] Rate_Post rate_Post)
        {
            db.Rate_Post.Add(rate_Post);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}