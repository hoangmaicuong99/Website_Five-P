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
    
    public partial class Image_Advertisement
    {
        public int image_advertisement_id { get; set; }
        public string image_advertisement1 { get; set; }
        public Nullable<int> advertisement_id { get; set; }
    
        public virtual Advertisement Advertisement { get; set; }
    }
}
