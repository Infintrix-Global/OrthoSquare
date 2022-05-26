using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Finance
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddFinance(long Financeid, string FinanceName, string InterestRate)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@FinanceName", FinanceName);
                objGeneral.AddParameterWithValueToSQLCommand("@Financeid", Financeid);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestRate", InterestRate);
                
                if (Financeid > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Financeid");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isInserted;
        }


        public DataTable GetAllFinance()
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FinanceName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Financeid", "0");
                objGeneral.AddParameterWithValueToSQLCommand("@InterestRate", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Financeid");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

        public DataTable GetSelectFinance(int Financeid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FinanceName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Financeid", Financeid);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestRate", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Financeid");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }



        public int DeleteFinance(int Financeid)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FinanceName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Financeid", Financeid);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestRate", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Financeid");
            }
            catch (Exception ex)
            {


                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateFinance(int Financeid, string FinanceName, string InterestRate)
        {
            int isUpdated = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FinanceName", FinanceName);
                objGeneral.AddParameterWithValueToSQLCommand("@Financeid", Financeid);
                objGeneral.AddParameterWithValueToSQLCommand("@InterestRate", InterestRate);

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_Financeid");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isUpdated;
        }
    }
}