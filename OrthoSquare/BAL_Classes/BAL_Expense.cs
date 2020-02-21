using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace OrthoSquare.BAL_Classes
{
    public class BAL_Expense
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;


        public int Add_Expense(long ExpenseID, long DoctorID,long Cid, string VendorName, string Amount, string ExpDate,string ExpDetails,string Expbill, int CreateID)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                if (ExpenseID > 0)
                {
                    strQuery = "Update ExpenseMaster set DoctorID=@DoctorID,VendorName=@VendorName,Amount=@Amount,ExpDate=@ExpDate,ExpDetails=@ExpDetails,ExpBillphoto=@ExpBillphoto where ExpenseID =@ExpenseID";
                }
                else
                {
                    strQuery = "insert into   ExpenseMaster (DoctorID,ClinicID,VendorName,Amount,ExpDate,ExpDetails,ExpBillphoto,CreateID,CreateDate,IsActive) values (@DoctorID,@Cid,@VendorName,@Amount,@ExpDate,@ExpDetails,@ExpBillphoto,@CreateID,GETDATE(),1)";
                }

                objGeneral.AddParameterWithValueToSQLCommand("@ExpenseID", ExpenseID);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);
                objGeneral.AddParameterWithValueToSQLCommand("@Amount", Amount);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpBillphoto", Expbill);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpDetails", ExpDetails);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpDate", objGeneral .getDatetime (ExpDate));
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public DataTable GetAllExpenSe()
        {
            strQuery = "Select * from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID where E.IsActive= 1 order by ExpenseID DESC";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllExpenSeReport(int Cid, int Did, string FromDate, string Todate)
        {
            strQuery = "Select * from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID where E.IsActive= 1";
            if (Cid > 0)
                strQuery += " and E.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and E.DoctorID='" + Did + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,E.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";


            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllClinicExpenSeReport(int Cid, string FromDate, string Todate)
        {
            strQuery = "Select Sum (Amount) as Total,ClinicName from ExpenseMaster EM Join tbl_ClinicDetails C on C.ClinicID = EM.ClinicID where EM.IsActive =1 ";
            if (Cid > 0)
                strQuery += " and EM.ClinicID='" + Cid + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,EM.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

            strQuery += " Group by ClinicName  ";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllClinicCollectionReport(int Cid)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,C.ClinicName,IM.ClinicID  from InvoiceMaster IM join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID   ";
            if (Cid > 0)
                strQuery += " where IM.ClinicID='" + Cid + "'";

            strQuery += " Group by ClinicName,IM.ClinicID  ";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public decimal GetPendingAmount(int Cid,int Did,int Pid)
        {
            //General objGeneral = new General();
            //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            //objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            //objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            //objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);

            if (Cid > 0)
            {
                strQuery = " Select Sum(PendingAmount) PendingAmount  from InvoiceMaster where PendingF =1 and ClinicID='" + Cid + "'";
            }
            if (Cid > 0 && Did > 0)
            {

                strQuery = " Select Sum(PendingAmount) PendingAmount  from InvoiceMaster where PendingF =1 and ClinicID='" + Cid + "' and DoctorID='"+Did+"'";

            }


            return Convert .ToDecimal (objGeneral.GetExecuteScalarByCommand(strQuery));

           //  objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


        }



        public DataTable GetAllPatientCollectionReport(int Cid,int Did)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,C.ClinicName,DD.FirstName as DFirstName,DD.LastName as DLastName,P.FristName,P.LastName,IM.patientid from InvoiceMaster IM  ";
            strQuery += " join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID  join tbl_DoctorDetails  DD on DD.DoctorID = IM.DoctorID  join PatientMaster  P on P.patientid = IM.patientid  where C.IsActive =1 ";
            
            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Cid + "'";
            strQuery += "   Group by ClinicName,DD.FirstName,DD.LastName,P.FristName,P.LastName,IM.patientid  ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterCollectionReport(int Cid, int Did)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,C.ClinicName,DD.FirstName ,DD.LastName,IM.ClinicID,IM.DoctorID from InvoiceMaster IM  ";
            strQuery += " join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID  join tbl_DoctorDetails  DD on DD.DoctorID = IM.DoctorID  where C.IsActive =1  ";

            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Cid + "'";
            strQuery += "  Group by ClinicName,DD.FirstName,DD.LastName,IM.ClinicID,IM.DoctorID ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }





        public int DeleteExp(int EID)
        {
            int _isDeleted = -1;
            try
            {
                strQuery = "Update ExpenseMaster set  IsActive=0 where ExpenseID='" + EID + "'";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);

               
                // = objGeneral.GetDatasetByCommand_SP("GET_Labs");
                _isDeleted = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }
    }
}