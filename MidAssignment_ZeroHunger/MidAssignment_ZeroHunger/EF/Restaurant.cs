//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MidAssignment_ZeroHunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Collect_Requests = new HashSet<Collect_Request>();
        }
    
        public int ResId { get; set; }
        public string ResName { get; set; }
        public string ResAddress { get; set; }
        public string ResContact { get; set; }
        public string ResUser { get; set; }
        public string ResPass { get; set; }
        public int NgoId { get; set; }
    
        public virtual NGO NGO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collect_Request> Collect_Requests { get; set; }
    }
}
