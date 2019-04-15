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
    
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            this.ActivityUsers = new HashSet<ActivityUser>();
            this.ActivityWinners = new HashSet<ActivityWinner>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime date { get; set; }
        public string fee { get; set; }
        public int payment_methods_id { get; set; }
        public string eligibility_criteria { get; set; }
        public string guest_name { get; set; }
        public string topic { get; set; }
        public string prize_details { get; set; }
        public string terms { get; set; }
        public string apply_procedure { get; set; }
        public int category_id { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityUser> ActivityUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityWinner> ActivityWinners { get; set; }
    }
}
