using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_DentalCategory
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddDentalCategory(string CategoryName)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@CategoryName", CategoryName);
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_DentalCategory");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllDentalCategory()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_DentalCategory");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteDentalCategory(int CID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryName","");
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID ", CID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_DentalCategory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateDentalCategory(string CategoryName, int CID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryName", CategoryName);
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID ", CID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_DentalCategory");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }
    }
}