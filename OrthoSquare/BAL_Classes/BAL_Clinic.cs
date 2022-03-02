using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Clinic
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        private string strQuery = string.Empty;
        public int Add_Clinic(ClinicDetails bojClinic)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojClinic.clinicID);

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicName", bojClinic.ClinicName);

                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojClinic.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojClinic.LastName);


                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine1", bojClinic.AddressLine1);
                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine2", bojClinic.AddressLine2);
                objGeneral.AddParameterWithValueToSQLCommand("@LocationID", bojClinic.LocationID);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo1", bojClinic.PhoneNo1);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo2", bojClinic.PhoneNo2);
                objGeneral.AddParameterWithValueToSQLCommand("@Emailid", bojClinic.Emailid);
                objGeneral.AddParameterWithValueToSQLCommand("@DayOfWeek", bojClinic.Noofweek);
                objGeneral.AddParameterWithValueToSQLCommand("@openTime", bojClinic.openTime);
                objGeneral.AddParameterWithValueToSQLCommand("@CloseTime", bojClinic.CloseTime);
                objGeneral.AddParameterWithValueToSQLCommand("@StateID", bojClinic.StateID);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryID", bojClinic.CountryID);
                objGeneral.AddParameterWithValueToSQLCommand("@CityID", bojClinic.CityID);

                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@LocationName", bojClinic.LocationName);
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", bojClinic.IsActive);
                objGeneral.AddParameterWithValueToSQLCommand("@IsApprove", bojClinic.IsApprove);
                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojClinic.UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojClinic.UserPassword);

                if (bojClinic.clinicID > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("sp_ClinicSetUp");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        //public int GetDoctorsID()
        //{

        //    try
        //    {
        //        strQuery = "Select isNull(MAX(DoctorID),1) from  tbl_DoctorDetails where IsDeleted =0";
        //        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        public void UpDateIssueComment(int empid,int ID, string StateUs, string Comments)
        {

            try
            {
                General objGeneral = new General();
                string dateTime1 = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                // string query = "insert into ReportIssue(UserId,IssueType,Title,Description,Attachment,Date,Status,CreatedBy,CreatedOn,IsActive)values(@empid,@IssueType,@Title,@Description,@Attachment,GETDATE(),@Status,@empid,GETDATE(),1)";
                string query = "Update  ReportIssue set Status=@StateUs,Comment=@Comments,CommentDate=@dateTime1,ModifiedOn=@dateTime1,ModifiedBy=@empid where ID =@ID ";
                objGeneral.AddParameterWithValueToSQLCommand("@empid", empid);
                objGeneral.AddParameterWithValueToSQLCommand("@ID", ID);
                objGeneral.AddParameterWithValueToSQLCommand("@StateUs", StateUs);
                objGeneral.AddParameterWithValueToSQLCommand("@Comments", Comments);
                objGeneral.AddParameterWithValueToSQLCommand("@dateTime1", dateTime1);
                objGeneral.GetExecuteNonQueryByCommand(query);
            }
            catch (Exception ex)
            {

            }
        }

        public void AddIssue(int empid, string IssueType, string Title, string Description, string Attachment,int Docotrid,int Clinicid )
        {

            try
            {
                General objGeneral = new General();
                string dateTime1 = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                string query = "insert into ReportIssue(UserId,IssueType,Title,Description,Attachment,Date,Status,CreatedBy,CreatedOn,IsActive,ClinicId,DoctorId)values(@empid,@IssueType,@Title,@Description,@Attachment,GETDATE(),@Status,@empid,GETDATE(),1,@Clinicid,@Docotrid)";

                objGeneral.AddParameterWithValueToSQLCommand("@empid", empid);
                objGeneral.AddParameterWithValueToSQLCommand("@IssueType", IssueType);
                objGeneral.AddParameterWithValueToSQLCommand("@Title", Title);
                objGeneral.AddParameterWithValueToSQLCommand("@Description", Description);
                objGeneral.AddParameterWithValueToSQLCommand("@Attachment", Attachment);
                objGeneral.AddParameterWithValueToSQLCommand("@Status", "Pending");
                objGeneral.AddParameterWithValueToSQLCommand("@Docotrid", Docotrid);
                objGeneral.AddParameterWithValueToSQLCommand("@Clinicid", Clinicid);
                objGeneral.GetExecuteNonQueryByCommand(query);
            }
            catch (Exception ex)
            {

            }
        }

        public int DeleteIssue(int ID)
        {
            int ID1 = 0;
            try
            {
                General objGeneral = new General();

                string query = "Update ReportIssue set IsActive=0 where Id =@id";
                objGeneral.AddParameterWithValueToSQLCommand("@id", ID);

                objGeneral.GetExecuteNonQueryByCommand(query);
                ID1 = 1;
                
            }
            catch (Exception ex)
            {

            }
            return ID1;
        }



        public DataTable GetAllClinicDetais()
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetAllClinicDetaisApprove()
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");

            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetClinicUsernameAndPass(string PhoneNo2, int ClinicID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo2", PhoneNo2);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                ds = objGeneral.GetDatasetByCommand_SP("GETClinicUsernameAndPass");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }




        public DataTable GetAllClinicDetaisNew(int Cid)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from tbl_ClinicDetails  where IsActive =1 ";
                if (Cid > 0)
                    strQuery += " and ClinicID='" + Cid + "'";
                strQuery += " ORDER BY ClinicName ASC";
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }





        public int DeleteClinic(int CID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateStatClinic(int CID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public DataTable GetSelectAllClinic(int CID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetSelectAllClinicEmployee(long CID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public int GetClinicID()
        {

            try
            {
                string strQuery = "Select isNull(MAX(ClinicID),1)  from  tbl_ClinicDetails where IsActive =1";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Add_AppointmentDetails(int Cid)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                string strQuery = "insert into AppointmentMaster (ClinicID,start_date,end_date,IsActive)values ('" + Cid + "','2017-10-10 00:00:00.000','2017-10-10 00:00:00.000',1)";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }

            catch (Exception ex)
            {
            }
            return isInserted;
        }
    }
}