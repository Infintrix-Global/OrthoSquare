using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OrthoSquare.Entities
{
     [DataContract]
    public class ViewComplaint
    {


         

         [DataMember]
         public string DentalinfoID { get; set; }

        [DataMember]
         public string Complaint { get; set; }

        [DataMember]
        public string DentalTreatment { get; set; }
        [DataMember]
        public string ToothNo { get; set; }
       

     }
     public class ViewMedicines
    {

        //---------------Medicines   
         [DataMember]
         public string Medicinesid { get; set; }
         [DataMember]
        public string MedicinesName { get; set; }
        [DataMember]
        public string Medicinestype { get; set; }
        [DataMember]
        public string TotalMedicines { get; set; }
        [DataMember]
        public string DayMedicines { get; set; }
        [DataMember]
        public string Remarks { get; set; }
     }

     public class PreviousConsultation
     {
      // -----------------PreviousConsultation
         //Add in Toth No



         [DataMember]
         public string TreatmentID { get; set; }

        [DataMember]
        public string TreatmentName { get; set; }
        [DataMember]
        public string DocterName { get; set; }
        [DataMember]
        public string Treatmentstart_date { get; set; }

        [DataMember]
        public string ToothNo { get; set; }
     }

     public class viewTreatmentPlan
     {
         // ------------------ TreatmentPla 
         // Doctor Add

         [DataMember]
         public string Treatmentplanid { get; set; }


        [DataMember]
        public string PlanDetails { get; set; }

          [DataMember]
        public string DocterName { get; set; }

     }
     public class viewLab
     {
        //-----Lab

         // Add new ToothNo  

         [DataMember]
         public string Labid { get; set; }


        [DataMember]
        public string LabName { get; set; }

        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public string TypeName { get; set; }

        [DataMember]
        public string OutwardDate { get; set; }

        [DataMember]
        public string InwardDate { get; set; }

        [DataMember]
        public string ToothNo { get; set; }
    }

     public class checkViewConsultation
     {
         public List<ViewComplaint> Complaints { get; set; }

         public List<ViewMedicines> Medicines { get; set; }

         public List<PreviousConsultation> PreviousConsultation { get; set; }

         public List<viewTreatmentPlan> TreatmentPlan { get; set; }

         public List<viewLab> Lab { get; set; }
         public string status { get; set; }

         public string message { get; set; }

     }
}