using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace OrthoSquare.Entities
{
    [DataContract]
    public class VerifyLogin
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public int patientid { get; set; }

        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public string PatientCode { get; set; }
        [DataMember]
        public string Name { get; set; }
       
        [DataMember]
        public string BOD { get; set; }
        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string ProfileImage { get; set; }

        [DataMember]
        public int ClinicID { get; set; }


        [DataMember]
        public string App_Version { get; set; }

        [DataMember]
        public string App_VCode { get; set; }

        [DataMember]
        public bool ForceUpdate { get; set; }

    }
    public class checkVerifyLogin
    {
        public string status { get; set; }
        public string message { get; set; }
        // public VerifyLogin data { get; set; }

        public VerifyLogin data { get; set; }
    }

    public class checkVerifyLogout
    {
        public string status { get; set; }
        public string message { get; set; }


        //   public VerifyLogin data { get; set; }

    }

    [DataContract]
    public class ChangePasswords
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
    public class checkChangePassword
    {
        public string message { get; set; }
        public string status { get; set; }
        public ChangePasswords Data { get; set; }
    }



    [DataContract]
    public class ForgotPassword
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Email { get; set; }
    }

    public class checkForgotPassword
    {
        public string status { get; set; }
        public string message { get; set; }
        public ForgotPassword Data { get; set; }
    }


     [DataContract]
    public class ClinicDetailsDetails
    {

        [DataMember]
         public int ClinicID { get; set; }
        [DataMember]
        public string ClinicName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string OpenTime { get; set; }

        [DataMember]
        public string CloseTime { get; set; }

        [DataMember]
        public string DayOfWeek { get; set; }

        [DataMember]
        public string EmailID { get; set; }

        [DataMember]
        public string Name { get; set; }
       

    }

   
     public class checkClinicList
    {
         public List<ClinicDetailsDetails> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    [DataContract]
    public class GetClinicList
    {

        [DataMember]
        public int ClinicId { get; set; }
        [DataMember]
        public string ClinicName { get; set; }

    }

    public class checkGetClinicList
    {
        public List<GetClinicList> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    [DataContract]
     public class DoctorDetailsAll
     {

         [DataMember]
         public int DoctorID { get; set; }
         [DataMember]
         public string DoctorType { get; set; }

         [DataMember]
         public string ClinicID { get; set; }

         [DataMember]
         public string Name { get; set; }

         [DataMember]
         public string Gender { get; set; }

         [DataMember]
         public string Email { get; set; }

         [DataMember]
         public string Mobile { get; set; }

         [DataMember]
         public string Address { get; set; }

         [DataMember]
         public string ProfileImageUrl { get; set; }

         [DataMember]
         public string ClinicName { get; set; }

     }


     public class checkDoctorList
     {
         public List<DoctorDetailsAll> Data { get; set; }
         public string status { get; set; }

         public string message { get; set; }

     }


    [DataContract]
    public class GetDoctorList
    {

        [DataMember]
        public int DoctorId { get; set; }
      
        [DataMember]
        public string ClinicId { get; set; }

        [DataMember]
        public string Name { get; set; }


    }


    public class checkGetDoctorList
    {
        public List<GetDoctorList> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    [DataContract]
    public class GetPatientList
    {

        [DataMember]
        public int ClinicId { get; set; }

        [DataMember]
        public int PatientId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string EmaiId { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int DoctorId { get; set; }
    }


    public class checkGetPatientList
    {
        public List<GetPatientList> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }

    public class checkMiscellaneousList
     {
         public string status { get; set; }
         public string Detail { get; set; }
         public string Type { get; set; }
         public string message { get; set; }

     }

     public class FeedbackS
     {

         [DataMember]
         public int SecurityId { get; set; }

         [DataMember]
         public string FeedbackType { get; set; }

         [DataMember]
         public string FeedbackDetails { get; set; }

     }

     public class checkFeedback
     {
         public string status { get; set; }

         public int Feedbackid { get; set; }
         public string message { get; set; }

     }



     [DataContract]
     public class AdvertismentDetails
     {

         [DataMember]
         public int Aid { get; set; }

         [DataMember]
         public string Title { get; set; }
         [DataMember]
         public string AdImage { get; set; }

        
     }


     public class checkAdvertisment
     {
         public List<AdvertismentDetails> Data { get; set; }
         public string status { get; set; }

         public string message { get; set; }

     }
}