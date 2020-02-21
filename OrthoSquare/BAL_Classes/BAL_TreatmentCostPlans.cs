using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_TreatmentCostPlans
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddTreatmentCostPlans(int CategoryID, string TreatmentID)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID", CategoryID);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);

                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCostPlansid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_TreatmentCostPlans");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetAllTreatmentCostPlans(int Cid)
        {
            try
            {
               
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", "");

                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCostPlansid ", 0);
               

                if(Cid > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@CategoryID", Cid);
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);

                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@CategoryID", 0);
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);

                }

               
                ds = objGeneral.GetDatasetByCommand_SP("SP_TreatmentCostPlans");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteTreatmentCostPlans(int TID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@CategoryID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", "");

                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCostPlansid ", TID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_TreatmentCostPlans");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


       // public int UpdateTreatment(string Treatmentname, string TreatmentCost, int TID)
        //{
        //    int isUpdated = -1;
        //    try
        //    {
        //        objGeneral.AddParameterWithValueToSQLCommand("@TreatmentName", Treatmentname);
        //        objGeneral.AddParameterWithValueToSQLCommand("@TreatmentCost", TreatmentCost);
        //        objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", TID);
        //        objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
        //        isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_TreatmentList");
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return isUpdated;
        //}

    }
}