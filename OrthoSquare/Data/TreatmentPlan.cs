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
    
    public partial class TreatmentPlan
    {
        public int treatmentplanid { get; set; }
        public Nullable<int> patientid { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public string PlanDetails { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
    }
}
