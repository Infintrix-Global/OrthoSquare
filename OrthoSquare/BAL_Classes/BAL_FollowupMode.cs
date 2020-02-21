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


        public DataTable FolloupSearchList(string Name, string MobileNo, int SourceType, int ReceivedByEmpId, string ToEnquiryDate, string FromEnquiryDate, string ToFollowDate, string FromFollowDate)
        {

            strQuery = "Select * from Enquiry E join EnquirySourceMaster ES on ES.Sourceid =E.Sourceid  ";
            strQuery += " join State S on S.StateID =E.stateid Join City C on C.CityID =E.Cityid ";
            strQuery += " Join tbl_ClinicDetails CD on CD .ClinicID =E.ReceivedByEmpId  Join tblEmployeePersonal Emp1 on Emp1 .EmployeeID =E.AssignToEmpId  where E.IsActive =1  ";

            General objGeneral = new General();
            if (Name != "")
                strQuery += " and E.FirstName like '%" + Name + "%'";
            if (MobileNo != "")
                strQuery += " and E.Mobile=@MobileNo";

            if (SourceType > 0)
                strQuery += " and E.Sourceid=@SourceType";

            if (ReceivedByEmpId > 0)
                strQuery += " and E.ReceivedByEmpId=@ReceivedByEmpId";

            if (FromEnquiryDate != "" && ToEnquiryDate != "")
                strQuery += " and convert(date,E.EnquiryDate,101) between convert(date,@FromEnquiryDate,101) and convert(date,@ToEnquiryDate,101)";

            if (FromFollowDate != "" && ToFollowDate != "")
                strQuery += " and convert(date,E.Folllowupdate,101) between convert(date,@FromFollowDate,101) and convert(date,@ToFollowDate,101)";

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