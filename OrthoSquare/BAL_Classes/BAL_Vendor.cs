using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;


namespace OrthoSquare.BAL_Classes
{
    public class BAL_Vendor
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();


        private string strQuery = string.Empty;
        public int AddVendor(string VendorName)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();



                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);

                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_VendorMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllVendor()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName","");

                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_VendorMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteVendor(int VID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", "");

                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", VID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_VendorMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateVendor(string VendorName, int VID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);

                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", VID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_VendorMaster");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }


    }
}