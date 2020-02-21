using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_LabsDetails
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;
        public int Add_LabDetails(LabDetails objLab)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@Labid", objLab.Labid);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", objLab.patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@TypeOfworkId", objLab.TypeOfworkId);
                objGeneral.AddParameterWithValueToSQLCommand("@LabName", objLab.LabName);
                objGeneral.AddParameterWithValueToSQLCommand("@ToothNo", objLab.ToothNo);
                objGeneral.AddParameterWithValueToSQLCommand("@OutwardDate",objGeneral.getDatetime (objLab.OutwardDate));
                objGeneral.AddParameterWithValueToSQLCommand("@InwardDate", objGeneral.getDatetime(objLab.InwardDate));
                objGeneral.AddParameterWithValueToSQLCommand("@Workcompletion", objLab.Workcompletion);
                objGeneral.AddParameterWithValueToSQLCommand("@Notes", objLab.Notes);
                objGeneral.AddParameterWithValueToSQLCommand("@billuplod", objLab.billuplod);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", objLab.CreateID);
                objGeneral.AddParameterWithValueToSQLCommand("@WorkStatus", objLab.WorkStatus);

                if (objLab.Labid > 0)
                {


                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("sp_AddLabDetails");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public DataTable GetLabsInoutReport(long Pid)
        {

            //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            //objGeneral.AddParameterWithValueToSQLCommand("@Labid", Lid);
            //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");

            strQuery = " Select * from LabDetails  LD Join LabMaster LM on LM.Labid= LD.Labid Join TypeofWorkLab T on T.TypeOfworkId = LD.TypeOfworkId Join PatientMaster PM  on PM.patientid = LD.patientid where LM.IsActive = 1 ";

            if (Pid > 0)
                strQuery += "  and LD.patientid='" + Pid + "'";

            return objGeneral.GetDatasetByCommand(strQuery);




        }


        public DataTable GetLabs()
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@Labid",0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }


        public DataTable GetLabsDetails(long Lid)
        {
            try
            {

                //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                //objGeneral.AddParameterWithValueToSQLCommand("@Labid", Lid);
                //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");

                strQuery = " Select Top 1 * From LabDetails where  Labid ='" + Lid + "' order by TLabid DESC";
                return objGeneral.GetDatasetByCommand(strQuery);


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }




        public DataTable GetLabsSelect(long Lid)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@Labid", Lid);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }

        public int DeleteLab(int LID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                objGeneral.AddParameterWithValueToSQLCommand("@Labid", LID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }
    }
}