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
    
    public partial class Reply_Comment
    {
        public int reply_comment_id { get; set; }
        public string reply_comment_content { get; set; }
        public Nullable<System.DateTime> reply_comment_datecreated { get; set; }
        public Nullable<System.DateTime> reply_comment_dateedit { get; set; }
        public Nullable<int> comment_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> reply_comment_option { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}