using OrthoSquare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrthoSquare.Common1;
using System.IO;
using System.Net;
namespace OrthoSquare
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
       
    

        #region Verify Login
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "verifyLogin", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkVerifyLogin verifyLogin(string username, string password, string Rolid, string registrationToken);
        #endregion




        #region Verify Login User name
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "verifyLoginUsername")]
        checkVerifyLogin verifyLoginUsername(int username, string Rolid, string registrationToken);
        #endregion

        #region Change Password
        [OperationContract]
       
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "ChangePassword")]
        checkChangePassword ChangePassword(int UserId, string UserName, string oldPassword, string newPassword, string Rolid);
        #endregion

        #region Forgot Password
        [OperationContract]
        /*  /ForgotPassword?Email=mac@123@gmail.com&Mobile=726885667 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "forgotPassword")]
        checkForgotPassword forgotPassword(string Email, string Mobile, string Rolid, string Name);
        #endregion

        #region ClinicA
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "ClinicAllList")]
        checkClinicList ClinicAllList();

        #endregion

        #region Doctor
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "DoctorAllList")]
        checkDoctorList DoctorAllList(int ClinicID);

        #endregion

        #region Add Appointment
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "AddAppointment")]
        checkAddAppointment AddAppointment(int patientid, int DoctorID, int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1, string start_date);
        #endregion

        #region Upcoming Appointment
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "UpcomingAppointment")]
        checkUpcomingAppointment UpcomingAppointment(int patientid);

        #endregion


        #region Last Appointment
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "LastAppointment")]
        checkLastAppointment LastAppointment(int patientid);

        #endregion


        #region Add Patient
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "AddPatient")]
        checkAddPatient AddPatient(int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1);
        #endregion

        #region Treatment List
        [OperationContract]
       
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "TreatmentList")]
        checkTreatmentList TreatmentList();

        #endregion

        #region InvoiceList
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "InvoiceList")]
        checkInvoiceList InvoiceList(int patientid);

        #endregion

        #region InvoicePrint
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "InvoicePrint")]
        checkInvoiceListPrint InvoicePrint(string InvCode, string InvoiceNo);

        #endregion


        #region Invoice Print view
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "InvoicePrintview")]
        checkInvoicePrintview InvoicePrintview(int patientid);

        #endregion

        #region MiscellaneousList
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "MiscellaneousList")]
        checkMiscellaneousList MiscellaneousList(string Type);

        #endregion

        #region Profile Image Upload Url
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UploadPics", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        File_Upload_Response UploadPics(Stream stream);
        #endregion


        #region Update Patient
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "PatientUpdate")]
        checkPatientUpdateNew PatientUpdate(int patientid, int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1);
        #endregion

        #region Cancel Appointment
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "CancelAppointment")]
        checkCancelAppointment CancelAppointment(int patientid);

        #endregion


        #region Cancel Appointment Update
        [OperationContract]
      
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "CancelAppointmentUpdate")]
        checkUpdateCancelAppointment CancelAppointmentUpdate(int patientid, int Appointmentid);

        #endregion

        #region View Consultation
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "ViewConsultation")]
        checkViewConsultation ViewConsultation(int patientid);

        #endregion

        #region Feedback
        [OperationContract]
        /*  /ChangePassword?roleID=1&UserID=1&oldPassword=tausif@1234&newPassword=tausif@123 */
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "FeedBack")]
        checkFeedback FeedBack(int patientid, string FeedbackType, string Description);

        #endregion

        #region View Consultation
        [OperationContract]

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "AdvertismentList")]
        checkAdvertisment AdvertismentList();

        #endregion


      
    }
}
