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
        public int Add_InvoiceDetails(int invid, int InvoiceNo, int patientid, int DoctorID1,int Cid, int TreatmentID, string Unit, string Cost, string Discount, string Tax, decimal TotalCost, decimal TotalDiscount, decimal TotalTax, decimal GrandTotal, string PaidAmount, string PendingAmount, int CreateID,string PayDate)
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
                objGeneral.AddParameterWithValueToSQLCommand("@PayDate", objGeneral.getDatetime(PayDate));
                


                if (invid > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddInvoiceDetails");

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int InvoiceDetailsTritment(int Tid,int Pid,int Did,int TreatmentID, string Unit, string Cost, string Discount, string Tax,string ISInvoice)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                if (ISInvoice == "1" || ISInvoice == "2")
                {
                    strQuery = " update TreatmentbyPatient set Unit = @Unit, TreatmentsCost = @Cost, Discount = @Discount, Tex = @Tax, ISInvoice = 1 where ID = @Tid ";
                }
                else
                {
                    strQuery = "insert into  TreatmentbyPatient(patientid,DoctorID,TreatmentID,StartedTreatments,TreatmentsCost,IsActive,Unit,Discount,Tex,ISInvoice,CtrateDate)";
                    strQuery += "  Values (@Pid,@Did,@TreatmentID,'Yes',@Cost,1,@Unit,@Discount,@Tax,1,GETDATE())";
               
                }

                objGeneral.AddParameterWithValueToSQLCommand("@Pid", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@TreatmentID", TreatmentID);
                objGeneral.AddParameterWithValueToSQLCommand("@Tid", Tid);
                objGeneral.AddParameterWithValueToSQLCommand("@Unit", Unit);
                objGeneral.AddParameterWithValueToSQLCommand("@Cost", Cost);
                objGeneral.AddParameterWithValueToSQLCommand("@Discount", Discount);
                objGeneral.AddParameterWithValueToSQLCommand("@Tax", Tax);
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


        public int Add_InvoicePaymentDetails(int InvoiceNo, string PaymentMode, string BankName, string BranchName, string CheckNo, string CheckDate, string CardNo, string BajajFinanceDoc, string ApprovalAmount, string Interest1, string TotalAMount, string ApprovalDate, string IRFCcode, string PaidAmount, string PendingAmount, int CreateID,string Finance)
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


        public DataTable GetAllInvoiceAmount(int InvCode)
        {
            strQuery = "Select * from InvoiceDetails ID Join TreatmentMASTER TM on TM.TreatmentID =ID.TreatmentID where InvoiceNo= '" + InvCode + "'";
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllInvoicePaymentDetila(int InvCode)
        {
            strQuery = "Select * from PaymentDetilas  where InvoiceNo= '" + InvCode + "'";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllInvoiceDetailsFid(int InvCode,string InvoiceCode)
        {
            //strQuery = "  Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += " Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName ,IM.GrandTotal - IM.PaidAmount as Pending_Amount  from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += " Join tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID Join tbl_ClinicDetails CD on CD.ClinicID =IM.ClinicID    where IM.InvoiceNo ='" + InvCode + "' and IM.InvoiceCode='" + InvoiceCode + "'";
           
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllInvoicDispaly(int ClinicID, int DoctorID, string Name,string Mno, string FromEnquiryDate, string ToEnquiryDate)
        {
            try
            {


                // strQuery = "Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,PM.Mobile,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid ";
                // strQuery += " JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID where  PM.IsActive =1";
                strQuery = " Select  IM.GrandTotal as GrandTotal,SUM(IM.PaidAmount) as PaidAmount ,IM.GrandTotal - SUM(IM.PaidAmount) as PendingAmount,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,PM.Mobile,DD.LastName as DLastName,IM.InvoiceCode,IM.InvoiceNo,convert(date,PayDate,105) as PayDate,IM.InvoiceTid ";
                strQuery += " from InvoiceMaster IM join PatientMaster PM on PM.patientid = IM.patientid JOin tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID where  PM.IsActive =1";



                if (ClinicID > 0)
                    strQuery += " and IM.ClinicID=" + ClinicID + "";
                if(DoctorID > 0)
                     strQuery += " and IM.DoctorID ="+DoctorID+""; 
                if(Name != "")
                    strQuery += " and PM.FristName like '%" + Name + "%'";
                if (Mno != "")
                    strQuery += " and PM.Mobile='" + Mno + "'";
                if (FromEnquiryDate != "" && ToEnquiryDate != "")
                    strQuery += " and convert(date,IM.PayDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";
                strQuery += " Group By PM.FristName,PM.LastName,DD.FirstName,PM.Mobile,DD.LastName,IM.InvoiceCode,IM.InvoiceNo,IM.GrandTotal,IM.InvoiceTid,convert(date,PayDate,105) Order by IM.InvoiceTid DESC";

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

        public decimal GetPaidInvoicMaster(int Pid)
        {
            strQuery = "Select  IsNull(Sum(PaidAmount),0)  from InvoiceMaster where  patientid=" + Pid + "";
            return Convert .ToDecimal  (objGeneral.GetExecuteScalarByCommand(strQuery));

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

    }
}