using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_EnquiryDetails
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        private string strQuery = string.Empty;
        public int Add_Enquiry(Enquiry_Details bojEnq)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();
                DateTime Folllowupdate1;
                if (bojEnq.Folllowupdate == "")
                {
                    Folllowupdate1 = objGeneral.getDatetime("01-01-1999");

                }
                else
                {
                    Folllowupdate1 = objGeneral.getDatetime(bojEnq.Folllowupdate);

                }
                DateTime DateBirth1;
                if (bojEnq.DateBirth == "")
                {
                    DateBirth1 = objGeneral.getDatetime("01-01-1999");

                }
                else
                {
                    DateBirth1 = objGeneral.getDatetime(bojEnq.DateBirth);

                }


                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", bojEnq.EnquiryID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojEnq.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid", bojEnq.Sourceid);
                //  objGeneral.AddParameterWithValueToSQLCommand("@PurposeId", bojEnq.PurposeId);
                objGeneral.AddParameterWithValueToSQLCommand("@Enquiryno", bojEnq.Enquiryno);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryDate", objGeneral.getDatetime(bojEnq.EnquiryDate));
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojEnq.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojEnq.LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", DBNull.Value);
                objGeneral.AddParameterWithValueToSQLCommand("@Age", bojEnq.Age);
                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojEnq.Gender);
                objGeneral.AddParameterWithValueToSQLCommand("@Address", bojEnq.Address);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryId", bojEnq.CountryId);
                objGeneral.AddParameterWithValueToSQLCommand("@stateid", bojEnq.stateid);
                objGeneral.AddParameterWithValueToSQLCommand("@Cityid", bojEnq.Cityid);
                objGeneral.AddParameterWithValueToSQLCommand("@Area", bojEnq.Area);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", bojEnq.Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", bojEnq.Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@Telephone", bojEnq.Telephone);
                objGeneral.AddParameterWithValueToSQLCommand("@ReceivedByEmpId", bojEnq.ReceivedByEmpId);
                objGeneral.AddParameterWithValueToSQLCommand("@AssignToEmpId", bojEnq.AssignToEmpId);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestLevel", bojEnq.InterestLevel);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestLevelCode", bojEnq.InterestLevelCode);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojEnq.CreatedBy);
                // objGeneral.AddParameterWithValueToSQLCommand("@CreatedDate", Convert.ToDateTime(bojEnq.CreatedDate) );
                objGeneral.AddParameterWithValueToSQLCommand("@Folllowupdate", Folllowupdate1);
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", "");
                //objGeneral.AddParameterWithValueToSQLCommand("@ModifiedDate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@Status", bojEnq.Status);
                objGeneral.AddParameterWithValueToSQLCommand("@Conversation", bojEnq.Conversation);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", bojEnq.TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@Pstatus", bojEnq.Pstatus);
                objGeneral.AddParameterWithValueToSQLCommand("@RoleId", bojEnq.RoleId);
                objGeneral.AddParameterWithValueToSQLCommand("@TelecallerToEmpId", bojEnq.TelecallerToEmpId);
                if (bojEnq.EnquiryID > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_ADDEnquiry");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int GetEnqurysIsvelid(string Mno)
        {

            try
            {
                string strQuery = "Select Count(*) from Enquiry  where Mobile ='" + Mno + "'";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetAllEnquiry(int Cid)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid left Join  tbl_ClinicDetails CD on CD.ClinicID =E.ClinicID  where E.IsActive =1 and E.IsPatient=0 ";

                if (Cid > 0)
                    strQuery += " and E.ClinicID ='" + Cid + "'";

                strQuery += "   order by EnquiryID DESC";

                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetAllEnquiryClinicDashboard(int Cid,string Year1)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid left Join  tbl_ClinicDetails CD on CD.ClinicID =E.ClinicID  where E.IsActive =1 and E.IsPatient=0 and Year(E.EnquiryDate) = '"+ Year1 + "'";

                if (Cid > 0)
                    strQuery += " and E.ClinicID ='" + Cid + "'";

                strQuery += "   order by EnquiryID DESC";

                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetAllEnquirynew(string Cid, string Name, String Mno, int Sourceid, string FromEnquiryDate, string ToEnquiryDate,int  RoleId,int CreateBy)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid left Join  tbl_ClinicDetails CD on CD.ClinicID =E.ClinicID  " +
                    "where E.IsActive =1 and E.IsPatient=0 and  E.CreatedBy ="+ CreateBy + " and RoleId="+ RoleId +" ";

                if (Cid != "0")
                    strQuery += " and E.ClinicID in (" + Cid + ")";
                if (Name != "")
                    strQuery += " and E.FirstName like '%" + Name + "%'";
                if (Mno != "")
                    strQuery += " and E.Mobile  = '" + Mno + "'";
                if (Sourceid > 0)
                    strQuery += " and E.Sourceid = " + Sourceid + "";
               
                //if (ClinicID > 0)
                //    strQuery += " and E.ClinicID = " + ClinicID + "";


                if (FromEnquiryDate != "" && ToEnquiryDate != "")
                    strQuery += " and convert(date,E.EnquiryDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";

                strQuery += "   order by EnquiryID DESC";

                objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

       public DataTable GetAllEnquirynewDoc(int Cid, string Name, String Mno, int Sourceid, int ClinicID, string FromEnquiryDate, string ToEnquiryDate)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid left Join  tbl_ClinicDetails CD on CD.ClinicID =E.ClinicID  where E.IsActive =1 and E.IsPatient=0";

                if (Cid > 0)
                    strQuery += " and E.ClinicID ='" + Cid + "'";
                if (Name != "")
                    strQuery += " and E.FirstName like '%" + Name + "%'";
                if (Mno != "")
                    strQuery += " and E.Mobile  = '" + Mno + "'";
                if (Sourceid > 0)
                    strQuery += " and E.Sourceid = " + Sourceid + "";
                if (ClinicID > 0)
                    strQuery += " and E.ClinicID = " + ClinicID + "";
                if (FromEnquiryDate != "" && ToEnquiryDate != "")
                    strQuery += " and convert(date,E.EnquiryDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";

                strQuery += "   order by EnquiryID DESC";

                objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
 
        public DataTable GetAllEnquirynewAppoiment(int Eid)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from Enquiry   where IsActive =1 and IsPatient=0";

                if (Eid > 0)
                    strQuery += " and EnquiryID ='" + Eid + "'";

                strQuery += "   order by EnquiryID DESC";


                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetAllEnquiryByAssignToDoctor(int Cid, string Year1)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid  where E.IsActive =1 and E.IsPatient=0 and Year(E.EnquiryDate) = '" + Year1 + "'";


                strQuery += " and E.AssignToEmpId ='" + Cid + "'";

                strQuery += "   order by EnquiryID DESC";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;


        }

        public DataTable GetAllEnquiryFollowup()
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", 0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Enquiry");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetAllEnquiryFollowup1(long Eid)
        {
            DataTable dt = new DataTable();
            try
            {
                //    strQuery = " Select F.EnquiryID,F.Followupdate,F.ConversationDetails,F.Followupmode,ES.statusName,NextFollowupdate,DD.FirstName+' '+DD.LastName as Dname from  Followup F join Enquirystatus ES on ES.StatusId =F.StatusId ";
                //strQuery += " join tbl_DoctorDetails DD on DD.DoctorID =F.employeeid where EnquiryID='" + Eid + "' order by Followupid DESC";

                strQuery = "Select E.EnquiryID,E.Folllowupdate as Followupdate,E.Conversation as ConversationDetails,ES.Sourcename as Followupmode,'Followup' as statusName,'' as NextFollowupdate,DD.FirstName+' '+DD.LastName as Dname From Enquiry E   ";
                strQuery += " join EnquirySourceMaster ES on E.Sourceid=ES.Sourceid join tbl_DoctorDetails DD on DD.DoctorID =E.AssignToEmpId where  E.EnquiryID='" + Eid + "' ";
                strQuery += " UNION ";
                strQuery += " Select F.EnquiryID,F.Followupdate,F.ConversationDetails,F.Followupmode,ES.statusName,NextFollowupdate,DD.FirstName+' '+DD.LastName as Dname from  Followup F join Enquirystatus ES on ES.StatusId =F.StatusId  join tbl_DoctorDetails DD on DD.DoctorID =F.employeeid  ";
                strQuery += "  where EnquiryID = '" + Eid + "' ";
               

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetViewAllEnquiryFollowup(long UserId, long RoleID)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select F.EnquiryID,F.Followupdate,F.ConversationDetails,F.Followupmode,ES.statusName,NextFollowupdate,DD.FirstName+' '+DD.LastName as Dname,E.FirstName+' '+E.LastName as Ename ,E.Mobile from  Followup F join Enquirystatus ES on ES.StatusId =F.StatusId ";
            strQuery += " join tbl_DoctorDetails DD on DD.DoctorID =F.employeeid join Enquiry E on E.EnquiryID =F.EnquiryID where F.IsActive=1 and convert(date,F.NextFollowupdate,105)  =convert(date, GETDATE() ,105)   ";

            if (RoleID == 1)
            {
                strQuery += " and F.ClinicID='" + UserId + "'";
            }
            if (RoleID == 3)
            {
                strQuery += " and  F.employeeid='" + UserId + "'";

            }
            strQuery += " order by Followupid DESC";
           // return objGeneral.GetDatasetByCommand(strQuery);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetViewAllEnquiryFollowupTelecaller(long UserId, long RoleID)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select F.EnquiryID,F.Followupdate,F.ConversationDetails,F.Followupmode,ES.statusName,NextFollowupdate,EMP.FirstName+' '+EMP.Surname as Dname,E.FirstName+' '+E.LastName as Ename ,E.Mobile from  Followup F join Enquirystatus ES on ES.StatusId =F.StatusId ";
                strQuery += " join tblEmployeePersonal EMP on EMP.EmployeeID =F.employeeid join Enquiry E on E.EnquiryID =F.EnquiryID where F.IsActive=1 and convert(date,F.NextFollowupdate,105)  =convert(date, GETDATE() ,105)   ";

                if (RoleID == 1)
                {
                    strQuery += " and F.ClinicID='" + UserId + "'";
                }
                if (RoleID == 3)
                {
                    strQuery += " and  F.employeeid='" + UserId + "'";

                }
                strQuery += " order by Followupid DESC";
                // return objGeneral.GetDatasetByCommand(strQuery);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }




        public DataTable GetAllEnquiryFollowpDetails(long Did, long Cin)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = " Select *,EMP.FirstName as RFirstName,EMP.LastName as RSurname,TM.TreatmentName from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery += " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tbl_DoctorDetails Emp on Emp .DoctorID =E.AssignToEmpId ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ClinicID ";
            strQuery += "  Join TreatmentMASTER TM on TM.TreatmentID=E.TreatmentID where E.IsActive =1 and E.IsPatient=0";
            if (Did > 0)
                strQuery += " and E.AssignToEmpId='" + Did + "'  ";
            if (Cin > 0)
                strQuery += " and E.ClinicID='" + Cin + "' ";
            strQuery += " order by InterestLevel DESC ";

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }





        public DataTable GetEnquiryNextFollowupDate(int Eqid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 7);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", Eqid);

                ds = objGeneral.GetDatasetByCommand_SP("GET_Enquiry");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public string GetFollowulaveDetilas(int Eqid)
        {
            string asd = "";
            try
            {
                General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 8);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", Eqid);
                asd= objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString();
            }
            catch (Exception ex)
            {
            }
            return asd;

        }

        public string GetFollowuTotal(int Eqid)
        {
            string asd = "";
            try
            {
                General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", Eqid);
                asd= objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString();

            }
            catch (Exception ex)
            {
            }
            return asd;
        }


        public string GetEnqMaxId()
        {
            string asd = "";
            try
            {
                General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", 0);
                asd= objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString();
            }
            catch (Exception ex)
            {
            }
            return asd;
        }

        public int DeleteEnquiry(int EID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", EID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Enquiry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public DataTable GetSelectAllEnquiry(int EID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", EID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Enquiry");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public int Add_Followup(Followup_Details bojFollowup)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@Followupid", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@FollowupCode", bojFollowup.FollowupCode);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", bojFollowup.EnquiryID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojFollowup.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@employeeid", bojFollowup.employeeid);
                objGeneral.AddParameterWithValueToSQLCommand("@enquiryno", bojFollowup.enquiryno);
                objGeneral.AddParameterWithValueToSQLCommand("@Followupdate", objGeneral.getDatetime(bojFollowup.Followupdate));
                objGeneral.AddParameterWithValueToSQLCommand("@Followupmodeid", bojFollowup.Followupmodeid);
                objGeneral.AddParameterWithValueToSQLCommand("@ConversationDetails", bojFollowup.ConversationDetails);
                objGeneral.AddParameterWithValueToSQLCommand("@NextFollowupdate", objGeneral.getDatetime(bojFollowup.NextFollowupdate));
                objGeneral.AddParameterWithValueToSQLCommand("@InterestLevel", bojFollowup.InterestLevel);
                objGeneral.AddParameterWithValueToSQLCommand("@Statusid", bojFollowup.Statusid);
                objGeneral.AddParameterWithValueToSQLCommand("@Remak", bojFollowup.Remak);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojFollowup.CreatedBy);

                objGeneral.AddParameterWithValueToSQLCommand("@FollowupmodeNew", bojFollowup.FollowupmodeNew);

                objGeneral.AddParameterWithValueToSQLCommand("@Fname", bojFollowup.Fname);
                objGeneral.AddParameterWithValueToSQLCommand("@LName", bojFollowup.LName);

                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", 0);


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Followup");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int GetEnquirySourceID(String Sourcename)
        {

            int asd = 0;
            try
            {
                General objGeneral = new General();
            string strQuery = "SELECT * FROM EnquirySourceMaster WHERE Lower(Sourcename)='" + Sourcename.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                    asd= Convert.ToInt32(dtData.Rows[0]["Sourceid"]);
            else
                    asd= 0;

            }
            catch (Exception ex)
            {
            }
            return asd;

        }


        public int GetEnquiryTreatmentID(String TreatmentName)
        {
            int asd = 0;
            try
            {
                General objGeneral = new General();
            string strQuery = "SELECT * FROM TreatmentMASTER WHERE Lower(TreatmentName)='" + TreatmentName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                    asd= Convert.ToInt32(dtData.Rows[0]["TreatmentID"]);
            else
                    asd= 0;
            }
            catch (Exception ex)
            {
            }
            return asd;
        }



        public int GetEnquiryDoctorID(String FirstName)
        {
            int asd = 0;
            try
            {
                General objGeneral = new General();
            string strQuery = "SELECT * FROM tbl_DoctorDetails WHERE Lower(FirstName)='" + FirstName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                    asd =Convert.ToInt32(dtData.Rows[0]["DoctorID"]);
            else
                asd= 0;
            }
            catch (Exception ex)
            {
            }
            return asd;
        }



        public int GetEnquiryClinicID(String ClinicName)
        {
            int asd = 0;
            try
            {
                General objGeneral = new General();
            string strQuery = "SELECT * FROM tbl_ClinicDetails WHERE Lower(ClinicName)='" + ClinicName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                    asd= Convert.ToInt32(dtData.Rows[0]["ClinicID"]);
            else
                    asd= 0;
            }
            catch (Exception ex)
            {
            }
            return asd;
        }


        public bool SaveExcelUploadedEnquiry(int TreatmentID, int ClinicID, string Enquiryno, string FirstName, string LastName, string Email, string Mobile, string Conversation,int CreateBy,int RoleId,int SourceId,int AID,int Tid)
        {
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO Enquiry (TreatmentID,ClinicID,DateBirth,Folllowupdate,IsPatient,Enquiryno,EnquiryDate,FirstName,LastName,Email,Mobile,Conversation,IsActive,CreatedBy,RoleId,SourceId,AssignToEmpId,TelecallerToEmpId)";
                strQuery += "VALUES (@TreatmentID,@ClinicID,'01-01-1999','01-01-1999',0,@Enquiryno,GETDATE(),@FirstName,@LastName,@Email,@Mobile,@Conversation,1,@CreateBy,@RoleId,@SourceId,@AID,@Tid) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Enquiryno", Enquiryno);
                //  objGeneral.AddParameterWithValueToSQLCommand("@EnquiryDate", EnquiryDate);

                //  objGeneral.AddParameterWithValueToSQLCommand("@EnquiryDate", objGeneral.getDatetime(Convert.ToDateTime(EnquiryDate).ToString("dd-MM-yyyy")));

                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);

                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);

                objGeneral.AddParameterWithValueToSQLCommand("@Conversation", Conversation);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", CreateBy);
                objGeneral.AddParameterWithValueToSQLCommand("@RoleId", RoleId);
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid", SourceId);
                objGeneral.AddParameterWithValueToSQLCommand("@AID", AID);
                objGeneral.AddParameterWithValueToSQLCommand("@Tid", Tid);

                int NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public DataTable GetEnquiryDetils(long Enq)
        {

            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from Enquiry E left Join EnquirySourceMaster ES on ES.Sourceid=E.Sourceid left Join TreatmentMASTER T on T.TreatmentID=E.TreatmentID  where  E.EnquiryID  ='" + Enq + "'";

                 dt= objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
            // return ds.Tables[0];
        }

        public DataTable GetEnquiryDetils123(long Enq)
        {

            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select *, D.FirstName +' '+ D.LastName as Dname from Enquiry E left Join EnquirySourceMaster ES on ES.Sourceid=E.Sourceid left Join TreatmentMASTER T on T.TreatmentID=E.TreatmentID left Join tbl_ClinicDetails C on C.ClinicID=E.ClinicID left Join tbl_DoctorDetails D on D.DoctorID=E.AssignToEmpId where  E.EnquiryID  ='" + Enq + "'";

                dt= objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
            }
            return dt;
            // return ds.Tables[0];
        }

    }
}