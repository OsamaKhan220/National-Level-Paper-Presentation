//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ksc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityWinner
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int activity_id { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}
