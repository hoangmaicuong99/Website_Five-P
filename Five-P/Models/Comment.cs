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
    
    public partial class Comment
    {
        public int comment_id { get; set; }
        public string comment_content { get; set; }
        public Nullable<System.DateTime> comment_datecreated { get; set; }
        public Nullable<System.DateTime> comment_dateedit { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> comment_option { get; set; }
        public Nullable<int> reply_post_id { get; set; }
    
        public virtual Reply_Post Reply_Post { get; set; }
        public virtual User User { get; set; }
    }
}
