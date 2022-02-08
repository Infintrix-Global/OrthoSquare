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

        public DataTable GetLabsInoutReport(long Pid, int cid)
        {

            //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            //objGeneral.AddParameterWithValueToSQLCommand("@Labid", Lid);
            //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");

            strQuery = " Select * from LabDetails  LD Join LabMaster LM on LM.Labid= LD.Labid Join TypeofWorkLab T on T.TypeOfworkId = LD.TypeOfworkId Join PatientMaster PM  on PM.patientid = LD.patientid where LM.IsActive = 1 ";

            if (Pid > 0)
                strQuery += "  and LD.patientid='" + Pid + "'";
            if (cid > 0)
                strQuery += "  and PM.ClinicID='" + cid + "'";
          
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetLabsInoutReportnew(string Fname,string Lname,string LabName,int cid)
        {

            //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            //objGeneral.AddParameterWithValueToSQLCommand("@Labid", Lid);
            //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");

            strQuery = " Select * from LabDetails  LD Join LabMaster LM on LM.Labid= LD.Labid Join TypeofWorkLab T on T.TypeOfworkId = LD.TypeOfworkId Join PatientMaster PM  on PM.patientid = LD.patientid where LM.IsActive = 1 ";

          
            if (cid > 0)
                strQuery += "  and PM.ClinicID='" + cid + "'";
            if (Fname != "")
                strQuery += " and PM.FristName like '%" + Fname + "%'";
            if (Lname != "")
                strQuery += " and PM.LastName like '%" + Lname + "%'";
            if (Lname != "")
                strQuery += " and LM.LabName like '%" + Lname + "%'";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetLabs(int Cid)
        {
            try
            {

                strQuery = "Select * from LabMaster LM Join PatientMaster PM on PM.patientid=LM.patientid Join TypeofWorkLab TL on TL.TypeOfworkId = LM.TypeOfworkId Join tbl_ClinicDetails CD on CD.ClinicId = PM.ClinicId Where LM.IsActive =1 and PM.IsActive =1 ";
              
                if (Cid > 0)
                    strQuery += " and PM.ClinicID=" + Cid + " ";
                strQuery += " order by Labid DESC";
                // objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                // objGeneral.AddParameterWithValueToSQLCommand("@Labid",0);
                return objGeneral.GetDatasetByCommand(strQuery);



            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }

          public DataTable GetLabsViewDetsils(int Pid)
        {
           

               strQuery ="Select * from LabMaster LM Join PatientMaster PM on PM.patientid=LM.patientid Join TypeofWorkLab TL on TL.TypeOfworkId = LM.TypeOfworkId";
               strQuery += " Where LM.IsActive =1 and PM.IsActive =1 and LM.patientid='" + Pid + "'";

               return objGeneral.GetDatasetByCommand(strQuery);


                //objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                //objGeneral.AddParameterWithValueToSQLCommand("@Labid",0);
                //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");



        }





        public DataTable GetLabsViewDetsilsNEW(long Pid)
        {


            strQuery = "Select * from LabMaster LM  Join TypeofWorkLab TL on TL.TypeOfworkId = LM.TypeOfworkId";
            strQuery += " Where LM.IsActive =1 and LM.patientid='" + Pid + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


            //objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
            //objGeneral.AddParameterWithValueToSQLCommand("@Labid",0);
            //ds = objGeneral.GetDatasetByCommand_SP("GET_Labs");



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