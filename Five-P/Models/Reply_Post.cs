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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reply_Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Rate_Reply_Post = new HashSet<Rate_Reply_Post>();
            this.Show_Activate_Reply_Post = new HashSet<Show_Activate_Reply_Post>();
        }
    
        public int reply_post_id { get; set; }
        public string reply_post_content { get; set; }
        public Nullable<System.DateTime> reply_post_datecreated { get; set; }
        public Nullable<System.DateTime> reply_post_dateedit { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<bool> reply_post_activate { get; set; }
        public Nullable<int> like_reply_post_id { get; set; }
        public Nullable<int> post_id { get; set; }
        public string reply_post_title { get; set; }
        public Nullable<int> reply_post_popular { get; set; }
        public Nullable<int> reply_post__calculate_medal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Like_Reply_Post Like_Reply_Post { get; set; }
        public virtual Post Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate_Reply_Post> Rate_Reply_Post { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show_Activate_Reply_Post> Show_Activate_Reply_Post { get; set; }
    }
}
