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
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Likes = new HashSet<Like>();
            this.Rate_Post = new HashSet<Rate_Post>();
            this.Reply_Post = new HashSet<Reply_Post>();
            this.Show_Activate_Post = new HashSet<Show_Activate_Post>();
            this.Tick_Post = new HashSet<Tick_Post>();
            this.Technology_Post = new HashSet<Technology_Post>();
        }
    
        public int post_id { get; set; }
        public string post_content { get; set; }
        public string post_img { get; set; }
        public Nullable<System.DateTime> post_datecreated { get; set; }
        public Nullable<System.DateTime> post_dateedit { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<bool> post_activate { get; set; }
        public Nullable<bool> post_activate_admin { get; set; }
        public string post_title { get; set; }
        public Nullable<int> post_sum_reply { get; set; }
        public Nullable<int> post_sum_comment { get; set; }
        public Nullable<int> post_view { get; set; }
        public Nullable<int> post_popular { get; set; }
        public Nullable<int> post_calculate_medal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate_Post> Rate_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply_Post> Reply_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show_Activate_Post> Show_Activate_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tick_Post> Tick_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Technology_Post> Technology_Post { get; set; }
    }
}
