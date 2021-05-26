using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OrthoSquare.Entities
{
    public class AddAppointment
    {

        [DataMember]
        public string AppointmenNo { get; set; }

        [DataMember]
        public string PatientCode { get; set; }
        [DataMember]
        public int ClinicID { get; set; }
        [DataMember]
        public int patientid { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string DateBirth { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Mobile1 { get; set; }

        [DataMember]
        public string end_date { get; set; }

        [DataMember]
        public string start_date { get; set; }
         [DataMember]
        public string ProfileImage { get; set; }

        

    }

    public class checkAddAppointment
    {
        public string status { get; set; }
        public int Appointmentid { get; set; }

        public string message { get; set; }
       // public AddAppointment Data { get; set; }
    }

    public class checkAddPatient
    {
        public string status { get; set; }
        public int patientid { get; set; }

        public string message { get; set; }
       
    }


    public class checkPatientUpdate
    {
        public string status { get; set; }
        public string message { get; set; }
        public AddAppointment Data { get; set; }
    }


    [DataContract]
    public class UpcomingAppointment
    {
        [DataMember]
        public int Appointmentid { get; set; }
        [DataMember]
        public int patientid { get; set; }

        [DataMember]
        public string patientName { get; set; }

        [DataMember]
        public int ClinicID { get; set; }

        [DataMember]
        public int DoctorID { get; set; }

        [DataMember]
        public string DoctorType { get; set; }

        [DataMember]
        public string DName { get; set; }


        [DataMember]
        public string Address { get; set; }


        [DataMember]
        public string ClinicName { get; set; }

        [DataMember]
        public string start_date { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string ProfileImageUrl { get; set; }
    }


    public class checkUpcomingAppointment
    {
        public List<UpcomingAppointment> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    public class checkCancelAppointment
    {
        public List<UpcomingAppointment> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }

    public class checkUpdateCancelAppointment
    {
        public List<UpcomingAppointment> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    public class checkLastAppointment
    {
        public List<UpcomingAppointment> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }


    public class TreatmentDetails
    {

        [DataMember]
        public int TreatmentID { get; set; }
        [DataMember]
        public string TreatmentName { get; set; }

        [DataMember]
        public string TreatmentCost { get; set; }

       

    }


    public class checkTreatmentList
    {
        public List<TreatmentDetails> Data { get; set; }
        public string status { get; set; }

        public string message { get; set; }

    }






    public class PatientUpdate
    {

      
       
        [DataMember]
        public int ClinicID1 { get; set; }
        [DataMember]
        public int patientid { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string DateBirth { get; set; }
        [DataMember]
        public string Age { get; set; }
        
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Mobile1 { get; set; }

      
        

    }

    public class checkPatientUpdateNew
    {
        public string status { get; set; }
        public string message { get; set; }
        public PatientUpdate Data { get; set; }
    }
}