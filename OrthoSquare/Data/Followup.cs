//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrthoSquare.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Followup
    {
        public int Followupid { get; set; }
        public string FollowupCode { get; set; }
        public Nullable<int> EnquiryID { get; set; }
        public Nullable<int> ClinicID { get; set; }
        public Nullable<int> employeeid { get; set; }
        public string enquiryno { get; set; }
        public Nullable<System.DateTime> Followupdate { get; set; }
        public Nullable<int> Followupmodeid { get; set; }
        public string Followupmode { get; set; }
        public string ConversationDetails { get; set; }
        public Nullable<System.DateTime> NextFollowupdate { get; set; }
        public string InterestLevel { get; set; }
        public string Statusid { get; set; }
        public string Remak { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}