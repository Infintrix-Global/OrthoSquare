using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Treatment
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

      
        private string strQuery = string.Empty;
        public int AddTreatment(string Treatmentname, string TreatmentCost)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentName", Treatmentname);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCost", TreatmentCost);
               
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_TreatmentList");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllTreatment()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCost", "");
               
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_TreatmentList");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteTreatment(int TID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentName","");
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCost","");
               
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", TID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_TreatmentList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateTreatment(string Treatmentname, string TreatmentCost, int TID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentName", Treatmentname);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCost", TreatmentCost);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", TID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_TreatmentList");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }



        public DataTable GetAllTreatment11()
        {

            strQuery = " Select * from TreatmentMASTER where IsActive =1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }


        public DataTable GetTax()
        {

            strQuery = " Select * from GSTRateMaster where IsActive =1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }

    }
}