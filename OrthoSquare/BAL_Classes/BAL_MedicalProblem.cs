using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_MedicalProblem
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();

        public int AddMProblems(string name)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@name", name);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProid", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MedicalProblemMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int Add_Allergic(string Dname)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                string strQuery = "insert into AllergicMaster (allergicName,IsActive) values ('" + Dname + "','1')";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;

            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }



        public DataTable GetAllMPDetails()
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@name", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProid", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_MedicalProblemMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public int DeleteMP(int MPID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@name", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProid", MPID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MedicalProblemMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateMP(string name, int MPID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@name", name);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProid", MPID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_MedicalProblemMaster");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }
    }
}