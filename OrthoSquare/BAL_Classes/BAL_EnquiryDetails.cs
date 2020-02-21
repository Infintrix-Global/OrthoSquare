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
                DateTime Folllowupdate1 ;
                if (bojEnq.Folllowupdate == "")
                {
                    Folllowupdate1 = objGeneral.getDatetime("01-01-1999");

                }
                else
                {
                   Folllowupdate1 = objGeneral.getDatetime(bojEnq.Folllowupdate);

                }
                DateTime DateBirth1 ;
                if (bojEnq.DateBirth == "")
                {
                    DateBirth1 = objGeneral.getDatetime("01 -01-1999");

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
                 objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", DateBirth1);
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
              //objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                //objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID",0);
                //ds = objGeneral.GetDatasetByCommand_SP("GET_Enquiry");




            strQuery = "Select * from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid  where E.IsActive =1";

                if(Cid > 0)
                    strQuery += " and E.ClinicID ='" + Cid + "'";

               strQuery += "   order by EnquiryID DESC";

               return objGeneral.GetDatasetByCommand(strQuery);


           
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




            strQuery = "Select * from  Followup F join tbl_DoctorDetails DD on DD.DoctorID =F.employeeid where EnquiryID='"+Eid+"' order by Followupid DESC";
            return objGeneral.GetDatasetByCommand(strQuery);
        }



        public DataTable GetAllEnquiryFollowpDetails(long Did)
        {

            strQuery = " Select *,EMP.FirstName as RFirstName,EMP.LastName as RSurname from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery +=  " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tbl_DoctorDetails Emp on Emp .DoctorID =E.AssignToEmpId ";
		    strQuery +=   " Join tbl_ClinicDetails CD on CD .ClinicID =E.ReceivedByEmpId ";

            strQuery += " where E.AssignToEmpId='" + Did + "' and E.IsActive =1 and E.IsPatient=0 order by InterestLevel DESC ";


          
            return objGeneral.GetDatasetByCommand(strQuery);
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
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 8);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", Eqid);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString ();


        }

        public string GetFollowuTotal(int Eqid)
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", Eqid);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString();


        }


        public string GetEnqMaxId()
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
            objGeneral.AddParameterWithValueToSQLCommand("@EnquiryID", 0);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Enquiry").ToString();

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
                objGeneral.AddParameterWithValueToSQLCommand("@Followupid",0);
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
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy",0);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Followup");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int GetEnquirySourceID(String Sourcename)
        {
            General objGeneral = new General();
            string strQuery = "SELECT * FROM EnquirySourceMaster WHERE Lower(Sourcename)='" + Sourcename.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                return Convert.ToInt32(dtData.Rows[0]["Sourceid"]);
            else
                return 0;

        }


        public int GetEnquiryTreatmentID(String TreatmentName)
        {
            General objGeneral = new General();
            string strQuery = "SELECT * FROM TreatmentMASTER WHERE Lower(TreatmentName)='" + TreatmentName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                return Convert.ToInt32(dtData.Rows[0]["TreatmentID"]);
            else
                return 0;

        }



        public int GetEnquiryDoctorID(String FirstName)
        {
            General objGeneral = new General();
            string strQuery = "SELECT * FROM tbl_DoctorDetails WHERE Lower(FirstName)='" + FirstName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                return Convert.ToInt32(dtData.Rows[0]["DoctorID"]);
            else
                return 0;

        }



        public int GetEnquiryClinicID(String ClinicName)
        {
            General objGeneral = new General();
            string strQuery = "SELECT * FROM tbl_ClinicDetails WHERE Lower(ClinicName)='" + ClinicName.Trim().ToLower() + "'";
            DataTable dtData = objGeneral.GetDatasetByCommand(strQuery);
            if (dtData != null && dtData.Rows.Count > 0)
                return Convert.ToInt32(dtData.Rows[0]["ClinicID"]);
            else
                return 0;

        }


        public bool SaveExcelUploadedEnquiry(int TreatmentID, int ClinicID, string Enquiryno, string FirstName, string LastName,string Email, string Mobile,string Conversation)
        {
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO Enquiry (TreatmentID,ClinicID,Enquiryno,FirstName,LastName,Email,Mobile,Conversation,IsActive)";
                strQuery += "VALUES (@TreatmentID,@ClinicID,@Enquiryno,@FirstName,@LastName,@Email,@Mobile,@Conversation,1) ; Select @@IDENTITY ";

                
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Enquiryno", Enquiryno);
                
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);

                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
               
                objGeneral.AddParameterWithValueToSQLCommand("@Conversation", Conversation);



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



            strQuery = "Select * from Enquiry E left Join EnquirySourceMaster ES on ES.Sourceid=E.Sourceid left Join TreatmentMASTER T on T.TreatmentID=E.TreatmentID  where  E.EnquiryID  ='" + Enq + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

            // return ds.Tables[0];
        }

    }
}