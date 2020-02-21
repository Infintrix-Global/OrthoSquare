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
        public int Add_InvoiceDetails(int invid, int InvoiceNo, int patientid, int DoctorID1,int Cid, int TreatmentID, string Unit, string Cost, string Discount, string Tax, decimal TotalCost, decimal TotalDiscount, decimal TotalTax, decimal GrandTotal, string PaidAmount, string PendingAmount, int CreateID)
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
                objGeneral.AddParameterWithValueToSQLCommand("@PendingAmount", PendingAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);



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



        public int Add_InvoicePaymentDetails(int InvoiceNo, string PaymentMode, string BankName, string BranchName, string CheckNo, string CheckDate, string CardNo, string BajajFinanceDoc, string IRFCcode, string PaidAmount, string PendingAmount, int CreateID)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();
               
                objGeneral.AddParameterWithValueToSQLCommand("@InvoiceNo", InvoiceNo);



                objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", PaymentMode);
                objGeneral.AddParameterWithValueToSQLCommand("@BankName", BankName);
                objGeneral.AddParameterWithValueToSQLCommand("@BranchName", BranchName);
                objGeneral.AddParameterWithValueToSQLCommand("@CheckNo", CheckNo);
            
                objGeneral.AddParameterWithValueToSQLCommand("@CheckDate", CheckDate);
                objGeneral.AddParameterWithValueToSQLCommand("@CardNo", CardNo);
                objGeneral.AddParameterWithValueToSQLCommand("@BajajFinanceDoc", BajajFinanceDoc);
                objGeneral.AddParameterWithValueToSQLCommand("@IRFCcode", IRFCcode);
              

                objGeneral.AddParameterWithValueToSQLCommand("@PaidAmount", PaidAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@PendingAmount", PendingAmount);
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);



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
            strQuery += " Select *,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName as DFirstName,DD.LastName as DLastName from InvoiceMaster IM join PatientMaster PM on PM.patientid= IM.patientid ";
            strQuery += " Join tbl_DoctorDetails DD on DD.DoctorID = IM.DoctorID Join tbl_ClinicDetails CD on CD.ClinicID =IM.CreateID    where IM.InvoiceNo ='" + InvCode + "' and IM.InvoiceCode='" + InvoiceCode + "'";
            return objGeneral.GetDatasetByCommand(strQuery);

        }




        public DataTable GetAllInvoicDispaly()
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@InvCode ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@InvNo ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                ds = objGeneral.GetDatasetByCommand_SP("GET_InvoiceDetails");
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
    }
}