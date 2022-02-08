using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_ConsultationAddTreatment
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;


        public DataTable GetConsultationAddTreatment(long patientid)
        {

            try
            {


                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                ds = objGeneral.GetDatasetByCommand_SP("Get_ConsultationAddTreatment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public List<invoiceDetils> GetInvoiceDetailsyId(long PID)
        {
            List<invoiceDetils> objtWorkorderEmployeesInfo = new List<invoiceDetils>();
            try
            {
                General objGeneral = new General();
                //strQuery = "SELECT WE.*,Emp.Title+' '+Emp.FirstName+' '+Emp.MiddleName+' '+Emp.Surname as EmployeeName " +
                //    " FROM WorkorderEmployees WE Left outer join tblEmployeePersonal Emp on WE.EmployeeID=Emp.EmployeeID " +
                //    " WHERE  WE.WorkOrderID ='" + WorkOrderID + "' and WE.IsActive='1'";


                strQuery = "Select * from TreatmentbyPatient where IsActive =1 and patientid='" + PID + "' and StartedTreatments ='Yes'";

                DataTable dtExpInfo = objGeneral.GetDatasetByCommand(strQuery);
                if (dtExpInfo != null && dtExpInfo.Rows.Count > 0)
                {
                    int RowCNT = 1;

                    foreach (DataRow item in dtExpInfo.Rows)
                    {
                        string TCost = "0", TUNit = "0", TDiscount = "0";

                        if (item["TreatmentsCost"].ToString() == "")
                        {
                            TCost ="0";
                        }
                        else
                        {
                            TCost=item["TreatmentsCost"].ToString();
                        }



                        if (item["Unit"].ToString() == "")
                        {
                            TUNit = "0";
                        }
                        else
                        {
                            TUNit = item["Unit"].ToString();
                        }

                        if (item["Discount"].ToString() == "")
                        {
                            TDiscount = "0";
                        }
                        else
                        {
                            TDiscount = item["Discount"].ToString();
                        }


                        invoiceDetils objNewRow = new invoiceDetils();
                        objNewRow.ID = Convert.ToInt32(item["ID"]);
                        objNewRow.TreatmentID = Convert.ToInt32(item["TreatmentID"]);
                        objNewRow.Cost = TCost;
                        objNewRow.Unit = TUNit;
                        objNewRow.Discount = TDiscount;
                        objNewRow.Tex = "0";
                        objNewRow.ISInvoice = Convert.ToInt32(item["ISInvoice"]);
                        objNewRow.RowNumber = RowCNT;


                        objtWorkorderEmployeesInfo.Add(objNewRow);
                        RowCNT++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objtWorkorderEmployeesInfo;
        }











        public int Add_TreatmentbyPatient(long pid, long Did, string Tid)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", pid);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", Tid);

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("Get_ConsultationAddTreatment");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public DataTable GetMedicalHistoryDetails(long patientid1)
        {

            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid1);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", "");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                ds = objGeneral.GetDatasetByCommand_SP("Get_ConsultationAddTreatment");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public int Add_PTGallreryDetails(long PTID, long patientid, long TreatmentID, string Remoarks, string TreatmentImage)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@PTID", PTID);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@Remoarks", Remoarks);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentImage", TreatmentImage);




                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);



                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddPatientTreatmentImage");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }




        public int Add_complaintinsert(long patientid, string Complaint, string DentalTreatment, string ToothNo, int Doctorid)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "insert into PatientbyDentalinfo (patientid,Complaint,DentalTreatment,ToothNo,CreateOn,DoctorID) values(@patientid,@Complaint,@DentalTreatment,@ToothNo,GETDATE(),@Doctorid) ";


                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@Complaint", Complaint);
                objGeneral.AddParameterWithValueToSQLCommand("@DentalTreatment", DentalTreatment);
                objGeneral.AddParameterWithValueToSQLCommand("@ToothNo", ToothNo);
                objGeneral.AddParameterWithValueToSQLCommand("@Doctorid", Doctorid);


                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;


            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }





        public int Add_Medicines(long patientid, string MedicinesName, string txtMtype, string TotalMedicines, string DayMedicines, string MorningMedicines, string AfternoonMedicines, string EveningMedicines, string Remarks)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "insert into PatientMedicines (patientid,MedicinesName,txtMtype,TotalMedicines,DayMedicines,MorningMedicines,AfternoonMedicines,EveningMedicines,Remarks,IsActive) ";
                strQuery += " values(@patientid,@MedicinesName,@txtMtype,@TotalMedicines,@DayMedicines,@MorningMedicines,@AfternoonMedicines,@EveningMedicines,@Remarks,1) ";


                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", MedicinesName);
                objGeneral.AddParameterWithValueToSQLCommand("@TotalMedicines", TotalMedicines);
                objGeneral.AddParameterWithValueToSQLCommand("@DayMedicines", DayMedicines);
                objGeneral.AddParameterWithValueToSQLCommand("@MorningMedicines", MorningMedicines);
                objGeneral.AddParameterWithValueToSQLCommand("@AfternoonMedicines", AfternoonMedicines);
                objGeneral.AddParameterWithValueToSQLCommand("@EveningMedicines", EveningMedicines);
                objGeneral.AddParameterWithValueToSQLCommand("@Remarks", Remarks);
                objGeneral.AddParameterWithValueToSQLCommand("@txtMtype", txtMtype);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;


            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public DataTable GetAdd_Medicines(long Pid)
        {
            try
            {



                strQuery = "Select * from PatientMedicines where IsActive=1";

                if (Pid > 0)
                    strQuery += " and patientid ='" + Pid + "'";


                return objGeneral.GetDatasetByCommand(strQuery);



            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }



        public DataTable GetPTGallery(long Pid)
        {
            try
            {

                //objGeneral.AddParameterWithValueToSQLCommand("@PTID", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@patientid", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@Remoarks", "");
                //objGeneral.AddParameterWithValueToSQLCommand("@TreatmentImage", "");
                //objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                //ds = objGeneral.GetDatasetByCommand_SP("SP_AddPatientTreatmentImage");

                strQuery = "Select Top 8 * from PatientTreatmentImage where IsActive=1";

                if (Pid > 0)
                    strQuery += " and patientid ='" + Pid + "'";
                strQuery += " ORDER BY PTID DESC";

                return objGeneral.GetDatasetByCommand(strQuery);



            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }




        public int Update_TreatmentbyPatient(long TPID, string Cost, string Tooth, string StartedTreatments, string Notes, string sdate)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Sdate", objGeneral.getDatetime(sdate));

                strQuery = "update  TreatmentbyPatient set toothNo='" + Tooth + "',TreatmentsCost='" + Cost + "',StartedTreatments ='" + StartedTreatments + "',TNotes ='" + Notes + "',ISInvoice='2' ,CtrateDate=@Sdate where ID='" + TPID + "' ";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int Update_TreatmentbyPatientYES(long TPID, string Cost, string Tooth, string StartedTreatments, string Notes, string sDate)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Sdate", objGeneral.getDatetime(sDate));

                strQuery = "update  TreatmentbyPatient set toothNo='" + Tooth + "',TreatmentsCost='" + Cost + "',StartedTreatments ='" + StartedTreatments + "',TNotes ='" + Notes + "',ISInvoice='2',CtrateDate=@Sdate where ID='" + TPID + "' ";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public int Update_TreatmentbyPatientWorkDone(int Pid, int TreatmentbyPatientID, string TootNo, string Notes)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                //   strQuery = "update  TreatmentbyPatient set toothNo='" + Tooth + "',TreatmentsCost='" + Cost + "',StartedTreatments ='" + StartedTreatments + "',TNotes ='" + Notes + "',ISInvoice='2',CtrateDate=GETDATE() where ID='" + TPID + "' ";

                strQuery = "insert into TreatmentStartedNotes (TreatmentbyPatientID,patientid,TootNo,Notes,CreateDate) values('" + TreatmentbyPatientID + "','" + Pid + "','" + TootNo + "','" + Notes + "',GETDATE())";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public int Delete_TreatmentbyPatient(long TPID)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "update  TreatmentbyPatient set IsActive=0 where ID='" + TPID + "' ";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int Add_TreatmentbyPlan(long Pid, int Did, string PlanDetails)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "insert into   TreatmentPlan (patientid,DoctorID,PlanDetails,IsActive,CreateOn) values ('" + Pid + "','" + Did + "','" + PlanDetails + "',1,GETDATE())  ";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable GetPTTreatmentPlan(long Pid)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select *,D.FirstName +' '+ D.LastName as DName from TreatmentPlan TP join tbl_DoctorDetails D on D.DoctorID =TP.DoctorID where TP.IsActive =1";

                if (Pid > 0)
                    strQuery += " and TP.patientid ='" + Pid + "'";


                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public DataTable GetMedicinesName(long Pid)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from PatientMedicines  where patientid ='" + Pid + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {

            }
            return dt;

        }

        public DataTable GetTreatmentStartedNotesWorkDone(int Pid)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select T.TreatmentName,TP.TootNo,TP.Notes,TP.CreateDate from TreatmentStartedNotes  TP left join  TreatmentbyPatient TSN  on  TSN.ID = TP. TreatmentbyPatientID ";
                strQuery += " left join  TreatmentMASTER T  on  T.TreatmentID = TSN. TreatmentID  where TSN.IsActive =1 ";
                strQuery += " and TP.patientid= '" + Pid + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);


            }
            catch (Exception ex)
            {

            }
            return dt;
        }




        public int Update_PCstatus(long Pid, string PCstatus)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "update  PatientMaster set PCstatus='" + PCstatus + "' where patientid='" + Pid + "' ";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

    }
}