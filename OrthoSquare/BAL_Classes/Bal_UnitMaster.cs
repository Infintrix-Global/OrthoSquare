using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace OrthoSquare.BAL_Classes
{
    public class Bal_UnitMaster
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddUnit(string Name)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllUnit()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteUnit(int BID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateUnit(string Name, int BID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }

    }
}