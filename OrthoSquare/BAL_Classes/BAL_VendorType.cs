using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_VendorType
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddVendorType(string Name)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@VendorType", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_VendorType");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllVendorType()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorType", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_VendorType");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteVendorType(int BID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@VendorType", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_VendorType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateVendorType(string Name, int BID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@VendorType", Name);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", BID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_VendorType");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }
    }
}