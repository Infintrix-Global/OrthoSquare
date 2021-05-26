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
        public int AddVendor(long vid,string VendorName, string Mobile, int VendorTypeid, int ClinicID)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();



                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", VendorTypeid);


                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", vid);


                if (vid > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                }
                else
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }

               
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_VendorMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllVendor(int Cid,int Vtype)
        {
            
                strQuery = "Select * from VendorMaster V Join VendorTypeMaster VT on VT.VendorTypeId =V.VendorTypeId Join tbl_ClinicDetails CD on CD.ClinicID =v.ClinicID  where V.IsActive =1";
                if (Cid > 0)
                    strQuery += " and V.ClinicID=" + Cid + "";
                if (Vtype > 0)
                    strQuery += " and V.VendorTypeId=" + Vtype + "";
                return objGeneral.GetDatasetByCommand(strQuery);
           
        }

        public DataTable GetAllVendorNew()
        {
            strQuery = "Select * from VendorMaster V Join VendorTypeMaster VT on VT.VendorTypeId =V.VendorTypeId where V.IsActive =1 and VT.VendorTypeId=2";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllVendorSelect(int vid)
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", "");

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", "");


                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", vid);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
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
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", "");
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", "");


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


     


        public int UpdateVendor(string VendorName, string Mobile, int VID, int ClinicID, int VendorTypeid)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID ", VID);

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorTypeId", VendorTypeid);

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