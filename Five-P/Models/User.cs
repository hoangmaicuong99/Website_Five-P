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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Friends = new HashSet<Friend>();
            this.Likes = new HashSet<Like>();
            this.Like_Reply_Post = new HashSet<Like_Reply_Post>();
            this.Posts = new HashSet<Post>();
            this.Rate_Post = new HashSet<Rate_Post>();
            this.Rate_Reply_Post = new HashSet<Rate_Reply_Post>();
            this.Reply_Post = new HashSet<Reply_Post>();
            this.Show_Activate_Post = new HashSet<Show_Activate_Post>();
            this.Technology_Care = new HashSet<Technology_Care>();
            this.Tick_Post = new HashSet<Tick_Post>();
            this.Friends1 = new HashSet<Friend>();
            this.Reviews_User = new HashSet<Reviews_User>();
            this.Reviews_User1 = new HashSet<Reviews_User>();
        }
    
        public int user_id { get; set; }
        public string user_pass { get; set; }
        public string user_nicename { get; set; }
        public string user_email { get; set; }
        public Nullable<System.DateTime> user_datecreated { get; set; }
        public string user_token { get; set; }
        public Nullable<int> user_role { get; set; }
        public Nullable<System.DateTime> user_datelogin { get; set; }
        public Nullable<bool> user_activate { get; set; }
        public Nullable<int> user_phone { get; set; }
        public string user_address { get; set; }
        public string user_img { get; set; }
        public Nullable<int> user_sex { get; set; }
        public string user_link_facebok { get; set; }
        public string user_link_github { get; set; }
        public string user_hobby_work { get; set; }
        public string user_hobby { get; set; }
        public Nullable<bool> user_activate_admin { get; set; }
        public Nullable<System.DateTime> user_date_born { get; set; }
        public Nullable<int> user_popular { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like_Reply_Post> Like_Reply_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate_Post> Rate_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate_Reply_Post> Rate_Reply_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply_Post> Reply_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show_Activate_Post> Show_Activate_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Technology_Care> Technology_Care { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tick_Post> Tick_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews_User> Reviews_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews_User> Reviews_User1 { get; set; }
    }
}
