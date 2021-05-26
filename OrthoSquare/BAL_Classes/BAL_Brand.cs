using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_Brand
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddBrand(string Name)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@BrandName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Brand");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllBrand()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@BrandName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Brand");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteBrand(int BID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@BrandName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Brand");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateBrand(string Name, int BID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@BrandName", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_Brand");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }
    }
}