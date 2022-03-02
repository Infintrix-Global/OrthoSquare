using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_LabMasterNew
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddLab(long Lid, string Name, string CommissionType, string Commission,int CreateBy)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@LabName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@LabId", Lid);
                objGeneral.AddParameterWithValueToSQLCommand("@CommissionType", CommissionType);
                objGeneral.AddParameterWithValueToSQLCommand("@Commission", Commission);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", CreateBy);

                if (Lid > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_LabMasterNew");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isInserted;
        }


        public DataTable GetAllLab()
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@LabName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@LabId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@CommissionType", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Commission", "");
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_LabMasterNew");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

        public DataTable GetSelectLab(int LID)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@LabName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@LabId", LID);
                objGeneral.AddParameterWithValueToSQLCommand("@CommissionType", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Commission", "");
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_LabMasterNew");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }



        public int DeleteLab(int LID)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@LabName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@LabId", LID);
                objGeneral.AddParameterWithValueToSQLCommand("@CommissionType", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Commission", "");
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_LabMasterNew");
            }
            catch (Exception ex)
            {


                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateLab(string Name, string CommissionType, string Commission, int LID)
        {
            int isUpdated = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@LabName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@LabId", LID);
                objGeneral.AddParameterWithValueToSQLCommand("@CommissionType", CommissionType);
                objGeneral.AddParameterWithValueToSQLCommand("@Commission", Commission);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateBy", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_LabMasterNew");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isUpdated;
        }
    }
}