//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Five_P.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reply_Post
    {
        public int reply_post_id { get; set; }
        public string reply_post_content { get; set; }
        public Nullable<System.DateTime> reply_post_datecreated { get; set; }
        public Nullable<System.DateTime> reply_post_dateedit { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<bool> reply_post_activate { get; set; }
        public Nullable<int> like_reply_post_id { get; set; }
    
        public virtual Like_Reply_Post Like_Reply_Post { get; set; }
        public virtual User User { get; set; }
    }
}