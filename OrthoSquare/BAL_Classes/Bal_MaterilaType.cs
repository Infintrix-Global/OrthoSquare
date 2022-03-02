using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace OrthoSquare.BAL_Classes
{
    public class Bal_MaterilaType
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddMaterialType(long MaterialTypeId, string Name, string IsMedical)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", MaterialTypeId);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", IsMedical);


                if (MaterialTypeId > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);

                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MaterialType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isInserted;
        }


        public DataTable GetAllMaterialType(string Name, string IsMedical)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", IsMedical);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_MaterialType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }



        public int DeleteMaterialType(int MaterialTypeId)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", MaterialTypeId);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MaterialType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _isDeleted;
        }


        public DataTable GetSelectMaterialTYpe(int MaterialTypeId)
        {
            try
            {
                General objGeneral = new General();
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", MaterialTypeId);
                objGeneral.AddParameterWithValueToSQLCommand("@IsMedical", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_MaterialType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }
    }
}