using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OrthoSquare.Entities
{
     [DataContract]
    public class InvoiceListPrintView
    {

        [DataMember]
        public int InvoiceNo { get; set; }
        [DataMember]
        public string InvoiceCode { get; set; }

        [DataMember]
        public string PatientName { get; set; }

        [DataMember]
        public string DoctorName { get; set; }

      

        [DataMember]
        public string PaidAmount { get; set; }

        [DataMember]
        public string PendingAmount { get; set; }

        [DataMember]
        public string PayDate { get; set; }

        [DataMember]
        public string GrandTotal { get; set; }

        [DataMember]
        public List<InvoiceTritment1> Payment { get; set; }
        [DataMember]

      
        public string Mobile { get; set; }
        [DataMember]

        public string Email { get; set; }
        [DataMember]

        public string Gender { get; set; }
        [DataMember]

        public string Age { get; set; }
        [DataMember]

        public string Address { get; set; }
      
        [DataMember]

        public string TotalCostAmount { get; set; }
        [DataMember]


        public string TotalTax { get; set; }

       
          [DataMember]
        public string TotalCost { get; set; }
          [DataMember]
        public string TotalDiscount { get; set; }
          [DataMember]
        public string WordsAmount { get; set; }
          [DataMember]
        public string ClinicName { get; set; }
          [DataMember]
        public string ClinicPhoneNo { get; set; }
          [DataMember]
        public string ClinicAddressLine { get; set; }
          [DataMember]
        public string ClinicEmailID { get; set; }






    }


     public class InvoiceTritment1
     {

         [DataMember]
         public int Invoiceid { get; set; }

         [DataMember]
         public int TreatmentID { get; set; }
         [DataMember]
         public int InvoiceNo { get; set; }
         [DataMember]
         public string TreatmentName { get; set; }

         [DataMember]
         public string Unit { get; set; }

         [DataMember]
         public string Cost { get; set; }

         [DataMember]
         public string Discount { get; set; }

         [DataMember]
         public string TotalTax { get; set; }

         [DataMember]
         public string GrandTotal { get; set; }

        
         
         
     }


     //public class checkInvoiceListPrint1
     //{
     //    public List<InvoiceTritment1> Data { get; set; }
       
     //}

     public class checkInvoicePrintview
     {
         public List<InvoiceListPrintView> Data { get; set; }

     //    public List<checkInvoiceListPrint1> Data1 { get; set; }


         public string status { get; set; }

         public string message { get; set; }




     }

}