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
    
    public partial class PatientMedicine
    {
        public int Medicinesid { get; set; }
        public string CNo { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> patientid { get; set; }
        public string MedicinesName { get; set; }
        public Nullable<int> MId { get; set; }
        public string txtMtype { get; set; }
        public string TotalMedicines { get; set; }
        public string DayMedicines { get; set; }
        public string MorningMedicines { get; set; }
        public string AfternoonMedicines { get; set; }
        public string EveningMedicines { get; set; }
        public string InHouse { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Strip { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateId { get; set; }
    }
}
