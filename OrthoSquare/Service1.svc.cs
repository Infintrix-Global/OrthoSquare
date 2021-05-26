using OrthoSquare.BAL_Classes;
using OrthoSquare.Common1;
using OrthoSquare.Data;
using OrthoSquare.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Hosting;


namespace OrthoSquare
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        NewOrthoSquare2210Entities db;

        General objg = new General();
        clsCommonMasters objcom = new clsCommonMasters();
        BAL_Patient objp = new BAL_Patient();
        BAL_ConsultationAddTreatment objConT = new BAL_ConsultationAddTreatment();
        BAL_LabsDetails objLb = new BAL_LabsDetails();
        Notificationnew objN = new Notificationnew();

        string msg;
        private string strQuery = string.Empty;



        #region Verify Login
        public checkVerifyLogin verifyLogin(string username, string password, string Rolid, string registrationToken)
        {
            checkVerifyLogin check = new checkVerifyLogin();

            VerifyLogin rowslogin = new VerifyLogin();
            db = new NewOrthoSquare2210Entities();
            try
            {
                if (Rolid == "8")
                {

                    var res = (from K in db.Logins
                               join P in db.PatientMasters on K.ClinicID equals P.patientid

                               where K.UserName == username && K.Password == password && K.RoleID == Rolid
                               select new
                               {
                                   P.patientid,
                                   P.FristName,
                                   P.LastName,
                                   P.Mobile,
                                   P.BOD,
                                   P.Gender,
                                   P.Email,
                                   P.ProfileImage,
                                   P.ClinicID,
                                   P.PatientCode,

                               }).FirstOrDefault();
                    if (res != null)
                    {

                        var res111 = (from P in db.PatientMasters
                                      where P.patientid == res.patientid
                                      select P).FirstOrDefault();

                        var res2 = (from P in db.App_VersionMaster

                                    select P).FirstOrDefault();

                        if (res111 != null)
                        {
                            res111.registrationToken = registrationToken;
                            db.SaveChanges();
                        }

                        
                        rowslogin.status = "true";
                        rowslogin.patientid = res.patientid;
                        rowslogin.Name = res.FristName + " " + res.LastName;
                        rowslogin.PatientCode = res.PatientCode;
                        rowslogin.BOD = Convert.ToDateTime(res.BOD).ToString("dd-MM-yyyy");

                        if (res.Gender != null)
                        {
                            rowslogin.Gender = res.Gender;
                        }
                        else
                        {
                            rowslogin.Gender = "";

                        }

                        if (res.ProfileImage != null)
                        {
                            rowslogin.ProfileImage = res.ProfileImage;
                        }
                        else
                        {
                            rowslogin.ProfileImage = "";

                        }

                        rowslogin.Email = res.Email;
                        rowslogin.Mobile = res.Mobile;
                       // rowslogin.ProfileImage = res.ProfileImage;
                        rowslogin.ClinicID = Convert.ToInt32(res.ClinicID);
                        rowslogin.App_Version = res2.App_Version;
                        rowslogin.App_VCode = res2.App_VCode;
                        rowslogin.ForceUpdate = Convert.ToBoolean(res2.ForceUpdate);
                        check.data = rowslogin;
                        check.message = "success";
                        check.status = "1";

                    }
                    else
                    {
                        check.data = null;
                        check.message = "failed";


                        check.status = "-1";
                    }
                }
                else if (Rolid == "3")
                {
                    var res = (from K in db.Logins
                               join D in db.tbl_DoctorDetails on K.ClinicID equals D.DoctorID

                               where K.UserName == username && K.Password == password && K.RoleID == Rolid
                               select new
                               {
                                   D.DoctorID,
                                   D.FirstName,
                                   D.LastName,
                                   D.Mobile1,
                                   D.Gender,
                                   D.Email,
                                   D.ProfileImageUrl,

                               }).FirstOrDefault();
                    if (res != null)
                    {


                        rowslogin.status = "true";
                        rowslogin.patientid = res.DoctorID;
                        rowslogin.Name = res.FirstName + " " + res.LastName;

                        rowslogin.Gender = res.Gender;

                        rowslogin.Email = res.Email;
                        rowslogin.Mobile = res.Mobile1;
                        rowslogin.ProfileImage = res.ProfileImageUrl;



                        check.data = rowslogin;
                        check.message = "success";
                        check.status = "1";



                    }
                    else
                    {
                        check.data = null;
                        check.message = "failed";


                        check.status = "-1";
                    }



                }
            }
            catch (Exception ex)
            {
                string msg = @"Status=false" + "\n" + "Msg=" + ex.Message;
                return null;
            }
            return check;
        }
        #endregion

        #region Verify Login UserName
        public checkVerifyLogin verifyLoginUsername(int username, string Rolid, string registrationToken)
        {
            checkVerifyLogin check = new checkVerifyLogin();

            VerifyLogin rowslogin = new VerifyLogin();
            db = new NewOrthoSquare2210Entities();
            try
            {
                if (Rolid == "8")
                {
                    var res = (from K in db.Logins
                               join P in db.PatientMasters on K.ClinicID equals P.patientid

                               where K.ClinicID == username && K.RoleID == Rolid
                               select new
                               {
                                   P.patientid,
                                   P.FristName,
                                   P.LastName,
                                   P.Mobile,
                                   P.BOD,
                                   P.Gender,
                                   P.Email,
                                   P.ProfileImage,
                                   P.ClinicID,
                                   P.PatientCode,

                               }).FirstOrDefault();
                    if (res != null)
                    {

                        var res111 = (from P in db.PatientMasters
                                      where P.patientid == res.patientid
                                      select P).FirstOrDefault();


                        var res2 = (from P in db.App_VersionMaster

                                    select P).FirstOrDefault();

                        if (res111 != null)
                        {
                            res111.registrationToken = registrationToken;
                            db.SaveChanges();
                        }

                        rowslogin.status = "true";
                        rowslogin.patientid = res.patientid;
                        rowslogin.Name = res.FristName + " " + res.LastName;
                        rowslogin.PatientCode = res.PatientCode;
                        rowslogin.BOD = Convert.ToDateTime(res.BOD).ToString("dd-MM-yyyy");

                    //   rowslogin.Gender = res.Gender;


                        if (res.Gender != null)
                        {
                            rowslogin.Gender = res.Gender;
                        }
                        else
                        {
                            rowslogin.Gender = "";

                        }

                        if (res.ProfileImage != null)
                        {
                            rowslogin.ProfileImage = res.ProfileImage;
                        }
                        else
                        {

                            rowslogin.ProfileImage = "";

                        }

                        rowslogin.Email = res.Email;
                        rowslogin.Mobile = res.Mobile;
                       // rowslogin.ProfileImage = res.ProfileImage;
                        rowslogin.ClinicID = Convert.ToInt32(res.ClinicID);

                        rowslogin.App_Version = res2.App_Version;
                        rowslogin.App_VCode = res2.App_VCode;
                        rowslogin.ForceUpdate = Convert.ToBoolean(res2.ForceUpdate);
                        check.data = rowslogin;
                        check.message = "success";
                        check.status = "1";



                    }
                    else
                    {
                        check.data = null;
                        check.message = "failed";


                        check.status = "-1";
                    }
                }
                else if (Rolid == "3")
                {
                    var res = (from K in db.Logins
                               join D in db.tbl_DoctorDetails on K.ClinicID equals D.DoctorID

                               where K.ClinicID == username && K.RoleID == Rolid
                               select new
                               {
                                   D.DoctorID,
                                   D.FirstName,
                                   D.LastName,
                                   D.Mobile1,
                                   D.Gender,
                                   D.Email,
                                   D.ProfileImageUrl,

                               }).FirstOrDefault();
                    if (res != null)
                    {


                        rowslogin.status = "true";
                        rowslogin.patientid = res.DoctorID;
                        rowslogin.Name = res.FirstName + " " + res.LastName;

                        rowslogin.Gender = res.Gender;

                        rowslogin.Email = res.Email;
                        rowslogin.Mobile = res.Mobile1;
                        rowslogin.ProfileImage = res.ProfileImageUrl;



                        check.data = rowslogin;
                        check.message = "success";
                        check.status = "1";



                    }
                    else
                    {
                        check.data = null;
                        check.message = "failed";


                        check.status = "-1";
                    }



                }
            }
            catch (Exception ex)
            {
                string msg = @"Status=false" + "\n" + "Msg=" + ex.Message;
                return null;
            }
            return check;
        }
        #endregion

        #region Change Password
        public checkChangePassword ChangePassword(int UserId,string UserName, string oldPassword, string newPassword, string Rolid)
        {
            General objGeneral = new General();
            checkChangePassword check = new checkChangePassword();
            ChangePasswords changePassword = new ChangePasswords();
            db = new NewOrthoSquare2210Entities();
            try
            {

                if (Rolid == "8")
                {
                    var Res111 = (from L in db.Logins
                                where L.UserName== UserName && L.Password == newPassword
                                select new
                                  {
                                    L.ClinicID
                                  }
                                ).FirstOrDefault();
                    if (Res111 == null)
                    {
                        var res = (from L in db.Logins
                                   join P in db.PatientMasters on L.ClinicID equals P.patientid
                                   where L.ClinicID == UserId && L.RoleID == Rolid
                                   select new
                                   {
                                       L.Password,
                                       P.FristName,
                                       P.LastName,
                                       L.UserName,
                                       P.patientid,
                                       P.Mobile,
                                       P.Email
                                   }).FirstOrDefault();
                        if (res != null)
                        {


                            var res1 = (from L in db.Logins
                                        where L.ClinicID == UserId && L.RoleID == Rolid
                                        select L).FirstOrDefault();
                            res1.Password = newPassword;
                            db.SaveChanges();

                            changePassword.Password = res1.Password.ToString();
                            changePassword.UserID = res.patientid;
                            changePassword.UserName = res.UserName.ToString();
                            changePassword.Mobile = res.Mobile.ToString();
                            changePassword.Email = res.Email.ToString();

                            changePassword.Name = res.FristName.ToString() + " " + res.LastName.ToString();
                            check.Data = changePassword;
                            check.message = "success";

                            SendMail(changePassword.Email, changePassword.UserName, changePassword.Password);


                            //string strmsg = "Dear " + changePassword.Name + ", your new password for SuperDr is " + changePassword.Password;
                            //string SmsStatusMsg = string.Empty;
                            //WebClient client = new WebClient();
                            //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + changePassword.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                            //SmsStatusMsg = client.DownloadString(URL);
                            //if (SmsStatusMsg.Contains("<br>"))
                            //{
                            //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                            //}


                            check.status = "1";


                        }
                        else
                        {
                            check.message = "invalid password";
                            check.status = "-2";
                            check.Data = null;
                        }
                    }
                    else
                    {
                        check.message = "UserName and Password AllRedy Used";
                        check.status = "-2";
                        check.Data = null;

                    }


                }
                if (Rolid == "3")
                {
                    var res = (from L in db.Logins
                               join D in db.tbl_DoctorDetails on L.ClinicID equals D.DoctorID
                               where L.ClinicID == UserId && L.Password == oldPassword && L.RoleID == Rolid
                               select new
                               {
                                   L.Password,
                                   D.FirstName,
                                   D.LastName,
                                   L.UserName,
                                   D.DoctorID,
                                   D.Mobile1,
                                   D.Email


                               }).FirstOrDefault();
                    if (res != null)
                    {


                        var res1 = (from L in db.Logins
                                    where L.ClinicID == UserId && L.Password == oldPassword && L.RoleID == Rolid
                                    select L).FirstOrDefault();
                        res1.Password = newPassword;
                        db.SaveChanges();

                        changePassword.Password = res1.Password.ToString();
                        changePassword.UserID = res.DoctorID;
                        changePassword.UserName = res.UserName.ToString();
                        changePassword.Mobile = res.Mobile1.ToString();
                        changePassword.Name = res.FirstName.ToString() + " " + res.LastName.ToString();
                        check.Data = changePassword;
                        check.message = "success";
                        //string strmsg = "Dear " + changePassword.Name + ", your new password for SuperDr is " + changePassword.Password;
                        //string SmsStatusMsg = string.Empty;
                        //WebClient client = new WebClient();
                        //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + changePassword.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                        //SmsStatusMsg = client.DownloadString(URL);
                        //if (SmsStatusMsg.Contains("<br>"))
                        //{
                        //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                        //}
                        check.status = "1";


                    }
                    else
                    {
                        check.message = "invalid password";
                        check.status = "-2";
                        check.Data = null;
                    }


                }

            }
            catch (Exception ex)
            {
                check.message = ex.Message;
                check.status = "0";
                check.Data = null;
            }
            return check;
        }
        #endregion

        #region Forgot Password
        public checkForgotPassword forgotPassword(string Email, string Mobile, string Rolid,string Name)
        {

            checkForgotPassword check = new checkForgotPassword();
            ForgotPassword forgot = null;


            string Message = "";
            db = new NewOrthoSquare2210Entities();
            try
            {
                if (Rolid == "8")
                {
                    if (Email != "")
                    {



                        var res = (from L in db.Logins
                                   join P in db.PatientMasters on L.ClinicID equals P.patientid
                                   where P.Email == Email && L.RoleID == Rolid && P.FristName == Name

                                   select new
                                   {
                                       L.Password,
                                       P.FristName,
                                       P.LastName,
                                       L.UserName,
                                       P.patientid,
                                       P.Email


                                   }).FirstOrDefault();




                        if (res != null)
                        {


                            forgot = new ForgotPassword();
                            forgot.Password = res.Password.ToString();
                            forgot.UserID = res.patientid;
                            forgot.UserName = res.UserName.ToString();
                            forgot.Email = res.Email.ToString();
                            forgot.Name = res.FristName.ToString() + " " + res.LastName.ToString();
                            check.Data = forgot;
                            check.message = "success";
                            check.status = "1";
                            SendMail(forgot.Email, forgot.UserName, forgot.Password);
                            // string strmsg = "Dear " + forgot.Name + ", your new password for SuperDr is " + forgot.Password;
                            // string SmsStatusMsg = string.Empty;



                            //Email Code

                            //WebClient client = new WebClient();
                            //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + forgot.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                            //SmsStatusMsg = client.DownloadString(URL);
                            //if (SmsStatusMsg.Contains("<br>"))
                            //{
                            //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                            //}
                            

                        }
                        else
                        {
                            check.Data = null;
                            check.message = "failed";
                            check.status = "-1";
                        }

                    }
                    else
                    {
                        var res2 = (from L in db.Logins
                                    join P in db.PatientMasters on L.ClinicID equals P.patientid
                                    where P.Mobile == Mobile && L.RoleID == Rolid && P.FristName == Name
                                    select new
                                    {
                                        L.Password,
                                        P.FristName,
                                        P.LastName,
                                        L.UserName,
                                        P.patientid,
                                        P.Mobile,
                                        P.Email,


                                    }).FirstOrDefault();
                        if (res2 != null)
                        {


                            forgot = new ForgotPassword();
                            forgot.Password = res2.Password.ToString();
                            forgot.UserID = res2.patientid;
                            forgot.UserName = res2.UserName.ToString();
                            forgot.Mobile = res2.Mobile.ToString();
                            forgot.Email = res2.Email.ToString();
                            forgot.Name = forgot.Name = res2.FristName.ToString() + " " + res2.LastName.ToString();
                            check.Data = forgot;
                            check.message = "success";
                            check.status = "1";
                            //  string strmsg = "Dear " + forgot.Name + ", your new password for SuperDr is " + forgot.Password;
                            // string SmsStatusMsg = string.Empty;
                            SendMail(forgot.Email, forgot.UserName, forgot.Password);

                            //WebClient client = new WebClient();
                            //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + forgot.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                            //SmsStatusMsg = client.DownloadString(URL);
                            //if (SmsStatusMsg.Contains("<br>"))
                            //{
                            //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                            //}
                            //check.status = "1";

                        }
                        else
                        {
                            check.Data = null;
                            check.message = "failed";
                            check.status = "-1";
                        }

                    }
                }
                if (Rolid == "3")
                {
                    if (Email != "")
                    {



                        var res = (from L in db.Logins
                                   join D in db.tbl_DoctorDetails on L.ClinicID equals D.DoctorID
                                   where D.Email == Email && L.RoleID == Rolid

                                   select new
                                   {
                                       L.Password,
                                       D.FirstName,
                                       D.LastName,
                                       L.UserName,
                                       D.DoctorID,
                                       D.Email


                                   }).FirstOrDefault();


                        if (res != null)
                        {


                            forgot = new ForgotPassword();
                            forgot.Password = res.Password.ToString();
                            forgot.UserID = res.DoctorID;
                            forgot.UserName = res.UserName.ToString();
                            forgot.Email = res.Email.ToString();
                            forgot.Name = res.FirstName.ToString() + " " + res.LastName.ToString();
                            check.Data = forgot;
                            check.message = "success";
                            string strmsg = "Dear " + forgot.Name + ", your new password for SuperDr is " + forgot.Password;
                            string SmsStatusMsg = string.Empty;

                            //Email Code

                            //WebClient client = new WebClient();
                            //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + forgot.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                            //SmsStatusMsg = client.DownloadString(URL);
                            //if (SmsStatusMsg.Contains("<br>"))
                            //{
                            //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                            //}
                            check.status = "1";

                        }
                        else
                        {
                            check.Data = null;
                            check.message = "failed";
                            check.status = "-1";
                        }

                    }
                    else
                    {
                        var res2 = (from L in db.Logins
                                    join D in db.tbl_DoctorDetails on L.ClinicID equals D.DoctorID
                                    where D.Mobile1 == Mobile && L.RoleID == Rolid
                                    select new
                                    {
                                        L.Password,
                                        D.FirstName,
                                        D.LastName,
                                        L.UserName,
                                        D.DoctorID,
                                        D.Mobile1

                                    }).FirstOrDefault();
                        if (res2 != null)
                        {


                            forgot = new ForgotPassword();
                            forgot.Password = res2.Password.ToString();
                            forgot.UserID = res2.DoctorID;
                            forgot.UserName = res2.UserName.ToString();
                            forgot.Mobile = res2.Mobile1.ToString();
                            forgot.Name = forgot.Name = res2.FirstName.ToString() + " " + res2.LastName.ToString();
                            check.Data = forgot;
                            check.message = "success";
                          //  string strmsg = "Dear " + forgot.Name + ", your new password for SuperDr is " + forgot.Password;
                           // string SmsStatusMsg = string.Empty;


                            //WebClient client = new WebClient();
                            //string URL = "http://alerts.solutionsinfini.com/api/v3/index.php?method=sms&api_key=Ac797fa388f3d813c7590337ebacec9a1&to=" + forgot.Mobile + "&sender=SUPERD&message=" + strmsg + "&unicode=1";
                            //SmsStatusMsg = client.DownloadString(URL);
                            //if (SmsStatusMsg.Contains("<br>"))
                            //{
                            //    SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ");
                            //}
                            //check.status = "1";

                        }
                        else
                        {
                            check.Data = null;
                            check.message = "failed";
                            check.status = "-1";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }


            return check;
        }
        #endregion

        #region ClinicList
        public checkClinicList ClinicAllList()
        {
            checkClinicList check = new checkClinicList();

            List<ClinicDetailsDetails> list = new List<ClinicDetailsDetails>();

            ClinicDetailsDetails objClinic = null;
            db = new NewOrthoSquare2210Entities();
            try
            {
                var res = (from C in db.tbl_ClinicDetails
                           where C.IsActive == true
                           select C).ToList();


                if (res != null)
                {
                    foreach (var item in res)
                    {
                        objClinic = new ClinicDetailsDetails();
                        objClinic.ClinicID = item.ClinicID;
                        objClinic.ClinicName = item.ClinicName;
                        if (string.IsNullOrEmpty(item.AddressLine1))
                            objClinic.Address = string.Empty;
                        else
                        {
                            if (string.IsNullOrEmpty(item.AddressLine2))
                                objClinic.Address = item.AddressLine1;
                            else
                                objClinic.Address = item.AddressLine1 + " " + item.AddressLine2;
                        }
                        objClinic.PhoneNo = item.PhoneNo2;
                        objClinic.EmailID = item.EmailID;

                        objClinic.CloseTime = item.CloseTime;
                        objClinic.OpenTime = item.OpenTime;

                        if (string.IsNullOrEmpty(item.FirstName))
                            objClinic.Name = string.Empty;
                        else
                        {
                            if (string.IsNullOrEmpty(item.LastName))
                                objClinic.Name = item.FirstName;
                            else
                                objClinic.Name = item.FirstName + " ," + item.LastName;
                        }

                        list.Add(objClinic);
                    }


                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";
                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion


        #region DoctorList
        public checkDoctorList DoctorAllList(int ClinicID)
        {
            checkDoctorList check = new checkDoctorList();

            List<DoctorDetailsAll> list = new List<DoctorDetailsAll>();
            string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();
            DoctorDetailsAll objDoctor = null;

            try
            {


                strQuery = "Select * from tbl_DoctorDetails D  Join tbl_ClinicDetails C on  D.ClinicID=C.ClinicID  where D.IsActive ='1'  ";
                if (ClinicID > 0)
                    strQuery += " and  D.ClinicID ='" + ClinicID + "'";


                DataTable dt = objg.GetDatasetByCommand(strQuery);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objDoctor = new DoctorDetailsAll();
                        objDoctor.DoctorID = Convert.ToInt32(dt.Rows[i]["DoctorID"]);
                        objDoctor.ClinicName = dt.Rows[i]["ClinicName"].ToString();
                        objDoctor.Name = dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString();
                        objDoctor.DoctorType = "";
                        objDoctor.Address = dt.Rows[i]["Line1"].ToString() + " " + dt.Rows[i]["Line2"].ToString();

                        objDoctor.Gender = dt.Rows[i]["Gender"].ToString();
                        objDoctor.Email = dt.Rows[i]["Email"].ToString();

                        objDoctor.Mobile = dt.Rows[i]["Mobile1"].ToString();

                        if (dt.Rows[i]["ProfileImageUrl"].ToString() != "")
                        {
                            objDoctor.ProfileImageUrl = ServerResponse + dt.Rows[i]["ProfileImageUrl"].ToString();
                        }


                        objDoctor.ClinicID = dt.Rows[i]["ClinicID"].ToString();
                        list.Add(objDoctor);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }

        #endregion


        #region Add Appointment
        public checkAddAppointment AddAppointment(int patientid, int DoctorID, int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1, string start_date)
        {



            db = new NewOrthoSquare2210Entities();
            checkAddAppointment check = new checkAddAppointment();

            AddAppointment AdA = new AddAppointment();

            try
            {

                int Eno = objcom.GetAppoinmentMax_No();
                string AppintmentNo = "A" + Eno.ToString();

                AdA.AppointmenNo = AppintmentNo;
                AdA.patientid = patientid;

                AdA.DoctorID = DoctorID;
                AdA.ClinicID = ClinicID;
                AdA.FirstName = FirstName;
                AdA.LastName = LastName;
                AdA.DateBirth = DateBirth;

                AdA.Age = Age;
                AdA.Email = Email;

                AdA.Mobile1 = Mobile1;
                AdA.start_date = start_date;

                AdA.end_date = start_date;



                var rej = new AppointmentMaster
                {
                    AppointmenNo = AdA.AppointmenNo,
                    ClinicID = AdA.ClinicID,
                    DoctorID = AdA.DoctorID,
                    patientid = AdA.patientid,
                    FirstName = AdA.FirstName,
                    LastName = AdA.LastName,

                    Emailid = AdA.Email,
                    DateofBirth = objg.getDatetime(AdA.DateBirth),
                    Age = AdA.Age,

                    MobileNo1 = AdA.Mobile1,
                    start_date = objg.getDatetime11(AdA.start_date),
                    end_date = objg.getDatetime11(AdA.start_date),
                    Status = 0,
                    IsActive = true,



                };
                db.AppointmentMasters.Add(rej);
                int result = db.SaveChanges();
                var Appointmentid = rej.Appointmentid;

                if (result > 0)
                {

                    check.Appointmentid = Appointmentid;
                    check.message = "success";
                    check.status = "1";
                    //check.Data = "";

                    //DataTable DTP = objp.GetPatient(patientid);

                    //msg = "Your Appoinment Date :" + Convert.ToDateTime(start_date) + " " + "Time : " + Convert.ToDateTime(start_date).ToShortTimeString() + " has been Booked Appoinment";

                    //if (DTP.Rows[0]["registrationToken"].ToString() != "")
                    //{

                    //    objN.SendMessage(patientid.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msg, " Booked Appoinment", "3");
                    //}
                }

                else
                {
                    // check.Data = null;
                    check.Appointmentid = 0;
                    check.message = "failed";
                    check.status = "-1";
                }



            }
            catch (Exception ex)
            {
                // check.Data = null;
                check.Appointmentid = 0;
                check.message = "failed";
                check.status = "-1";
            }
            return check;
        }
        #endregion

        #region Upcoming Appointment
        public checkUpcomingAppointment UpcomingAppointment(int patientid)
        {
            checkUpcomingAppointment check = new checkUpcomingAppointment();

            List<UpcomingAppointment> list = new List<UpcomingAppointment>();
            string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();
            UpcomingAppointment objupAp = null;

            try
            {


                strQuery = "Select *, D.FirstName +' '+ D.LastName as Dname, AM.FirstName +' '+ AM.LastName as AMname from AppointmentMaster AM join tbl_ClinicDetails C on C.ClinicID = AM.ClinicID join tbl_DoctorDetails D on D.DoctorID = AM.DoctorID ";
                strQuery += " where AM.patientid = '" + patientid + "' and AM.IsActive =1 and AM.Status Not In (2) and convert(date,AM.start_date,101) >  CONVERT(date,GETDATE(),101) Order by convert(date,AM.start_date,101) ASC";


                DataTable dt = objg.GetDatasetByCommand(strQuery);


                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string status = "";
                        if (dt.Rows[i]["Status"].ToString() == "1")
                        {
                            status = "Approved";
                        }
                        else if (dt.Rows[i]["Status"].ToString() == "2")
                        {

                            status = "Cancel";
                        }
                        else
                        {
                            status = "Pending";

                        }
                        objupAp = new UpcomingAppointment();
                        objupAp.Appointmentid = Convert.ToInt32(dt.Rows[i]["Appointmentid"]);
                        objupAp.DoctorID = Convert.ToInt32(dt.Rows[i]["DoctorID"]);
                        objupAp.patientid = Convert.ToInt32(dt.Rows[i]["patientid"]);
                        objupAp.patientName = dt.Rows[i]["AMname"].ToString();
                        objupAp.ClinicID = Convert.ToInt32(dt.Rows[i]["ClinicID"]);

                        objupAp.ClinicName = dt.Rows[i]["ClinicName"].ToString();
                        objupAp.Address = dt.Rows[i]["AddressLine1"].ToString();
                        objupAp.DName = dt.Rows[i]["Dname"].ToString();
                        objupAp.start_date = Convert.ToDateTime(dt.Rows[i]["start_date"]).ToString("dd-MM-yyyy HH:MM");
                        objupAp.status = status;
                        if (dt.Rows[i]["ProfileImageUrl"].ToString() != "")
                        {
                            objupAp.ProfileImageUrl = ServerResponse + dt.Rows[i]["ProfileImageUrl"].ToString();
                        }
                        list.Add(objupAp);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Last Appointment
        public checkLastAppointment LastAppointment(int patientid)
        {
            checkLastAppointment check = new checkLastAppointment();

            List<UpcomingAppointment> list = new List<UpcomingAppointment>();
            string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();
            UpcomingAppointment objupAp = null;

            try
            {


                strQuery = "Select  *, D.FirstName +' '+ D.LastName as Dname, AM.FirstName +' '+ AM.LastName as AMname from AppointmentMaster AM join tbl_ClinicDetails C on C.ClinicID = AM.ClinicID join tbl_DoctorDetails D on D.DoctorID = AM.DoctorID ";
                strQuery += " where AM.patientid = '" + patientid + "' and AM.IsActive =1  and  Status =1  and AM.Status Not In (2) and convert(date,AM.start_date,101) <=  CONVERT(date,GETDATE(),101) Order by convert(date,AM.start_date,101) DESC";


                DataTable dt = objg.GetDatasetByCommand(strQuery);


                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string status = "";
                        if (dt.Rows[i]["Status"].ToString() == "1")
                        {
                            status = "Approved";
                        }
                        else if (dt.Rows[i]["Status"].ToString() == "2")
                        {

                            status = "Cancel";
                        }
                        else
                        {
                            status = "Pending";

                        }



                        objupAp = new UpcomingAppointment();
                        objupAp.Appointmentid = Convert.ToInt32(dt.Rows[i]["Appointmentid"]);
                        objupAp.DoctorID = Convert.ToInt32(dt.Rows[i]["DoctorID"]);
                        objupAp.patientid = Convert.ToInt32(dt.Rows[i]["patientid"]);
                        objupAp.patientName = dt.Rows[i]["AMname"].ToString();
                        objupAp.ClinicID = Convert.ToInt32(dt.Rows[i]["ClinicID"]);

                        objupAp.ClinicName = dt.Rows[i]["ClinicName"].ToString();
                        objupAp.Address = dt.Rows[i]["AddressLine1"].ToString();
                        objupAp.DName = dt.Rows[i]["Dname"].ToString();
                        objupAp.start_date = Convert.ToDateTime(dt.Rows[i]["start_date"]).ToString("dd-MM-yyyy HH:MM");
                        if (dt.Rows[i]["ProfileImageUrl"].ToString() != "")
                        {
                            objupAp.ProfileImageUrl = ServerResponse + dt.Rows[i]["ProfileImageUrl"].ToString();
                        }
                        objupAp.status = status;
                        list.Add(objupAp);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Add Patient
        public checkAddPatient AddPatient(int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1)
        {


            db = new NewOrthoSquare2210Entities();
            checkAddPatient check = new checkAddPatient();

            AddAppointment AdA = new AddAppointment();

            try
            {

                int Eno = objcom.GetPatient_No();
                string Pno = "P" + Eno.ToString();

                int Pid = objp.GetPaisantID() + 1;
                string Password1 = FirstName + "@" + Pid;


                AdA.PatientCode = Pno;


                AdA.ClinicID = ClinicID;
                AdA.FirstName = FirstName;
                AdA.LastName = LastName;
                AdA.DateBirth = DateBirth;

                AdA.Age = Age;
                AdA.Email = Email;

                AdA.Mobile1 = Mobile1;



                var rej = new PatientMaster
                {
                    PatientCode = AdA.PatientCode,
                    ClinicID = AdA.ClinicID,
                    RegistrationDate = objg.getDatetime(System.DateTime.Now.ToString("dd-MM-yyyy")),

                    FristName = AdA.FirstName,
                    LastName = AdA.LastName,

                    Email = AdA.Email,
                    BOD = objg.getDatetime(AdA.DateBirth),
                    Age = AdA.Age,
                    Mobile = AdA.Mobile1,
                    IsActive = true,

                };
                db.PatientMasters.Add(rej);
                int result = db.SaveChanges();
                
                var patientid1 = rej.patientid;


                string strQ = "	insert into Login (UserName ,Password,RoleID,IsActive,ClinicID) values ('" + Mobile1 + "','" + Password1 + "','8','1','" + patientid1 + "')";
                objg.GetExecuteNonQueryByCommand(strQ);



                if (result > 0)
                {


                    check.patientid = patientid1;


                    check.message = "success";
                    check.status = "1";

                     SendMail(Email, Mobile1, Password1);
                }

                else
                {

                    check.message = "failed";


                    check.status = "-1";
                }



            }
            catch (Exception ex)
            {

                check.message = "failed";


                check.status = "-1";
            }
            return check;
        }
        #endregion

        #region Treatment List
        public checkTreatmentList TreatmentList()
        {
            checkTreatmentList check = new checkTreatmentList();

            List<TreatmentDetails> list = new List<TreatmentDetails>();

            TreatmentDetails objT = null;
            db = new NewOrthoSquare2210Entities();
            try
            {
                var res = (from T in db.TreatmentMASTERs
                           where T.IsActive == true
                           select T).ToList();


                if (res != null)
                {
                    foreach (var item in res)
                    {
                        objT = new TreatmentDetails();
                        objT.TreatmentID = item.TreatmentID;
                        objT.TreatmentName = item.TreatmentName;
                        objT.TreatmentCost = item.TreatmentCost;
                        list.Add(objT);
                    }


                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Invoice List
        public checkInvoiceList InvoiceList(int patientid)
        {
            checkInvoiceList check = new checkInvoiceList();

            List<InvoiceList> list = new List<InvoiceList>();

            InvoiceList objInv = null;

            try
            {

                strQuery = "Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid  ";
                strQuery += " JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID  ";
                if (patientid > 0)
                    strQuery += " where  IM.patientid ='" + patientid + "'";

                strQuery += " Order by IM.InvoiceTid DESC ";



                DataTable dt = objg.GetDatasetByCommand(strQuery);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objInv = new InvoiceList();
                        objInv.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                        objInv.InvoiceCode = dt.Rows[i]["InvoiceCode"].ToString();
                        objInv.PatientName = dt.Rows[i]["PFristName"].ToString() + " " + dt.Rows[i]["PLastName"].ToString();
                        objInv.DoctorName = dt.Rows[i]["DFirstName"].ToString() + " " + dt.Rows[i]["DLastName"].ToString();
                        objInv.GrandTotal = dt.Rows[i]["GrandTotal"].ToString();

                        objInv.PaidAmount = dt.Rows[i]["PaidAmount"].ToString();
                        objInv.PendingAmount = dt.Rows[i]["PendingAmount"].ToString();

                        objInv.PayDate = Convert.ToDateTime(dt.Rows[i]["PayDate"]).ToString("dd-MM-yyyy");


                        list.Add(objInv);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Invoice Print
        public checkInvoiceListPrint InvoicePrint(string InvCode, string InvoiceNo)
        {
            checkInvoiceListPrint check = new checkInvoiceListPrint();

            List<InvoiceTritment> list = new List<InvoiceTritment>();

            InvoiceTritment objInv = null;

            try
            {


                strQuery = "Select * from InvoiceDetails ID Join TreatmentMASTER TM on TM.TreatmentID =ID.TreatmentID where InvoiceNo= '" + InvoiceNo + "'";


                DataTable dt = objg.GetDatasetByCommand(strQuery);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objInv = new InvoiceTritment();
                        objInv.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                        objInv.TreatmentName = dt.Rows[i]["TreatmentName"].ToString();
                        objInv.Unit = dt.Rows[i]["Unit"].ToString();
                        objInv.Cost = dt.Rows[i]["Cost"].ToString();
                        objInv.Discount = dt.Rows[i]["Discount"].ToString();
                        objInv.TotalTax = dt.Rows[i]["TotalTax"].ToString();
                        objInv.GrandTotal = dt.Rows[i]["GrandTotal"].ToString();

                        list.Add(objInv);

                    }

                    check.Data = list;
                    string strQuery1;
                    strQuery1 = " Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
                    strQuery1 += " Join tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID Join tbl_ClinicDetails CD on CD.ClinicID =IM.CreateID    where IM.InvoiceNo ='" + InvoiceNo + "' and IM.InvoiceCode='" + InvCode + "'";
                    DataTable dt1 = objg.GetDatasetByCommand(strQuery1);


                    check.PatientName = dt1.Rows[0]["PFristName"].ToString() + " " + dt1.Rows[0]["PLastName"].ToString();
                    check.DoctorName = dt1.Rows[0]["DFirstName"].ToString() + " " + dt1.Rows[0]["DLastName"].ToString();
                    check.Mobile = dt1.Rows[0]["Mobile"].ToString();
                    check.Email = dt1.Rows[0]["Email"].ToString();
                    check.Gender = dt1.Rows[0]["Gender"].ToString();
                    check.Age = dt1.Rows[0]["Age"].ToString();
                    check.Address = dt1.Rows[0]["Address"].ToString();
                    check.InvoiceCode = dt1.Rows[0]["InvoiceCode"].ToString();
                    check.TotalCostAmount = dt1.Rows[0]["TotalCostAmount"].ToString();
                    check.TotalTax = dt1.Rows[0]["TotalTax"].ToString();
                    check.GrandTotal = dt1.Rows[0]["GrandTotal"].ToString();
                    check.PaidAmount = dt1.Rows[0]["PaidAmount"].ToString();
                    check.PendingAmount = dt1.Rows[0]["PendingAmount"].ToString();
                    check.TotalCost = dt1.Rows[0]["TotalCost"].ToString();
                    check.TotalDiscount = dt1.Rows[0]["TotalDiscount"].ToString();
                    check.WordsAmount = dt1.Rows[0]["GrandTotal"].ToString();
                    check.ClinicName = dt1.Rows[0]["ClinicName"].ToString();
                    check.ClinicPhoneNo = dt1.Rows[0]["PhoneNo2"].ToString();
                    check.ClinicAddressLine = dt1.Rows[0]["AddressLine1"].ToString();
                    check.ClinicEmailID = dt1.Rows[0]["EmailID"].ToString();
                    check.message = "success";
                    check.status = "1";

                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Miscellaneous List
        public checkMiscellaneousList MiscellaneousList(string Type)
        {
            checkMiscellaneousList check = new checkMiscellaneousList();

            db = new NewOrthoSquare2210Entities();
            try
            {
                //var res = (from E in db.EditorDetails
                //           where E.Type == Type
                //           select E).FirstOrDefault();
                strQuery = "Select * from EditorDetail where Type='"+ Type + "' ";
              


                DataTable dt = objg.GetDatasetByCommand(strQuery);

                if (dt != null && dt.Rows.Count > 0)
                {


                    check.Detail = dt.Rows[0]["Detail"].ToString();
                    check.Type = dt.Rows[0]["Type"].ToString();
                    check.message = "success";

                    check.status = "1";
                }
                else
                {

                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {

                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region Invoice Print view
        public checkInvoicePrintview InvoicePrintview(int patientid)
        {
            checkInvoicePrintview check = new checkInvoicePrintview();

            List<InvoiceListPrintView> list = new List<InvoiceListPrintView>();
            //List<InvoiceTritment1> list1 = new List<InvoiceTritment1>();

            InvoiceListPrintView objInv = null;

            try
            {

                strQuery = "Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid  ";
                strQuery += " JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID  ";
                if (patientid > 0)
                    strQuery += " where  IM.patientid ='" + patientid + "'";

                strQuery += " Order by IM.InvoiceTid DESC ";



                DataTable dt = objg.GetDatasetByCommand(strQuery);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        List<InvoiceTritment1> list1 = null;
                        InvoiceTritment1 objInv1 = null;
                        objInv = new InvoiceListPrintView();
                        objInv.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                        objInv.InvoiceCode = dt.Rows[i]["InvoiceCode"].ToString();
                        objInv.PatientName = dt.Rows[i]["PFristName"].ToString() + " " + dt.Rows[i]["PLastName"].ToString();
                        objInv.DoctorName = dt.Rows[i]["DFirstName"].ToString() + " " + dt.Rows[i]["DLastName"].ToString();
                        objInv.GrandTotal = dt.Rows[i]["GrandTotal"].ToString();

                        objInv.PaidAmount = dt.Rows[i]["PaidAmount"].ToString();
                        objInv.PendingAmount = dt.Rows[i]["PendingAmount"].ToString();

                        objInv.PayDate = Convert.ToDateTime(dt.Rows[i]["PayDate"]).ToString("dd-MM-yyyy");




                        strQuery = "Select * from InvoiceDetails ID Join TreatmentMASTER TM on TM.TreatmentID =ID.TreatmentID where InvoiceNo= '" + Convert.ToInt32(dt.Rows[i]["InvoiceNo"]) + "'";


                        DataTable dt1 = objg.GetDatasetByCommand(strQuery);

                        if (dt1 != null)
                        {
                            list1 = new List<InvoiceTritment1>();

                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                objInv1 = new InvoiceTritment1();
                                objInv1.InvoiceNo = Convert.ToInt32(dt1.Rows[j]["InvoiceNo"]);
                                objInv1.TreatmentName = dt1.Rows[j]["TreatmentName"].ToString();
                                objInv1.Unit = dt1.Rows[j]["Unit"].ToString();
                                objInv1.Cost = dt1.Rows[j]["Cost"].ToString();
                                objInv1.Discount = dt1.Rows[j]["Discount"].ToString();
                                objInv1.TotalTax = dt1.Rows[j]["TotalTax"].ToString();
                                objInv1.GrandTotal = dt1.Rows[j]["GrandTotal"].ToString();
                                objInv1.TreatmentID = Convert.ToInt32(dt1.Rows[j]["TreatmentID"]);
                                objInv1.Invoiceid = Convert.ToInt32(dt1.Rows[j]["Invoiceid"]);
                                list1.Add(objInv1);


                            }



                        }



                        string strQuery1;
                        strQuery1 = " Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
                        strQuery1 += " Join tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID Join tbl_ClinicDetails CD on CD.ClinicID =IM.CreateID    where IM.InvoiceNo ='" + Convert.ToInt32(dt.Rows[i]["InvoiceNo"]) + "' and IM.InvoiceCode='" + dt.Rows[i]["InvoiceCode"].ToString() + "'";
                        DataTable dt11 = objg.GetDatasetByCommand(strQuery1);


                        objInv.PatientName = dt11.Rows[0]["PFristName"].ToString() + " " + dt11.Rows[0]["PLastName"].ToString();
                        objInv.DoctorName = dt11.Rows[0]["DFirstName"].ToString() + " " + dt11.Rows[0]["DLastName"].ToString();
                        objInv.Mobile = dt11.Rows[0]["Mobile"].ToString();
                        objInv.Email = dt11.Rows[0]["Email"].ToString();
                        objInv.Gender = dt11.Rows[0]["Gender"].ToString();
                        objInv.Age = dt11.Rows[0]["Age"].ToString();
                        objInv.Address = dt11.Rows[0]["Address"].ToString();
                        objInv.InvoiceCode = dt11.Rows[0]["InvoiceCode"].ToString();
                        objInv.TotalCostAmount = dt11.Rows[0]["TotalCostAmount"].ToString();
                        objInv.TotalTax = dt11.Rows[0]["TotalTax"].ToString();
                        objInv.GrandTotal = dt11.Rows[0]["GrandTotal"].ToString();
                        objInv.PaidAmount = dt11.Rows[0]["PaidAmount"].ToString();
                        objInv.PendingAmount = dt11.Rows[0]["PendingAmount"].ToString();
                        objInv.TotalCost = dt11.Rows[0]["TotalCost"].ToString();
                        objInv.TotalDiscount = dt11.Rows[0]["TotalDiscount"].ToString();
                        objInv.WordsAmount = dt11.Rows[0]["GrandTotal"].ToString();
                        objInv.ClinicName = dt11.Rows[0]["ClinicName"].ToString();
                        objInv.ClinicPhoneNo = dt11.Rows[0]["PhoneNo2"].ToString();
                        objInv.ClinicAddressLine = dt11.Rows[0]["AddressLine1"].ToString();
                        objInv.ClinicEmailID = dt11.Rows[0]["EmailID"].ToString();




                        objInv.Payment = list1;

                        list.Add(objInv);

                    }
                    check.Data = list;

                    check.message = "success";

                    check.status = "1";
                }



                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region UploadPics

        public File_Upload_Response UploadPics(Stream stream)
        {


            File_Upload_Response FUR = new File_Upload_Response();
            A_File_Upload FU = new A_File_Upload();


            string f_path = "";
            string SID = "";
            int SecID = 0;
            string Tag = "";

            try
            {

                MemoryStream ms = null;

                byte[] b = null;

                MultipartParser parser = null;
                parser = new MultipartParser(stream);

                b = parser.FileContents;
                ErrorMessage("UploadPics: b=" + b);
                int count = 0;
                foreach (var item in parser.MyContents)
                {
                    if (item.PropertyName == "fileName")
                    {
                        string Fname = Convert.ToString(item.StringData.Remove(0, 96));
                        Fname = Fname.Trim();
                        ErrorMessage("Fname=" + Fname);
                        FU.Fname = Fname;
                        //FU.Fname = Convert.ToString(item.StringData.Replace("\r", ""));
                        ErrorMessage("FU.Fname = =" + Fname);
                    }
                    ErrorMessage("fileContent enter");
                    if (item.PropertyName.Contains("fileContent"))
                    {
                        ErrorMessage("fileContent Start");

                        ms = new MemoryStream(b, 0, b.Length);
                        ErrorMessage(" Memory stream transfered");
                        //string p = Convert.ToString(HttpContext.Current.Server.MapPath);
                        //("~/Files/");
                        ErrorMessage("FU.Fname= " + FU.Fname);
                        ErrorMessage("Path= " + Convert.ToString(HttpRuntime.AppDomainAppPath));
                        //FileStream fs = new FileStream(HttpContext.Current.Server.MapPath
                        //  ("~/Files/") + FU.Fname, FileMode.Create);
                        FileStream fs = new FileStream(Path.Combine(HttpRuntime.AppDomainAppPath, "EmployeeProfile/") + FU.Fname, FileMode.Create);

                        ErrorMessage("file stream created. ");
                        // string ServerResponse = ConfigurationManager.AppSettings["ServerPathR"].ToString();
                        string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();
                        ErrorMessage("serever response " + ServerResponse);
                        ms.WriteTo(fs);
                        ErrorMessage("ms.write ");
                        ms.Close();
                        ErrorMessage("ms.close ");
                        fs.Close();
                        ErrorMessage("fs.close ");
                        fs.Dispose();
                        ErrorMessage("fs.dispose ");
                        FUR.status = "1";
                        FUR.path = ServerResponse + FU.Fname;

                        ErrorMessage(" Fur.path" + ServerResponse + FU.Fname);
                        f_path = ServerResponse + FU.Fname;

                        ErrorMessage(" Fur.path" + f_path);


                    }
                    ErrorMessage("patientId Starts");
                    if (item.PropertyName.Contains("patientId"))
                    {
                        ErrorMessage("patientId enters");
                        SID = Convert.ToString(item.StringData.Remove(0, 95));
                        ErrorMessage(" SID =" + SID);
                        SID = SID.Trim();
                        ErrorMessage("  SID = SID.Trim();");
                        //dhaval

                    }

                    ErrorMessage("SecID = Convert.ToInt32(SID)zzzz;");

                }



                ErrorMessage("New line");
                SecID = Convert.ToInt32(SID);
                ErrorMessage("SecID = Convert.ToInt32(SID);");
                checkPatientUpdate check = new checkPatientUpdate();
                ErrorMessage("check");
                AddAppointment updateSG = new AddAppointment();
                ErrorMessage("updateSG");
                db = new NewOrthoSquare2210Entities();
                ErrorMessage("db = new NewOrthoSqua");
                var res3 = (from P in db.PatientMasters
                            where P.patientid == SecID
                            select P).FirstOrDefault();

                ErrorMessage("db = new NewOrthoSqua");
                string p = f_path;
                ErrorMessage(" string p = f_path;=" + p);
                res3.ProfileImage = p;
                ErrorMessage(" res3.ProfileImage = p;");
                db.SaveChanges();
                ErrorMessage("  db.SaveChanges();");

                updateSG.ProfileImage = res3.ProfileImage;
                ErrorMessage("res3.ProfileImage=" + res3.ProfileImage);


                return FUR;


            }

            catch (Exception ex)
            {

                // return the error message if the operation fails
                FUR.status = "0";

                FUR.path = ex.Message.ToString();
                ErrorMessage("Exception=" + ex.Message.ToString());
                return FUR;

            }

        }
        public static void ErrorMessage(string msg)
        {

            string ACPPath = HostingEnvironment.MapPath("~/log.txt"); //System.Configuration.ConfigurationManager.AppSettings["Log"];
            StreamWriter swExtLogFile = new StreamWriter(ACPPath, true);
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("*****Error message=****" + msg + " at " + DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
        }
        #endregion

        #region Patient Update

        public checkPatientUpdateNew PatientUpdate(int patientid, int ClinicID, string FirstName, string LastName, string DateBirth, string Age, string Email, string Mobile1)
        {
            //GuardUpload
            checkPatientUpdateNew check = new checkPatientUpdateNew();

            PatientUpdate objP = new PatientUpdate();
            db = new NewOrthoSquare2210Entities();

            try
            {

                var res = (from P in db.PatientMasters
                           where P.patientid == patientid
                           select P).FirstOrDefault();


                if (res != null)
                {
                    res.FristName = FirstName;
                    res.LastName = LastName;
                    res.BOD = Convert.ToDateTime(DateBirth);
                    res.Age = Age;
                    res.Email = Email;
                    res.Mobile = Mobile1;
                    res.ClinicID = ClinicID;

                    db.SaveChanges();

                    objP.FirstName = res.FristName;
                    objP.LastName = res.LastName;
                    objP.DateBirth = Convert.ToDateTime(res.BOD).ToString("dd-MM-yyyy");
                    objP.Age = res.Age;
                    objP.Email = res.Email;
                    objP.Mobile1 = res.Mobile;

                    check.Data = objP;
                    check.message = "success";
                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";


                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = "failed";
                check.status = "-1";
            }


            return check;
        }

        #endregion


        #region Cancel Appointment List
        public checkCancelAppointment CancelAppointment(int patientid)
        {
            checkCancelAppointment check = new checkCancelAppointment();

            List<UpcomingAppointment> list = new List<UpcomingAppointment>();
            string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();
            UpcomingAppointment objupAp = null;

            try
            {


                // strQuery = "Select *, D.FirstName +' '+ D.LastName as Dname from AppointmentMaster AM join tbl_ClinicDetails C on C.ClinicID = AM.ClinicID join tbl_DoctorDetails D on D.DoctorID = AM.DoctorID ";
                // strQuery += " where AM.patientid = '" + patientid + "' and AM.IsActive =1 and Status= 2 and convert(date,AM.start_date,101) >  CONVERT(date,GETDATE(),101) Order by convert(date,AM.start_date,101) ASC";

                strQuery = "Select *, D.FirstName +' '+ D.LastName as Dname ,AM.FirstName +' '+ AM.LastName as AMname from AppointmentMaster AM join tbl_ClinicDetails C on C.ClinicID = AM.ClinicID join tbl_DoctorDetails D on D.DoctorID = AM.DoctorID ";
                strQuery += " where AM.patientid = '" + patientid + "' and AM.IsActive =1 and Status= 2  Order by convert(date,AM.start_date,101) ASC";


                DataTable dt = objg.GetDatasetByCommand(strQuery);


                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string status = "";
                        if (dt.Rows[i]["Status"].ToString() == "1")
                        {
                            status = "Approve";
                        }
                        else if (dt.Rows[i]["Status"].ToString() == "2")
                        {

                            status = "Cancel";
                        }
                        else
                        {
                            status = "Pending";

                        }
                        objupAp = new UpcomingAppointment();
                        objupAp.Appointmentid = Convert.ToInt32(dt.Rows[i]["Appointmentid"]);
                        objupAp.DoctorID = Convert.ToInt32(dt.Rows[i]["DoctorID"]);
                        objupAp.patientid = Convert.ToInt32(dt.Rows[i]["patientid"]);
                        objupAp.patientName = dt.Rows[i]["AMname"].ToString();
                        objupAp.ClinicID = Convert.ToInt32(dt.Rows[i]["ClinicID"]);

                        objupAp.ClinicName = dt.Rows[i]["ClinicName"].ToString();
                        objupAp.Address = dt.Rows[i]["AddressLine1"].ToString();
                        objupAp.DName = dt.Rows[i]["Dname"].ToString();
                        objupAp.start_date = Convert.ToDateTime(dt.Rows[i]["start_date"]).ToString("dd-MM-yyyy HH:MM");

                        if (dt.Rows[i]["ProfileImageUrl"].ToString() != "")
                        {
                            objupAp.ProfileImageUrl = ServerResponse + dt.Rows[i]["ProfileImageUrl"].ToString();
                        }
                        objupAp.status = status;
                        list.Add(objupAp);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion


        #region Cancel Appointment Update

        public checkUpdateCancelAppointment CancelAppointmentUpdate(int patientid, int Appointmentid)
        {

            checkUpdateCancelAppointment check = new checkUpdateCancelAppointment();
            UpcomingAppointment objupAp = new UpcomingAppointment();
            List<UpcomingAppointment> list = new List<UpcomingAppointment>();
            db = new NewOrthoSquare2210Entities();

            try
            {

                var res = (from A in db.AppointmentMasters
                           where A.patientid == patientid && A.Appointmentid == Appointmentid
                           select A).FirstOrDefault();

                if (res != null)
                {
                    res.Status = 2;

                    db.SaveChanges();




                    var res1 = (from A in db.AppointmentMasters
                                join CD in db.tbl_ClinicDetails on A.ClinicID equals CD.ClinicID
                                join D in db.tbl_DoctorDetails on A.DoctorID equals D.DoctorID
                                where A.patientid == patientid && A.Appointmentid == Appointmentid
                                select new
                                {
                                    A.Appointmentid,
                                    A.Status,
                                    A.patientid,
                                    A.DoctorID,
                                    A.ClinicID,
                                    A.start_date,
                                    CD.ClinicName,
                                    CD.AddressLine1,
                                    D.FirstName,
                                    D.LastName,


                                }).FirstOrDefault();

                    if (res1 != null)
                    {

                        string status = "";
                        if (res1.Status == 2)
                        {
                            status = "Cancel";
                        }


                        objupAp.Appointmentid = Convert.ToInt32(res1.Appointmentid);
                        objupAp.DoctorID = Convert.ToInt32(res1.DoctorID);
                        objupAp.patientid = Convert.ToInt32(res1.patientid);
                        objupAp.ClinicID = Convert.ToInt32(res1.ClinicID);
                        objupAp.ClinicName = res1.ClinicName;
                        objupAp.Address = res1.AddressLine1;
                        objupAp.DName = res1.FirstName + ' ' + res1.LastName;
                        objupAp.start_date = Convert.ToDateTime(res1.start_date).ToString("dd-MM-yyyy HH:MM");
                        objupAp.status = status;

                        list.Add(objupAp);

                        check.Data = list;
                        check.message = "success";
                        check.status = "1";

                        DataTable DTP = objp.GetPatient(patientid);

                        msg = "Your Appoinment Date :" + Convert.ToDateTime(res1.start_date).ToString("dd-MM-yyyy") + " " + "Time : " + Convert.ToDateTime(res1.start_date).ToShortTimeString() + " has been Booked Cancel";

                        if (DTP.Rows[0]["registrationToken"].ToString() != "")
                        {

                            objN.SendMessage(patientid.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msg, " Booked Cancel", "2");
                        }
                    }
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";


                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = "failed";
                check.status = "-1";
            }


            return check;
        }

        #endregion

        #region View Consultation
        public checkViewConsultation ViewConsultation(int patientid)
        {
            clsCommonMasters objcommon = new clsCommonMasters();
            BAL_Appointment objAP = new BAL_Appointment();


            checkViewConsultation check = new checkViewConsultation();

            List<ViewComplaint> list = new List<ViewComplaint>();
            List<PreviousConsultation> list1 = new List<PreviousConsultation>();
            List<ViewMedicines> list2 = new List<ViewMedicines>();
            List<viewTreatmentPlan> list3 = new List<viewTreatmentPlan>();
            List<viewLab> list4 = new List<viewLab>();
            ViewComplaint objCon = null;
            PreviousConsultation objCP = null;
            ViewMedicines objM = null;

            viewTreatmentPlan objTP = null;
            viewLab objLab = null;


            try
            {


                DataTable dt = objcommon.ComplaintsDetils(Convert.ToInt32(patientid));

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objCon = new ViewComplaint();
                        objCon.DentalinfoID = dt.Rows[i]["DentalinfoID"].ToString();
                        objCon.Complaint = dt.Rows[i]["Complaint"].ToString();
                        objCon.DentalTreatment = dt.Rows[i]["DentalTreatment"].ToString();
                        objCon.ToothNo = dt.Rows[i]["ToothNo"].ToString();
                        list.Add(objCon);

                    }
                    check.Complaints = list;
                }


                DataTable dt1 = objAP.GetPreviousConsultationDetila(patientid, 1);

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {

                        objCP = new PreviousConsultation();
                        objCP.TreatmentID = dt1.Rows[i]["TreatmentID"].ToString();
                        objCP.TreatmentName = dt1.Rows[i]["TreatmentName"].ToString();
                        objCP.DocterName = dt1.Rows[i]["FirstName"].ToString() + ' ' + dt1.Rows[i]["LastName"].ToString();
                        objCP.ToothNo = dt1.Rows[i]["toothNo"].ToString();
                        objCP.Treatmentstart_date = Convert.ToDateTime(dt1.Rows[i]["CtrateDate"]).ToString("dd-MM-yyyy");

                        list1.Add(objCP);

                    }
                    check.PreviousConsultation = list1;
                }

                DataTable AllData2 = objConT.GetMedicinesName(patientid);


                if (AllData2 != null && AllData2.Rows.Count > 0)
                {
                    for (int i = 0; i < AllData2.Rows.Count; i++)
                    {


                        objM = new ViewMedicines();
                        objM.Medicinesid = AllData2.Rows[i]["Medicinesid"].ToString();
                        objM.MedicinesName = AllData2.Rows[i]["MedicinesName"].ToString();
                        objM.Medicinestype = AllData2.Rows[i]["txtMtype"].ToString();
                        objM.TotalMedicines = AllData2.Rows[i]["TotalMedicines"].ToString();
                        objM.DayMedicines = AllData2.Rows[i]["DayMedicines"].ToString();
                        objM.Remarks = AllData2.Rows[i]["Remarks"].ToString();
                        list2.Add(objM);

                    }
                    check.Medicines = list2;
                }


                DataTable AllDataTPP = objConT.GetPTTreatmentPlan(patientid);


                if (AllDataTPP != null && AllDataTPP.Rows.Count > 0)
                {
                    for (int i = 0; i < AllDataTPP.Rows.Count; i++)
                    {


                        objTP = new viewTreatmentPlan();
                        objTP.Treatmentplanid = AllDataTPP.Rows[i]["Treatmentplanid"].ToString();
                        objTP.PlanDetails = AllDataTPP.Rows[i]["PlanDetails"].ToString();
                        objTP.DocterName = AllDataTPP.Rows[i]["FirstName"].ToString() + ' ' + AllDataTPP.Rows[i]["LastName"].ToString();

                        list3.Add(objTP);

                    }
                    check.TreatmentPlan = list3;
                }

                DataTable AllDataLB = objLb.GetLabsViewDetsils(patientid);

                if (AllDataLB != null && AllDataLB.Rows.Count > 0)
                {
                    for (int i = 0; i < AllDataLB.Rows.Count; i++)
                    {


                        objLab = new viewLab();
                        objLab.Labid = AllDataLB.Rows[i]["Labid"].ToString();
                        objLab.LabName = AllDataLB.Rows[i]["LabName"].ToString();
                        objLab.PatientName = AllDataLB.Rows[i]["FristName"].ToString() + ' ' + AllDataLB.Rows[i]["LastName"].ToString();
                        objLab.TypeName = AllDataLB.Rows[i]["TypeName"].ToString();
                        objLab.OutwardDate = Convert.ToDateTime(AllDataLB.Rows[i]["OutwardDate"]).ToString("dd-MM-yyyy");
                        objLab.InwardDate = Convert.ToDateTime(AllDataLB.Rows[i]["InwardDate"]).ToString("dd-MM-yyyy");
                        objLab.ToothNo = AllDataLB.Rows[i]["ToothNo"].ToString();
                        list4.Add(objLab);

                    }
                    check.Lab = list4;
                }




                check.message = "success";

                check.status = "1";
            }
            catch (Exception ex)
            {
                //  check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        #region FeedBack
        public checkFeedback FeedBack(int patientid, string FeedbackType, string Description)
        {

            db = new NewOrthoSquare2210Entities();
            checkFeedback check = new checkFeedback();
            FeedbackS LoginSG = new FeedbackS();

            DateTime RGDate = DateTime.Parse(System.DateTime.Now.ToString("dd-MM-yyyy"));


            try
            {

                var rej = new FeedbackMaster
                {
                    patientid = patientid,
                    FeedbackDetails = Description,
                    FeedbackType = FeedbackType,
                    //   FeedbackDate = RGDate.ToString (),
                    IsActive = true,

                };
                db.FeedbackMasters.Add(rej);
                int result = db.SaveChanges();
                var FeedbackId = rej.Feedbackid;


                if (result > 0)
                {
                    check.Feedbackid = FeedbackId;
                    check.message = "success";
                    check.status = "1";
                }

                else
                {
                    check.message = "failed";
                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.message = "failed";
                check.status = "-1";
            }


            return check;
        }

        #endregion


        #region Advertisment List
        public checkAdvertisment AdvertismentList()
        {
            checkAdvertisment check = new checkAdvertisment();

            List<AdvertismentDetails> list = new List<AdvertismentDetails>();

            AdvertismentDetails objAd = null;

            try
            {



                strQuery = "Select * from AdvertismentMaster where IsActive =1 ";


                DataTable dt = objg.GetDatasetByCommand(strQuery);


                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        objAd = new AdvertismentDetails();
                        objAd.Aid = Convert.ToInt32(dt.Rows[i]["Aid"]);
                        objAd.Title = dt.Rows[i]["Title"].ToString();
                        objAd.AdImage = dt.Rows[i]["AdImage"].ToString();

                        list.Add(objAd);

                    }

                    check.Data = list;
                    check.message = "success";

                    check.status = "1";
                }
                else
                {
                    check.Data = null;
                    check.message = "failed";

                    check.status = "-1";
                }
            }
            catch (Exception ex)
            {
                check.Data = null;
                check.message = ex.Message;
                check.status = "0";
            }
            return check;
        }
        #endregion

        protected void SendMail(string Email, string Username, string Password)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "orthomail885@gmail.com";
            // any address where the email will be sending
            // var toAddress = "mehulrana1901@gmail.com,urvi.gandhi@infintrixglobal.com,nidhi.mehta@infintrixglobal.com,bhavin.gandhi@infintrixglobal.com,mehul.rana@infintrixglobal.com,naimisha.rohit@infintrixglobal.com";

            var toAddress = Email;

            //Password of your gmail address
            const string fromPassword = "Ortho@1234";
            // Passing the values and make a email formate to display
            string subject = "Your UserName and Password For Ortho Square";
            string body = "Dear ," + "\n";
            body += "Your UserName and password For OrthoSquare :" + "\n\n";
            body += "UserName : " + Username + " " + "\n";
            body += "Passward : " + Password + " " + "\n\n";
            body += "Thank you!" + "\n";
            body += "Warm Regards," + "\n";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 50000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

    }
}
