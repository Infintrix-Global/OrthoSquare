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
        public int AddUnit(long UnitId, string Name, string IsMedical)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", UnitId);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", IsMedical);



                if (UnitId > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);

                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isInserted;
        }


        public DataTable GetAllUnit(string UnitName, string IsMedical)
        {
            try
            {
                General objGeneral = new General();
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", UnitName);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", IsMedical);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }




        public int DeleteUnit(int BID)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", "");
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


        public DataTable GetSelectUnit(int UnitId)
        {
            try
            {
                General objGeneral = new General();
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", UnitId);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_UnitMaster");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

    }
}