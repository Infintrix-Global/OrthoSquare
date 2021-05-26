using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_Pack
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddPack(string Name)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@PackName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Pack");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllPack()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@PackName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Pack");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeletePack(int BID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@PackName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Pack");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdatePack(string Name, int BID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@PackName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_Pack");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }
    }
}