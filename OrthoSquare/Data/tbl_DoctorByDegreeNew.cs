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
    
    public partial class tbl_DoctorByDegreeNew
    {
        public int ID { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public string DegreeName { get; set; }
        public string Boardname { get; set; }
        public string CertificationImage { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}