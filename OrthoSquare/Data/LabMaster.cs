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
    
    public partial class LabMaster
    {
        public int Labid { get; set; }
        public Nullable<int> patientid { get; set; }
        public Nullable<int> TypeOfworkId { get; set; }
        public string LabName { get; set; }
        public string ToothNo { get; set; }
        public Nullable<System.DateTime> OutwardDate { get; set; }
        public Nullable<System.DateTime> InwardDate { get; set; }
        public string Workcompletion { get; set; }
        public string WorkStatus { get; set; }
        public string Notes { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> Updateid { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}