using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Enquirystatus
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        public int AddEnquirystatus(string statusName)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@statusName", statusName);
                objGeneral.AddParameterWithValueToSQLCommand("@StatusId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Enquirystatus");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllEnquirystatus()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@statusName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@StatusId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Enquirystatus");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteEnquirystatus(int ESID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@statusName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@StatusId", ESID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Enquirystatus");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateEnquirystatus(string statusName, int ESID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@statusName", statusName);
                objGeneral.AddParameterWithValueToSQLCommand("@StatusId", ESID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_Enquirystatus");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }


    }
}