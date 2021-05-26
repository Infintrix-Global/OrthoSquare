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


        public DataTable GetAllTreatmentWorkDone(int Pid)
        {

            strQuery = " Select * from TreatmentbyPatient TP left join  TreatmentMASTER T  on  T.TreatmentID = TP. TreatmentID where T.IsActive =1 and  StartedTreatments='YES' ";
          
            if (Pid > 0)
                strQuery += " and  TP.patientid="+ Pid + " ";

            return objGeneral.GetDatasetByCommand(strQuery);
        }



        public DataTable GetTax()
        {

            strQuery = " Select * from GSTRateMaster where IsActive =1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }



        public DataTable GetTreatmentPatientCount(string year,string Months,string Did)
        {

            strQuery = " Select TM.TreatmentName, COUNT(TBP.patientid) PatientTotal from TreatmentMASTER TM left join TreatmentbyPatient TBP on TBP.TreatmentID= TM.TreatmentID left join PatientMaster P on P.patientid= TBP.patientid  where TM.IsActive=1 and P.isActive=1 ";

            if(Did !="")
                strQuery += " and TBP.DoctorID in ("+ Did + ") ";
            if (year != "")
                strQuery += " and year(TBP.CtrateDate) ='" + year + "'  ";
            if (Months != "")
                strQuery += " and Month(TBP.CtrateDate) ='" + Months + "'  ";

            strQuery += " group by TM.TreatmentName";
            
            return objGeneral.GetDatasetByCommand(strQuery);
        }

        public int CountTritment(string name)
        {
            int _isDeleted = -1;
            string str = "Select count(*) from TreatmentMASTER where TreatmentName='" + name + "'";

            return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(str));
        }


        public DataTable GetTreatmentbyPatient(int Did,int Tid, string FromEnquiryDate, string ToEnquiryDate)
        {

            strQuery = "Select DISTINCT  TBP.patientid,PM.FristName +' '+ PM.LastName as Pname,DM.FirstName +' '+ DM.LastName as Dname,TBP.CtrateDate from  TreatmentbyPatient TBP  left Join PatientMaster PM on PM.patientid =TBP.patientid Join tbl_DoctorDetails DM on DM.DoctorID = TBP.DoctorID where TBP.IsActive=1";

            if (Did  > 0)
                strQuery += " and TBP.DoctorID ='" + Did + "'  ";
            if (Tid > 0)
                strQuery += " and TBP.TreatmentID ='" + Tid + "'  ";
            if (FromEnquiryDate != "" && ToEnquiryDate != "")
                strQuery += " and convert(date,TBP.CtrateDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";



            return objGeneral.GetDatasetByCommand(strQuery);
        }

        public DataTable GetDoctorByClinicnew(int cid)
        {

            strQuery = " Select DBC.DoctorID from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1   and D.IsDeleted=0";
          
            if (cid > 0)
                strQuery += "and DBC.ClinicID ="+ cid + "";


            return objGeneral.GetDatasetByCommand(strQuery);
        }

    }
}