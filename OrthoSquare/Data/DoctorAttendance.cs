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
    
    public partial class DoctorAttendance
    {
        public int AttendanceId { get; set; }
        public Nullable<int> ClinicID { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Fid { get; set; }
    }
}