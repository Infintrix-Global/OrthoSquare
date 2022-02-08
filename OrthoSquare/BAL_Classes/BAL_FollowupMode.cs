using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_FollowupMode
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        private string strQuery = string.Empty;

        public int AddFollowupMode(string ModeName)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@ModeId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@ModeName", ModeName);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_FollowupMode");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllFollowupMode()
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@ModeId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@ModeName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_FollowupMode");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteFollowupMode(int FID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@ModeId", FID);
                objGeneral.AddParameterWithValueToSQLCommand("@ModeName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_FollowupMode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateFollowupMode(string ModeName, int FID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@ModeId", FID);
                objGeneral.AddParameterWithValueToSQLCommand("@ModeName", ModeName);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_FollowupMode");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }


        public DataTable FolloupSearchList(string Name, string MobileNo, int SourceType, int ReceivedByEmpId, string FromEnquiryDate , string ToEnquiryDate, string FromFollowDate, string  ToFollowDate, int UserID,int Rolid)
        {

            General objGeneral = new General();
          
            strQuery = " Select * ,E.FirstName +' '+E.LastName as Ename,Emp.FirstName+' '+Emp.LastName as Dname,TM.TreatmentName from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery += " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tbl_DoctorDetails Emp on Emp .DoctorID =E.AssignToEmpId ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ClinicID ";
            strQuery += "  Join TreatmentMASTER TM on TM.TreatmentID=E.TreatmentID where E.IsActive =1 and E.IsPatient=0";
            


            if (UserID > 1)
                if (Rolid == 1)
                {
                    strQuery += " and E.ClinicID  ="+UserID+"";

                    if (ReceivedByEmpId > 0)
                        strQuery += " and E.ClinicID=@ReceivedByEmpId";
                }
                else
                {
                    strQuery += " and  E.AssignToEmpId =" + UserID + "";
                }
            if (Name != "")
                strQuery += " and E.FirstName like '%" + Name + "%'";
            if (MobileNo != "")
                strQuery += " and E.Mobile=@MobileNo";

            if (SourceType > 0)
                strQuery += " and E.Sourceid=@SourceType";

           

            if (FromEnquiryDate != "" && ToEnquiryDate != "")
                strQuery += " and convert(date,E.EnquiryDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";

            if (FromFollowDate != "" && ToFollowDate != "")
                strQuery += " and convert(date,E.Folllowupdate,105) between convert(date,@FromFollowDate,105) and convert(date,@ToFollowDate,105)";
       
            strQuery += " order by E.Folllowupdate DESC";

            objGeneral.AddParameterWithValueToSQLCommand("@Name", Name);
            objGeneral.AddParameterWithValueToSQLCommand("@MobileNo", MobileNo);
            objGeneral.AddParameterWithValueToSQLCommand("@SourceType", SourceType);
            objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@FromFollowDate", FromFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToFollowDate", ToFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ReceivedByEmpId", ReceivedByEmpId);
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable FolloupSearchTellecallList(string Name, string MobileNo, int SourceType, int ReceivedByEmpId, string FromEnquiryDate, string ToEnquiryDate, string FromFollowDate, string ToFollowDate, int UserID, int Rolid)
        {

            General objGeneral = new General();

            strQuery = " Select * ,E.FirstName +' '+E.LastName as Ename,Emp.FirstName+' '+Emp.Surname as Dname,TM.TreatmentName from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery += " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tblEmployeePersonal Emp on Emp .EmployeeID =E.TelecallerToEmpId ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ClinicID ";
            strQuery += "  Join TreatmentMASTER TM on TM.TreatmentID=E.TreatmentID where E.IsActive =1 and E.IsPatient=0 ";

            if (UserID > 1)
               
                 strQuery += " and  E.TelecallerToEmpId =" + UserID + "";
               
            if (Name != "")
                strQuery += " and E.FirstName like '%" + Name + "%'";
            if (MobileNo != "")
                strQuery += " and E.Mobile=@MobileNo";

            if (SourceType > 0)
                strQuery += " and E.Sourceid=@SourceType";

            if (ReceivedByEmpId > 0)
                strQuery += " and E.ClinicID=@ReceivedByEmpId";

            if (FromEnquiryDate != "" && ToEnquiryDate != "")
                strQuery += " and convert(date,E.EnquiryDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";

            if (FromFollowDate != "" && ToFollowDate != "")
                strQuery += " and convert(date,E.Folllowupdate,105) between convert(date,@FromFollowDate,105) and convert(date,@ToFollowDate,105)";

            strQuery += " order by convert(date,E.Folllowupdate,105) DESC";

            objGeneral.AddParameterWithValueToSQLCommand("@Name", Name);
            objGeneral.AddParameterWithValueToSQLCommand("@MobileNo", MobileNo);
            objGeneral.AddParameterWithValueToSQLCommand("@SourceType", SourceType);
            objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@FromFollowDate", FromFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToFollowDate", ToFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ReceivedByEmpId", ReceivedByEmpId);
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable FolloupSearchTellecallList1(int UserID, int Rolid)
        {

            General objGeneral = new General();

            strQuery = " Select * ,E.FirstName +' '+E.LastName as Ename,Emp.FirstName+' '+Emp.Surname as Dname,TM.TreatmentName from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery += " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tblEmployeePersonal Emp on Emp .EmployeeID =E.TelecallerToEmpId ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ClinicID ";
            strQuery += "  Join TreatmentMASTER TM on TM.TreatmentID=E.TreatmentID where E.IsActive =1 and E.IsPatient=0 ";

            if (UserID > 1)

             strQuery += " and  E.TelecallerToEmpId =" + UserID + "";
            strQuery += " order by convert(date,E.Folllowupdate,105) DESC";

            
            return objGeneral.GetDatasetByCommand(strQuery);

        }



        public DataTable PendingFolloupSearchList(string Name, string MobileNo, int SourceType, int ReceivedByEmpId, string ToEnquiryDate, string FromEnquiryDate, string ToFollowDate, string FromFollowDate, int UserID, int Rolid)
        {

            General objGeneral = new General();

            strQuery = " Select * ,E.FirstName +' '+E.LastName as Ename,Emp.FirstName+' '+Emp.LastName as Dname,TM.TreatmentName from Enquiry E  Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid ";
            strQuery += " join Country Cou on E.CountryId =Cou.CountryID     join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tbl_DoctorDetails Emp on Emp .DoctorID =E.AssignToEmpId ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ClinicID ";
            strQuery += "  Join TreatmentMASTER TM on TM.TreatmentID=E.TreatmentID where NOT EXISTS  (SELECT * FROM Followup F  WHERE F.EnquiryID = E.EnquiryID) and E.IsActive =1 and E.IsPatient=0";

            if (UserID > 1)
                if (Rolid == 1)
                {
                    strQuery += " and E.ClinicID  =" + UserID + "";
                }
                else
                {
                    strQuery += " and  E.AssignToEmpId =" + UserID + "";
                }


            if (Name != "")
                strQuery += " and E.FirstName like '%" + Name + "%'";
            if (MobileNo != "")
                strQuery += " and E.Mobile=@MobileNo";

            if (SourceType > 0)
                strQuery += " and E.Sourceid=@SourceType";

            if (ReceivedByEmpId > 0)
                strQuery += " and E.ReceivedByEmpId=@ReceivedByEmpId";

            if (FromEnquiryDate != "" && ToEnquiryDate != "")
                strQuery += " and convert(date,E.EnquiryDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";

            if (FromFollowDate != "" && ToFollowDate != "")
                strQuery += " and convert(date,E.Folllowupdate,105) between convert(date,@FromFollowDate,105) and convert(date,@ToFollowDate,105)";

            strQuery += " order by E.InterestLevel DESC";

            objGeneral.AddParameterWithValueToSQLCommand("@Name", Name);
            objGeneral.AddParameterWithValueToSQLCommand("@MobileNo", MobileNo);
            objGeneral.AddParameterWithValueToSQLCommand("@SourceType", SourceType);
            objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);
            objGeneral.AddParameterWithValueToSQLCommand("@FromFollowDate", FromFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToFollowDate", ToFollowDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ReceivedByEmpId", ReceivedByEmpId);
            return objGeneral.GetDatasetByCommand(strQuery);

        }

    }
}