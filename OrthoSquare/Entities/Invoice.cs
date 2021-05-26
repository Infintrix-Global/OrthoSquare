using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OrthoSquare.Entities
{
    [DataContract]
    public class InvoiceList
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
        public string GrandTotal { get; set; }

        [DataMember]
        public string PaidAmount { get; set; }

        [DataMember]
        public string PendingAmount { get; set; }

        [DataMember]
        public string PayDate { get; set; }

      

    }


    public class checkInvoiceList
    {
        public List<InvoiceList> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }




    }


    public class InvoiceTritment
    {

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


    public class checkInvoiceListPrint
    {
        public List<InvoiceTritment> Data { get; set; }
        public string PatientName { get; set; }

        public string DoctorName { get; set; }


        public string Mobile { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }

        public string Age { get; set; }
        public string Address { get; set; }

        public string InvoiceCode { get; set; }
        public string TotalCostAmount { get; set; }

        public string TotalTax { get; set; }


        public string GrandTotal { get; set; }

        public string PaidAmount { get; set; }

        public string PendingAmount { get; set; }

        public string TotalCost { get; set; }

        public string TotalDiscount { get; set; }

        public string WordsAmount { get; set; }

        public string ClinicName { get; set; }

        public string ClinicPhoneNo { get; set; }

        public string ClinicAddressLine { get; set; }

        public string ClinicEmailID { get; set; }

        public string status { get; set; }

        public string message { get; set; }
    }


}