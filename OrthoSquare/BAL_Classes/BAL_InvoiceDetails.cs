using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_InvoiceDetails
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;
        public int Add_InvoiceDetails(int invid, int InvoiceNo, int patientid, int DoctorID1,int Cid, int TreatmentID, string Unit, string Cost, string Discount, string Tax, decimal TotalCost, decimal TotalDiscount, decimal TotalTax, decimal GrandTotal, string PaidAmount, string PendingAmount, int CreateID,string PayDate, int ISInvoice, string InvoiceCode,string toothno,decimal Downpayment,string FinanceType, decimal FinanceAmount,decimal RevenueAmount)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();
                decimal TotalCostAmount = Convert.ToDecimal(TotalCost) - Convert.ToDecimal(TotalDiscount);

                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceNo", InvoiceNo);

                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID1);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@Unit", Unit);
                objGeneral.AddParameterWithValueToSQLCommand("@Cost", Cost);
                objGeneral.AddParameterWithValueToSQLCommand("@Discount", Discount);
                objGeneral.AddParameterWithValueToSQLCommand("@Tax", Tax);
                objGeneral.AddParameterWithValueToSQLCommand("@TotalCost", TotalCost);
                objGeneral.AddParameterWithValueToSQLCommand("@TotalDiscount", TotalDiscount);
                objGeneral.AddParameterWithValueToSQLCommand("@TotalCostAmount", TotalCostAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@TotalTax", TotalTax);
                objGeneral.AddParameterWithValueToSQLCommand("@GrandTotal", GrandTotal);

                objGeneral.AddParameterWithValueToSQLCommand("@PaidAmount", PaidAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@PendingAmount", Convert .ToDecimal (PendingAmount));
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);
                objGeneral.AddParameterWithValueToSQLCommand("@ISInvoice", ISInvoice);
                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceCode", InvoiceCode);
                objGeneral.AddParameterWithValueToSQLCommand("@toothno", toothno);


                objGeneral.AddParameterWithValueToSQLCommand("@PayDate", objGeneral.getDatetime(PayDate));
                objGeneral.AddParameterWithValueToSQLCommand("@Downpayment", Downpayment);


                objGeneral.AddParameterWithValueToSQLCommand("@FinanceType", FinanceType);
                objGeneral.AddParameterWithValueToSQLCommand("@FinanceAmount", FinanceAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@RevenueAmount", RevenueAmount);
                if (invid > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddInvoiceDetailsNew");

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int InvoiceDetailsTritment(int Tid,int Pid,int Did,int TreatmentID, string Unit, string Cost, string Discount, string Tax,string ISInvoice,string Toothno,string sDate,string ClinicId)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Sdate", objGeneral.getDatetime(sDate));

                if (ISInvoice == "1" || ISInvoice == "2")
                {
                    strQuery = " update TreatmentbyPatient set Unit = @Unit, TreatmentsCost = @Cost, Discount = @Discount, Tex = @Tax, ISInvoice = 1,toothNo=@Toothno where ID = @Tid ";
                }
                else
                {
                    strQuery = "insert into  TreatmentbyPatient(patientid,DoctorID,TreatmentID,StartedTreatments,TreatmentsCost,IsActive,Unit,Discount,Tex,ISInvoice,toothNo,CtrateDate,ClinicId)";
                    strQuery += "  Values (@Pid,@Did,@TreatmentID,'Yes',@Cost,1,@Unit,@Discount,@Tax,1,@Toothno,@Sdate,@ClinicId)";
               
                }

                objGeneral.AddParameterWithValueToSQLCommand("@Pid", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@Tid", Tid);
                objGeneral.AddParameterWithValueToSQLCommand("@Unit", Unit);
                objGeneral.AddParameterWithValueToSQLCommand("@Cost", Cost);
                objGeneral.AddParameterWithValueToSQLCommand("@Discount", Discount);
                objGeneral.AddParameterWithValueToSQLCommand("@Tax", Tax);
                objGeneral.AddParameterWithValueToSQLCommand("@Toothno", Toothno);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicId", ClinicId);
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }







        public int InvoicePendingFUpdate(int patientid)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "Update InvoiceMaster set PendingF =0 where patientid = '" + patientid + "'";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }
             
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public int InvoiceDetilsDelete(int patientid)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "Delete from  InvoiceDetails  where patientid = '" + patientid + "'";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }

            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int Add_InvoicePaymentDetails(int InvoiceNo, string PaymentMode, string BankName, string BranchName, string CheckNo, string CheckDate, string CardNo, string BajajFinanceDoc, string ApprovalAmount, string Interest1, string TotalAMount, string ApprovalDate, string IRFCcode, string PaidAmount, string PendingAmount, int CreateID,string Finance, string PayDate)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                if (PaymentMode == "Finance")
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", Finance);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", PaymentMode);

                }
                objGeneral.AddParameterWithValueToSQLCommand("@PayDate", objGeneral.getDatetime(PayDate));
                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceNo", InvoiceNo);
                
                objGeneral.AddParameterWithValueToSQLCommand("@BankName", BankName);
                objGeneral.AddParameterWithValueToSQLCommand("@BranchName", BranchName);
                objGeneral.AddParameterWithValueToSQLCommand("@CheckNo", CheckNo);

                if (Convert.ToString(CheckDate) == "")
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@CheckDate", DBNull.Value);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@CheckDate", objGeneral.getDatetime(CheckDate));
                }

              

                objGeneral.AddParameterWithValueToSQLCommand("@CardNo", CardNo);
                objGeneral.AddParameterWithValueToSQLCommand("@BajajFinanceDoc", BajajFinanceDoc);
                objGeneral.AddParameterWithValueToSQLCommand("@IRFCcode", IRFCcode);
                objGeneral.AddParameterWithValueToSQLCommand("@PaidAmount", PaidAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@PendingAmount", PendingAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);
                objGeneral.AddParameterWithValueToSQLCommand("@ApprovalAmount", Convert .ToDecimal(ApprovalAmount));
                objGeneral.AddParameterWithValueToSQLCommand("@TotalAMount", Convert .ToDecimal(TotalAMount));
                objGeneral.AddParameterWithValueToSQLCommand("@InterestinAmount", Convert .ToDecimal(Interest1));


                if (Convert.ToString(ApprovalDate) == "")
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@ApprovalDate", DBNull.Value);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@ApprovalDate", objGeneral.getDatetime(ApprovalDate));
                }



                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddInvoicePaymentDetails");

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }






        public DataTable GetAllInvoiceDetails(int InvCode)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@InvCode ", InvCode);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@InvNo ",0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceDetails");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetMedicinesInvoiceDetails(int Cno)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Cno", Cno);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoicePatientMedicines");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public DataTable GetMedicinesClinicDetails(int Pid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Cno", "0");
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoicePatientMedicines");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetMedicinesDetailsList(int Cno)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@Cno", Cno);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoicePatientMedicines");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetAllInvoiceAmount(int InvCode)
        {
            strQuery = "Select * from InvoiceDetails ID Join TreatmentMASTER TM on TM.TreatmentID =ID.TreatmentID where InvoiceNo= '" + InvCode + "'";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllMedicinPrint(int CNo)
        {
            strQuery = "Select * From PatientMedicines PM Join MedicinesMaster MM on MM.MedicinesId=PM.MId where CNo="+CNo+"";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllInvoicePaymentDetila(int InvCode)
        {
            strQuery = "Select * from PaymentDetilas  where InvoiceNo= '" + InvCode + "'";
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllInvoicePaymentDetilainv(int InvCode)
        {
            //strQuery = "Select * from InvoiceMaster  where InvoiceNo= '" + InvCode + "'";


            strQuery = "Select PaymentMode, Im.GrandTotal,Im.payDate,IM.PaidAmount, IM.PendingAmount   From InvoiceMaster IM join PaymentDetilas PM on IM.InvoiceTid = PM.InvoiceTid where IM.InvoiceNo= '" + InvCode + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllInvoiceDetailsFid(int InvCode,string InvoiceCode)
        {
            //strQuery = "  Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += " Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName ,IM.GrandTotal - IM.PaidAmount as Pending_Amount  from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += " Join tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID Join tbl_ClinicDetails CD on CD.ClinicID =IM.ClinicID    where IM.InvoiceNo ='" + InvCode + "' and IM.InvoiceCode='" + InvoiceCode + "'";
           
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetInvoiceDetailsPayMent(int InvCode, string InvoiceCode)
        {

            string strQuery = string.Empty;
            //strQuery = "  Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            //strQuery += "  Select InvoiceNo,InvoiceCode,SUM(PaidAmount) PaidAmount,GrandTotal- SUM(PaidAmount) as PendingPayment, GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount  FROM InvoiceMaster IM   where InvoiceNo =" + InvCode + " and InvoiceCode='"+ InvoiceCode + "' ";
            //strQuery += " Group by InvoiceNo,InvoiceCode,GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount";


            strQuery += "  Select InvoiceNo,SUM(PaidAmount) PaidAmount,GrandTotal- SUM(PaidAmount) as PendingPayment, GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount  FROM InvoiceMaster IM   where InvoiceNo =" + InvCode + " ";
            strQuery += " Group by InvoiceNo,GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount";


            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetInvoiceDetailsPayMentFinance(int InvCode, string InvoiceCode)
        {

            string strQuery = string.Empty;
            //strQuery = "  Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += "  Select InvoiceNo,InvoiceCode,Downpayment,GrandTotal- Downpayment as PendingPayment, GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount,IM.RevenueAmount  FROM InvoiceMaster IM   where InvoiceNo =" + InvCode + " and InvoiceCode='" + InvoiceCode + "' ";
            strQuery += " Group by InvoiceNo,InvoiceCode,GrandTotal,TotalDiscount,TotalTax,IM.TotalCost,IM.TotalCostAmount,Downpayment,IM.RevenueAmount";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllGetAllInvoicDispaly(int ClinicID,int DoctorID,int PatientsId,string Mobile, string FromDate, string Todate)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@PatiletId", PatientsId);

                ds = objGeneral.GetDatasetByCommand_SP("GET_TestGetAllInvoicDispaly");
                //ds = objGeneral.GetDatasetByCommand_SP("GET_TestGetAllInvoicDispaly");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }


        public DataTable GetAllInvoicDispaly(int ClinicID, int DoctorID, string Name,string Mno, string FromEnquiryDate, string ToEnquiryDate)
        {
            try
            {


                // strQuery = "Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,PM.Mobile,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid ";
                // strQuery += " JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID where  PM.IsActive =1";

                strQuery = " Select  IM.GrandTotal as GrandTotal,SUM(IM.PaidAmount) as PaidAmount ,IM.GrandTotal - SUM(IM.PaidAmount) as PendingAmount,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,PM.Mobile,DD.LastName as DLastName,IM.InvoiceCode,IM.InvoiceNo ";
                strQuery += " from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID where  PM.IsActive =1";

                if (ClinicID > 0)
                    strQuery += " and IM.ClinicID=" + ClinicID + "";
                if (DoctorID > 0)
                    strQuery += " and IM.DoctorID =" + DoctorID + "";
                if (Name != "")
                    strQuery += " and PM.FristName like '%" + Name + "%'";
                if (Mno != "")
                    strQuery += " and PM.Mobile='" + Mno + "'";
                //if (FromEnquiryDate != "" && ToEnquiryDate != "")
                //    strQuery += " and convert(date,IM.PayDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";
                strQuery += " Group By PM.FristName,PM.LastName,DD.FirstName,PM.Mobile,DD.LastName,IM.InvoiceCode,IM.InvoiceNo,IM.GrandTotal order by IM.InvoiceNo DESC ";


                objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromEnquiryDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", ToEnquiryDate);

                return objGeneral.GetDatasetByCommand(strQuery);
                //objGeneral.AddParameterWithValueToSQLCommand("@InvCode ", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@patientid ", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@InvNo ", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                //ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceDetails");

            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetAllInvoicTreatment(long Pid)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@InvCode ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@InvNo ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceDetails");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetTreatmentCost(int id)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID ", id);
                ds = objGeneral.GetDatasetByCommand_SP("GET_TreatmentSelectCost");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetFinanceSchemes(int id,int  Mode)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@ID", id);
                objGeneral.AddParameterWithValueToSQLCommand("@Mode", Mode);
                ds = objGeneral.GetDatasetByCommand_SP("SP_GetFinanceSchemes");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        //public DataTable GetAllInvoicMaster(long Pid)
        //{
        //    try
        //    {

        //        objGeneral.AddParameterWithValueToSQLCommand("@InvCode ", 0);
        //        objGeneral.AddParameterWithValueToSQLCommand("@patientid ", Pid);
        //        objGeneral.AddParameterWithValueToSQLCommand("@InvNo ", 0);
        //        objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
        //        ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceDetails");
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return ds.Tables[0];
        //}



        public DataTable GetAllInvoicMaster(int Pid)
        {
            strQuery = "Select Top 1 * from InvoiceMaster where  patientid='" + Pid + "'  order by InvoiceTid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public decimal GetPaidInvoicMaster(int Pid ,int InvoiceNo)
        {
            strQuery = "Select  IsNull(Sum(PaidAmount),0)  from InvoiceMaster where  patientid=" + Pid + " and InvoiceNo ="+ InvoiceNo + "";
            return Convert .ToDecimal  (objGeneral.GetExecuteScalarByCommand(strQuery));

        }


        public decimal GetPaidInvoice(int Pid, int InvoiceNo)
        {
            strQuery = "Select  IsNull(Sum(PaidAmount),0) from InvoiceMaster where  patientid=" + Pid + " and InvoiceNo =" + InvoiceNo + "";
            return Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));

        }




        public int SaveBajaEMI(int InvoiceNo, int Patientid, string EMIsAmount, string DateofEMI)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();

                int Pid = GetPaymentDetilasMax_no();


                string strQuery = "INSERT INTO EMIBajajFinance (PaymentID,InvoiceNo,Patientid,EMIsAmount,DateofEMI)";
                strQuery += "VALUES (@PaymentID,@InvoiceNo,@Patientid,@EMIsAmount,@DateofEMI) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@PaymentID", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceNo", InvoiceNo);
                objGeneral.AddParameterWithValueToSQLCommand("@Patientid", Patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@DateofEMI", Convert.ToDateTime(DateofEMI));
                objGeneral.AddParameterWithValueToSQLCommand("@EMIsAmount", Convert .ToDecimal (EMIsAmount));
               
                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

              
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }


        public int GetPaymentDetilasMax_no()
        {
            General objGeneral = new General();

            strQuery = "select MAX(PaymentID) from PaymentDetilas ";

            return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


        }


      


        public int SaveFeedBack(int patientid, string FeedbackType, string FeedbackDetails, string FeedbackDate)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();

                int Pid = GetPaymentDetilasMax_no();


                string strQuery = "INSERT INTO FeedbackMaster (patientid,FeedbackType,FeedbackDetails,FeedbackDate,IsActive)";
                strQuery += "VALUES (@patientid,@FeedbackType,@FeedbackDetails,@FeedbackDate,1) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@FeedbackType", FeedbackType);
                objGeneral.AddParameterWithValueToSQLCommand("@FeedbackDetails", FeedbackDetails);

                objGeneral.AddParameterWithValueToSQLCommand("@FeedbackDate", objGeneral .getDatetime (FeedbackDate));

                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));


            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }


        public int DeleteInvoicie(string InvoiceNo)
        {
            int _isDeleted = -1;
            try
            {
        
                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceNo", InvoiceNo);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_DeleteInvoice");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public int Deleteinvoice(int InvoiceNo)
        {

            int NewID = 0;
            try
            {
                strQuery = "Delete From InvoiceMaster where InvoiceTid ='" + InvoiceNo + "'";
                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));


            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }


        public DataTable GetAllPayMentDetails(int Cid,int Did,string FormDate,string Todate,string PaymentMode)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@Id", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@FromdPayDate ", FormDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToPayDate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", PaymentMode);
               
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceReport");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetAllPayMentModeDetails(int Cid, int Did, string FormDate, string Todate, string PaymentMode)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@Id", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@FromdPayDate ", FormDate);
                objGeneral.AddParameterWithValueToSQLCommand("@ToPayDate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", PaymentMode);

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceReport");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetViewMedicinesInvoice(int PID)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@Cno", "0");
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", PID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoicePatientMedicines");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

    }
}