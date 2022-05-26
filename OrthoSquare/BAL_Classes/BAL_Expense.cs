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


        public int Add_Expense(long ExpenseID, long DoctorID, long Cid, string VendorType, string VendorName, string Amount, string ExpDate, string ExpDetails, string Expbill, int CreateID,string FromPlace,string  ToPlace)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                if (ExpenseID > 0)
                {
                    strQuery = "Update ExpenseMaster set DoctorID=@DoctorID,ClinicID=@Cid,VendorType=@VendorType,VendorName=@VendorName,Amount=@Amount,ExpDate=@ExpDate,ExpDetails=@ExpDetails,ExpBillphoto=@ExpBillphoto,ToPlace=@ToPlace,FromPlace=@FromPlace where ExpenseID =@ExpenseID";
                }
                else
                {
                    strQuery = "insert into   ExpenseMaster (DoctorID,ClinicID,VendorType,VendorName,Amount,ExpDate,ExpDetails,ExpBillphoto,CreateID,CreateDate,IsActive,FromPlace,ToPlace) values (@DoctorID,@Cid,@VendorType,@VendorName,@Amount,@ExpDate,@ExpDetails,@ExpBillphoto,@CreateID,GETDATE(),1,@FromPlace,@ToPlace)";
                }

                objGeneral.AddParameterWithValueToSQLCommand("@ExpenseID", ExpenseID);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorType", VendorType);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorName", VendorName);
                objGeneral.AddParameterWithValueToSQLCommand("@Amount", Amount);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpBillphoto", Expbill);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpDetails", ExpDetails);
                objGeneral.AddParameterWithValueToSQLCommand("@ExpDate", objGeneral .getDatetime (ExpDate));
                objGeneral.AddParameterWithValueToSQLCommand("@CreateID", CreateID);
                objGeneral.AddParameterWithValueToSQLCommand("@FromPlace", FromPlace);
                objGeneral.AddParameterWithValueToSQLCommand("@ToPlace", ToPlace);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);

                isInserted = 1;

            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public DataTable GetAllExpenSe(int cid,int did)
        {
            strQuery = "Select * from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID  Join tbl_ClinicDetails C on C.ClinicID= E.ClinicID where E.IsActive= 1 ";
            
            if(cid > 0)
                 strQuery += " and E.ClinicID =" + cid + "";
            if(did > 0)
                 strQuery += " and E.DoctorID =" + did + "";

             strQuery += " order by ExpenseID DESC";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllExpenSeReport(int Cid, int Did, string FromDate, string Todate)
        {
            strQuery = "Select * from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID Join tbl_ClinicDetails C on C.ClinicID= E.ClinicID where E.IsActive= 1";
            
            if (Cid > 0)
                strQuery += " and E.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and E.DoctorID='" + Did + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,E.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";
            strQuery += "   order by E.ExpDate DESC";

            return objGeneral.GetDatasetByCommand(strQuery);

        }






        public DataTable GetAllExpenSeReportEXL(int Cid, int Did, string FromDate, string Todate)
        {
            strQuery = "Select C.ClinicName,DD.FirstName +' '+DD.LastName as DoctorName,E.VendorName,E.Amount,E.ExpDate,E.ToPlace,E.FromPlace,E.VendorType  from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID Join tbl_ClinicDetails C on C.ClinicID= E.ClinicID where E.IsActive= 1";
            if (Cid > 0)
                strQuery += " and E.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and E.DoctorID='" + Did + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,E.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";
            strQuery += "   order by E.ExpDate DESC";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllClinicExpenSeReport(int Cid, string FromDate, string Todate)
        {
            strQuery = "Select Sum (Amount) as Total,ClinicName from ExpenseMaster EM Join tbl_ClinicDetails C on C.ClinicID = EM.ClinicID  join tbl_DoctorDetails DD on DD.DoctorID =EM.DoctorID where EM.IsActive =1 ";
           
            if (Cid > 0)
                strQuery += " and EM.ClinicID='" + Cid + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,EM.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

            strQuery += " Group by ClinicName  ";
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllDoctorExpenSeReport(int Did, string FromDate, string Todate)
        {
            strQuery = "Select Amount as Total,D.FirstName +' '+D.LastName as Dname,VendorName,ExpDate from ExpenseMaster EM Join tbl_DoctorDetails D on D.DoctorID = EM.DoctorID where EM.IsActive =1 ";
           
            if (Did > 0)
                strQuery += " and EM.DoctorID='" + Did + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,EM.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

            
            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllClinicviewExpenSeReport(int Cid, string FromDate, string Todate)
        {
            strQuery = "Select Amount as Total,ClinicName,VendorName,ExpDate from ExpenseMaster EM Join tbl_ClinicDetails C on C.ClinicID = EM.ClinicID where EM.IsActive =1 ";
            
            if (Cid > 0)
                strQuery += " and EM.ClinicID='" + Cid + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,EM.ExpDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";


            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllClinicCollectionReportNew(int Cid, string FromDate, string Todate)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,sum(PendingAmount) as PendingAmount,C.ClinicName,IM.ClinicID  from InvoiceMaster IM join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID   ";

            if (Cid > 0)
                strQuery += " where IM.ClinicID='" + Cid + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,IM.PayDate,105) between convert(date,@FromEnquiryDate,105) and convert(date,@ToEnquiryDate,105)";
            strQuery += " Group by ClinicName,IM.ClinicID  ";
            objGeneral.AddParameterWithValueToSQLCommand("@FromEnquiryDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToEnquiryDate", Todate);

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllClinicCollection_Report(string FromDate, string Todate, int ClinicID)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
               
                ds = objGeneral.GetDatasetByCommand_SP("GET_ClinicCollectionReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }



        public DataTable GetAllClinicCollectionReport(int Cid)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,sum(PendingAmount) as PendingAmount,C.ClinicName,IM.ClinicID  from InvoiceMaster IM join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID   ";
           
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

        public DataTable GetAllPatientCollectionReport(string FromDate, string Todate, int ClinicID, int DoctorID, int patientid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);


                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientCollectionReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }


        public DataTable GetAllPatientCollectionReport(int Cid,int Did, string ToDate, string FromDate,string Name)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,IM.GrandTotal - Sum(PaidAmount)  as PendingAmount,C.ClinicName,DD.FirstName as DFirstName,DD.LastName as DLastName,P.FristName,P.LastName,IM.patientid from InvoiceMaster IM  ";
            strQuery += " join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID  join tbl_DoctorDetails  DD on DD.DoctorID = IM.DoctorID  join PatientMaster  P on P.patientid = IM.patientid  where C.IsActive =1 ";
            
            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Did + "'";
            if (Name != "")
                strQuery += " and P.FristName like '%" + Name + "%'";

            if (FromDate != "" && ToDate != "")
                strQuery += " and convert(date,IM.PayDate,105) between convert(date,'" + FromDate + "',105) and convert(date,'"+ ToDate + "',105)";

            strQuery += "   Group by ClinicName,DD.FirstName,DD.LastName,P.FristName,P.LastName,IM.patientid,IM.GrandTotal ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterCollectionReport(int Cid, int Did)
        {
            strQuery = "Select Sum(PaidAmount) as PaidAmount,sum(PendingAmount) as PendingAmount,C.ClinicName,DD.FirstName ,DD.LastName,IM.ClinicID,IM.DoctorID from InvoiceMaster IM  ";
            strQuery += " join tbl_ClinicDetails  C on C.ClinicID = IM.ClinicID  join tbl_DoctorDetails  DD on DD.DoctorID = IM.DoctorID  where C.IsActive =1  ";

            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Cid + "'";
            strQuery += "  Group by ClinicName,DD.FirstName,DD.LastName,IM.ClinicID,IM.DoctorID ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterCollectionReportNew(int Cid, int Did,string FromDate, string Todate)
        {
            strQuery = "Select DBC.DoctorId,D.FirstName +' ' +D.LastName as DoctorName,D.Mobile1,IsNull(MAX(PaidAmount),0) as PaidAmount,IsNull(MAX(PendingAmount),0)as PendingAmount,IsNull(MAX(GrandTotal),0)as Total,C.ClinicName from tbl_DoctorDetails D   ";
            strQuery += " left Join DoctorByClinic DBC on D.DoctorId = DBC.DoctorID left Join tbl_ClinicDetails C on DBC.ClinicId = C.ClinicId left Join InvoiceMaster IM on DBC.ClinicId = IM.ClinicId where D.isDeleted =0 ";

            if (Cid > 0)
                strQuery += " and DBC.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and DBC.DoctorID='" + Did + "'";
            if (FromDate != "" && Todate != "")
                strQuery += " and convert(date,IM.PayDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";
            strQuery += "  Group by  D.FirstName,D.LastName,DBC.DoctorId,D.Mobile1,C.ClinicName ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllDocterCollectionReportNew11(int Cid, int Did, string FromDate, string Todate)
        {

            General objGeneral11 = new General();
            // strQuery = "Select IsNull(SUM(PaidAmount), 0) as PaidAmount,IsNull(SUM(PendingAmount), 0) as PendingAmount,IsNull(SUM(GrandTotal), 0) as Total from InvoiceMaster where ";
            strQuery = "Select IsNull(SUM(IM.PaidAmount), 0) as PaidAmount,IsNull(SUM(ID.GrandTotal), 0) as Total , IsNull(SUM(ID.GrandTotal), 0)- IsNull(SUM(IM.PaidAmount), 0)  as PendingAmount ";
            strQuery += " From InvoiceMaster IM  Join InvoiceDetails ID on IM.InvoiceNo=ID.InvoiceNo where 1=1 ";


            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Did + "'";

            if (FromDate != "" && FromDate != "")
                strQuery += " and convert(date,IM.PayDate,105) between convert(date,@FromDate,105) and convert(date,@Todate,105)";

            objGeneral11.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral11.AddParameterWithValueToSQLCommand("@Todate", Todate);
            return objGeneral11.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterCollectionAmount(int Cid, int Did, string FromDate, string Todate)
        {

            General objGeneral11 = new General();
            // strQuery = "Select IsNull(SUM(PaidAmount), 0) as PaidAmount,IsNull(SUM(PendingAmount), 0) as PendingAmount,IsNull(SUM(GrandTotal), 0) as Total from InvoiceMaster where ";
            strQuery = " Select IsNull(SUM(ID.GrandTotal), 0) as Total ,IM.PaidAmount  ";
            strQuery += "  From InvoiceMaster IM  Join InvoiceDetails ID on IM.InvoiceNo=ID.InvoiceNo where 1=1 ";


            if (Cid > 0)
                strQuery += " and IM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and IM.DoctorID='" + Did + "'";

            if (FromDate != "" && FromDate != "")
                strQuery += " and convert(date,IM.PayDate,105) between convert(date,@FromDate,105) and convert(date,@Todate,105)";
            strQuery += " Group By IM.PaidAmount ";
         
            objGeneral11.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral11.AddParameterWithValueToSQLCommand("@Todate", Todate);
            return objGeneral11.GetDatasetByCommand(strQuery);

        }

        public DataTable GetAllDocterCollectionReportNew1(string Cid, string Did)
        {
            strQuery = "Select DBC.DoctorId,D.FirstName +' ' +D.LastName as DoctorName,D.Mobile1,C.ClinicName,DBC.ClinicId,DBC.DoctorID,D.isDeleted from tbl_DoctorDetails D   ";
            strQuery += "  Join DoctorByClinic DBC on D.DoctorId = DBC.DoctorID  Join tbl_ClinicDetails C on DBC.ClinicId = C.ClinicId   ";

            if (Cid != "0")
                strQuery += " where DBC.ClinicID='" + Cid + "'";
            if (Did != "0")
                strQuery += " and DBC.DoctorID='" + Did + "'";
           
           // strQuery += "  Group by  D.FirstName,D.LastName,DBC.DoctorId,D.Mobile1,C.ClinicName,DBC.ClinicId,DBC.DoctorID ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterCollectionReportNew11(string Cid, string Did)
        {
            strQuery = "Select DBC.DoctorId,D.FirstName +' ' +D.LastName as DoctorName,D.Mobile1,C.ClinicName,DBC.ClinicId,DBC.DoctorID,D.isDeleted from tbl_DoctorDetails D   ";
            strQuery += "  Join DoctorByClinic DBC on D.DoctorId = DBC.DoctorID  Join tbl_ClinicDetails C on DBC.ClinicId = C.ClinicId  where 1=1 ";

            if (Cid != "0")
                strQuery += " and DBC.ClinicID='" + Cid + "'";
            if (Did != "")
                strQuery += " and D.FirstName +' ' +D.LastName like '%" + Did + "%'";


            // strQuery += "  Group by  D.FirstName,D.LastName,DBC.DoctorId,D.Mobile1,C.ClinicName,DBC.ClinicId,DBC.DoctorID ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }



        public DataTable GetAllDocterCollectionReportNew1Account(string FromDate, string Todate)
        {
            strQuery = "Select Sum(INV.PaidAMount) as Total,D.FirstName +' ' +D.LastName as DoctorName,C.ClinicName  From InvoiceMaster INV   left Join tbl_ClinicDetails C on INV.ClinicId = C.ClinicId    ";
            strQuery += "   left Join tbl_DoctorDetails D on D.DoctorId = INV.DoctorId    ";

            strQuery += " Where convert(date,INV.PayDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

            strQuery += "  Group BY D.FirstName, D.LastName,C.ClinicName ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllClinicbyDocNew(int Did)
        {
            strQuery = "Select C.ClinicName from  tbl_ClinicDetails C  left Join DoctorByClinic DBC on C.ClinicId = DBC.ClinicId";
        
            strQuery += " Where DBC.ClinicID='" + Did + "'";
           
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

        public DataTable GetAllFinancePayment(string FromDate, string Todate,int ClinicID,int DoctorsID, string PaymentMode)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);
                objGeneral.AddParameterWithValueToSQLCommand("@PaymentMode", PaymentMode);

               
                ds = objGeneral.GetDatasetByCommand_SP("Get_FinanceReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }


        public DataTable GetAllMedicinesCollectionReport(string FromDate, string Todate, int ClinicID, int DoctorsID, string Medicines)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", Medicines);


                ds = objGeneral.GetDatasetByCommand_SP("Get_MedicinesCollectionReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

        public DataTable GetAllTreatmentReport(string FromDate, string Todate, int ClinicID,int Mode,int TreatmentGroupid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", Mode);
                objGeneral.AddParameterWithValueToSQLCommand("@Groupid", TreatmentGroupid);


                ds = objGeneral.GetDatasetByCommand_SP("GET_TreatmentReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }


        public DataTable GetEnquiryFollowPuReport(string FromDate, string Todate, int ClinicID,int DoctorsID, string Mode)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

                objGeneral.AddParameterWithValueToSQLCommand("@mode", Mode);
           


                ds = objGeneral.GetDatasetByCommand_SP("GET_EnquiryFollowPReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

        public DataTable GET_TreatmentGroup()
        {
            try
            {
                General objGeneral = new General();
              

                ds = objGeneral.GetDatasetByCommand_SP("GET_TreatmentGroup");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

    }
}