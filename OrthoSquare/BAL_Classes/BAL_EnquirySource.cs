using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_EnquirySource
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();

        public int AddEnqirySource(string Sourcename)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@Sourcename", Sourcename);
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_EnquirySourceMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllEnqirySource()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@Sourcename", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_EnquirySourceMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteEnqirySource(int ESID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@Sourcename","");
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid ", ESID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_EnquirySourceMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateEnqirySource(string Sourcename, int ESID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@Sourcename", Sourcename);
                objGeneral.AddParameterWithValueToSQLCommand("@Sourceid ", ESID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_EnquirySourceMaster");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }


        public int CountEnqirySource(string name)
        {
            int _isDeleted = -1;
            try
            {
                string str = "Select count(*) from EnquirySourceMaster where Sourcename='" + name + "'";

                _isDeleted= Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(str));
            }
            catch (Exception ex)
            {
            }
            return _isDeleted;
        }

    }
}