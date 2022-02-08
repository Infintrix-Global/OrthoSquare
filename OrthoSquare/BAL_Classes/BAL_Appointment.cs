using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace OrthoSquare.BAL_Classes
{
    public class BAL_Appointment
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        private string strQuery = string.Empty;
        public int Add_AppointmentDetails(Appointment_Details bojApp)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                DateTime DateBirth1;
                if (bojApp.DateBirth == "")
                {
                    DateBirth1 = objGeneral.getDatetime("01-01-1999");

                }
                else
                {
                    DateBirth1 = objGeneral.getDatetime(bojApp.DateBirth);

                }


                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid", bojApp.Appointmentid);

                objGeneral.AddParameterWithValueToSQLCommand("@AppointmenNo", bojApp.AppointmenNo);

                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojApp.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojApp.LastName);

                objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", DateBirth1);

                // objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", objGeneral.getDatetime(bojApp.DateBirth));
                objGeneral.AddParameterWithValueToSQLCommand("@Age", bojApp.Age);

                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojApp.Gender);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", bojApp.Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", bojApp.Mobile1);
                objGeneral.AddParameterWithValueToSQLCommand("@MobileNo2", bojApp.Mobile2);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojApp.CreatedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", bojApp.ModifiedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@OffLineData", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@start_date", objGeneral.getDatetime11(bojApp.start_date));
                objGeneral.AddParameterWithValueToSQLCommand("@end_date", objGeneral.getDatetime11(bojApp.end_date));
                objGeneral.AddParameterWithValueToSQLCommand("@start_time", bojApp.start_time);
                objGeneral.AddParameterWithValueToSQLCommand("@end_time", bojApp.end_time);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", bojApp.DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", bojApp.patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojApp.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", bojApp.EnquiryID);
                if (bojApp.patientid > 0 || bojApp.EnquiryID > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_ADDAppointment");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int Add_AppointmentDetails(int Did)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                strQuery = "insert into AppointmentMaster (DoctorID,start_date,end_date,IsActive)values ('" + Did + "','2017-10-10 00:00:00.000','2017-10-10 00:00:00.000',1)";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }

            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAlltodayAppoinment()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetAlltodayAppoinmentNew1(int Cid)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select * from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101) AND Status IN  (0,1)";

                if (Cid > 0)
                    strQuery += " and AM.ClinicID='" + Cid + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable GetAlltodayAppoinmentNew(int Cid)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select TOP 10 *,D.FirstName as DFirstName,D.LastName As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101) AND Status IN  (0,1)";

                if (Cid > 0)
                    strQuery += " and AM.ClinicID='" + Cid + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable GetAlltodayAppoinmentNewDocter(int Did)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select TOP 10 *,D.FirstName as DFirstName,D.LastName As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101) AND Status IN  (0,1)";

                if (Did > 0)
                    strQuery += " and AM.DoctorID='" + Did + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }



        public DataTable GetAllListtodayAppoinment()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetAllListtodayAppoinmentNew(string Name, string MobileNo, int DoctorID, int Status)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select *,D.FirstName as DFirstName,D.LastName As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101)  ";


                General objGeneral = new General();
                if (Name != "")
                    strQuery += " and  AM.FirstName like '%" + Name + "%'";
                if (MobileNo != "")
                    strQuery += " and AM.MobileNo1=@MobileNo ";

                if (DoctorID > 0)
                    strQuery += " and AM.DoctorID=@DoctorID ";

                if (Status > 0)
                {
                    strQuery += " and AM.Status=@Status ";
                }
                else
                {

                    strQuery += " AND Status IN  (0,1)";
                }

                objGeneral.AddParameterWithValueToSQLCommand("@Name", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@MobileNo", MobileNo);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@Status", Status);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }




        public DataTable GetAllListtodayAppoinmentDetails(string Name, string MobileNo, int DoctorID, int Cid, int Status, string FromDate, string ToDate, string TodayDate)
        {
            DataTable dt = new DataTable();
            try
            {
                General objGeneral = new General();
                strQuery = "Select *,D.FirstName as DFirstName,D.LastName As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where AM.IsActive =1   ";

                if (TodayDate == "1")
                    strQuery += " and  convert(date,AM.start_date,101)  >= CONVERT(date,GETDATE(),101)";

                if (Name != "")
                    strQuery += " and  AM.FirstName like '%" + Name + "%'";
                if (MobileNo != "")
                    strQuery += " and AM.MobileNo1=@MobileNo ";

                if (DoctorID > 0)
                    strQuery += " and AM.DoctorID=@DoctorID ";
                if (Cid > 0)
                    strQuery += " and AM.ClinicId=@Cid";
                if (FromDate != "" && ToDate != "")
                    strQuery += " and convert(date,AM.start_date,105) between convert(date,@FromDate,105) and convert(date,@ToDate,105)";

                if (Status > 0)
                {
                    strQuery += " and AM.Status=@Status ";
                }
                else
                {

                    strQuery += " AND Status IN  (0,1)";
                }

                objGeneral.AddParameterWithValueToSQLCommand("@Name", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@MobileNo", MobileNo);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@Status", Status);
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToDate", ToDate);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public int GetReject(int Aid)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", Aid);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public int GetApprove(int AID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", AID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public DataTable GetAlltodayConsultation()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }




        public DataTable GetAlltodayConsultationViewCon(int Did, int Cid, string pname, string pcode)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select *,PM.FristName as PFristName,PM.LastName as PLastName,PM.Mobile as PMobile,DM.FirstName as DFirstName,DM.LastName as DLastName from AppointmentMaster AM  ";
                strQuery += " Join PatientMaster PM on PM.patientid = AM.patientid ";
                strQuery += " Join tbl_DoctorDetails DM on DM.DoctorID = AM.DoctorID ";
                strQuery += " where AM.Status =1 ";

                if (Did > 0)
                    strQuery += " and AM.DoctorID ='" + Did + "'";

                if (Cid > 0)
                    strQuery += " and AM.ClinicID ='" + Cid + "'";
                if (pname != "")
                    strQuery += " and PM.FristName like '" + pname + "%'";
                if (pcode != "")
                    strQuery += " and PM.PatientCode ='" + pcode + "'";
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }




        public DataTable GetAlltodayConsultationViewConnew(int Did, int Cid, string pname, string pcode)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select PM.patientid,PM.PatientCode,PM.FristName as PFristName,PM.LastName as PLastName,PM.Mobile as PMobile,DM.FirstName as DFirstName,DM.LastName as DLastName,CD.ClinicName from TreatmentbyPatient AM  ";
                strQuery += " Join PatientMaster PM on PM.patientid = AM.patientid ";
                strQuery += " Join tbl_DoctorDetails DM on DM.DoctorID = AM.DoctorID  Join tbl_ClinicDetails CD on PM.ClinicID=CD.ClinicID ";
                strQuery += " where PM.IsActive =1 ";

                if (Did > 0)
                    strQuery += " and AM.DoctorID ='" + Did + "'";

                if (Cid > 0)
                    strQuery += " and PM.ClinicID ='" + Cid + "'";
                if (pname != "")
                    strQuery += " and PM.FristName like '%" + pname + "%'";
                if (pcode != "")
                    strQuery += " and PM.PatientCode ='" + pcode + "'";
                strQuery += " Group by PM.patientid,PM.FristName,PM.LastName,PM.PatientCode ,PM.Mobile,DM.FirstName,DM.LastName,CD.ClinicName";
                dt = objGeneral.GetDatasetByCommand(strQuery);


            }
            catch (Exception ex)
            {
            }
            return dt;
        }



        public DataTable GetAllviewConsultation()
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select *,PM.FristName as PFristName,PM.LastName as PLastName,PM.Mobile as PMobile from PatientMaster PM where PM.IsActive=1";
                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {
            }
            return dt;

        }

        public DataTable GetAllAppoimentDetails(int Aid)
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Appointmentid ", Aid);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 7);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Appointment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetPreviousConsultationDetila(long patientid11, long Did)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select *  from TreatmentbyPatient TP join  TreatmentMASTER TM on Tm.TreatmentID =TP.TreatmentID join  tbl_DoctorDetails D on D.DoctorID =TP.DoctorID where TP.patientid ='" + patientid11 + "' and TP.IsActive =1 and StartedTreatments='Yes'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }


        public DataTable GetTreatmentPlanConsultationDetila(long patientid11, long Did)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select *  from TreatmentPlan TP join  tbl_DoctorDetails D on D.DoctorID =TP.DoctorID where TP.patientid ='" + patientid11 + "' and TP.IsActive =1";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

    }
}