using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;


public class clsCommonMasters
{


    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    General objGeneral = new General();
    //DataSet ds = new DataSet();
    private string strQuery = string.Empty;
    public DataTable CountryMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);

            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);

            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }

    public DataTable GetIssueList(int empid, string IssueType, string Status, string FromDate, string ToDate)
    {
        DataTable dt = new DataTable();
        try
        {
            //strQuery = "Select * from ReportIssue R left join tbl_ClinicDetails C on C.ClinicID =R.UserId where R.IsActive =1 ";
            //Change by Nidhi: To get doctor detail instead of clinic
            // check in login table for userid and role. if 
            strQuery = "Select  (FirstName + ' ' + LastName ) As DoctorName,* from ReportIssue R left join tbl_DoctorDetails D on D.DoctorID =R.UserId where R.IsActive =1";
            if (empid > 0)
                strQuery += " and R.UserId =@empid";
            if (IssueType != "--- Select ---")
                strQuery += " and R.IssueType =@IssueType";
            if (Status != "--- Select ---")
                strQuery += " and R.Status =@Status";

            if (FromDate != "" && ToDate != "")
                strQuery += " and convert(date,R.Date,105) between convert(date,@FromDate,105) and convert(date,@ToDate,105)";
            strQuery += " ORDER BY R.Id DESC ";

            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@ToDate", ToDate);

            objGeneral.AddParameterWithValueToSQLCommand("@IssueType", IssueType);
            objGeneral.AddParameterWithValueToSQLCommand("@Status", Status);
            objGeneral.AddParameterWithValueToSQLCommand("@empid", empid);
            dt = objGeneral.GetDatasetByCommand(strQuery);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable GetAllClinicDetaisNew1(int Sid)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from tbl_ClinicDetails  where IsActive =1 ";
            if (Sid > 0)
                strQuery += " and StateID='" + Sid + "'";
            strQuery += " ORDER BY ClinicName ASC";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }



    public DataTable GetAllHelp(string strName)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from VideoMaster  where isActive =1 ";
            if (strName != "")
                strQuery += " and Name='" + strName + "'";
            //  strQuery += " ORDER BY ClinicName ASC";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public DataTable clinicMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 19);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }

    public DataTable MedicalProblemMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 11);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }



    public DataTable AllergicDetails()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 12);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }
    public int GetEmployeeCODE()
    {
        General objGeneral = new General();
        int ID = 0;
        try
        {
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 8);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);

            ID = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ID;

    }

    public DataTable GetRole()
    {
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 9);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");

        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];



    }

    public DataTable GetRoleNEW()
    {

        DataTable dt = new DataTable();
        try
        {
            strQuery = "SELECT * FROM Role WHERE IsActive=1";

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable GetDoctorByClinic(int Did)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from DoctorByClinic DBC join tbl_ClinicDetails C on C.ClinicID = DBC.ClinicID where C.IsActive =1 and IsDeactive=1 and DBC.IsDeactive=1";
            if (Did > 0)
                strQuery += " and   DBC.DoctorID='" + Did + "'";
            strQuery += " ORDER BY ClinicName ASC";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable GetSubAdminClinic(int Did)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from SubAdminClinic DBC join tbl_ClinicDetails C on C.ClinicID = DBC.ClinicID where C.IsActive =1  and DBC.IsActive=1";
            strQuery += " and DBC.Doctorid="+ Did + "";
            strQuery += " ORDER BY ClinicName ASC";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable GetByTelecallerClinic(int EMPID, int RoleId)
    {
        DataTable dt = new DataTable();
        try
        {
            if (RoleId == 9)
            {
                strQuery = "Select *,EP.FirstName+' '+EP.Surname as EMPName from tblEmployeePersonal EP join tbl_ClinicDetails C on C.ClinicId = EP.ClinicID Join Login L on EP.EmployeeID = L.ClinicID   where L.RoleID In(9) and EP.IsActive = 1";
            }
            else
            {
                strQuery = "Select *,EP.FirstName+' '+EP.Surname as EMPName from tblEmployeePersonal EP join tbl_ClinicDetails C on C.ClinicId = EP.ClinicID Join Login L on EP.EmployeeID = L.ClinicID   where L.RoleID In(5) and EP.IsActive = 1";
            }
            if (EMPID > 0)
                strQuery += " and   EP.EmployeeID ='" + EMPID + "'";
            strQuery += " ORDER BY EP.FirstName ASC";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }





    public DataTable GetDataInTritmentByPai(int Pid)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select TP.DoctorID,P.patientid,P.ClinicID from TreatmentbyPatient TP Join PatientMaster P On P.patientid = TP.patientid where P.patientid= '" + Pid + "' ";

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;

    }




    public DataTable GetClinicByDoctor(int Cid)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1 and D.IsDeleted=0";
            if (Cid > 0)
                strQuery += " and   DBC.ClinicID='" + Cid + "'";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable AreaMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 7);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }

    public DataTable Gettooth()
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from ToothNoMaster";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable GettoothDetails(string toothid)
    {
        DataTable dt = new DataTable();
        try
        {
            strQuery = "Select * from ToothNoMaster where toothID in (" + toothid + ")";
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable StateMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }

    public DataTable NewStateMaster(int Countryid)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", Countryid);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }


    public DataTable CityMaster(int StateId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", StateId);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }
    public DataTable DoctersMasterCid(int Did)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();

            strQuery = " Select * from DoctorByClinic where DoctorID=" + Did + "";

            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable DoctersMasterAdmin(int Cid)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();

            strQuery = " Select D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName,* from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1   and D.IsDeleted=0";

            strQuery += "and DBC.ClinicID =@ClinicID";

            strQuery += "  order by D.FirstName ASC";
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public DataTable DoctersMaster(int Cid, int Rolid)
    {
        DataTable dt = new DataTable();
        try
        {

            General objGeneral = new General();


            if (Rolid == 1)
            {
                ////strQuery = "Select * from tbl_DoctorDetails where  IsActive =1 ";
                ////strQuery += " and ClinicID=@ClinicID";

                strQuery = " Select *,D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1   and D.IsDeleted=0 and DBC.IsDeactive=1";
                if (Cid > 0)
                    strQuery += "and DBC.ClinicID =@ClinicID";
                strQuery += "  order by D.FirstName ASC";


            }
            else if (Rolid == 3)
            {

                // strQuery = "Select *,FirstName +' '+ MiddleName as DoctorName from tbl_DoctorDetails where  IsActive =1 ";
                // strQuery += " and ClinicID=@ClinicID";


                strQuery = " Select *,D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1  and D.IsDeleted=0 and DBC.IsDeactive=1";
                if (Cid > 0)
                    strQuery += "and DBC.ClinicID =@ClinicID";
                strQuery += "  order by D.FirstName ASC";


            }
            else
            {

                //strQuery = "Select *,FirstName +' '+ LastName as DoctorName from tbl_DoctorDetails where  IsActive =1  and IsDeleted=0";
                //if (Cid > 0)
                //    strQuery += "and ClinicID =@ClinicID";
                //strQuery += "  order by FirstName ASC";

                strQuery = " Select *,D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where D.IsActive =1  and D.IsDeleted=0 and DBC.IsDeactive=1";
                if (Cid > 0)
                    strQuery += "and DBC.ClinicID =@ClinicID";
                strQuery += "  order by D.FirstName ASC";

            }


            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public DataTable DoctersMasterNew(int Cid, int Rolid)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();


            if (Rolid == 1)
            {
                strQuery = "Select D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName,* from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID  where  IsActive =1  and IsDeleted=0 and DBC.IsDeactive=1 ";

                strQuery += " and DBC.ClinicID=@ClinicID";
                strQuery += "  order by FirstName ASC";
            }
            else if (Rolid == 3)
            {
                //strQuery = "Select * from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID where  IsActive =1  and IsDeleted=0";
                //strQuery += " and D.DoctorID=@ClinicID";
                //strQuery += "  order by FirstName ASC";

                strQuery = "Select  FirstName+' '+ isnull(LastName,' ') as DoctorName,* from  tbl_DoctorDetails  where IsDeleted=0";
                strQuery += " and DoctorID=@ClinicID";
                strQuery += "  order by FirstName ASC";

            }
            else
            {

                strQuery = "Select  FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1  and IsDeleted=0";
                strQuery += "  order by FirstName ASC";
            }


            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public DataTable DoctersMasterNewENQ11(int Cid, int Rolid)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();

            strQuery = "Select D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName,* from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID  where  IsActive =1  and IsDeleted=0  and DBC.IsDeactive =1";

            strQuery += " and DBC.ClinicID=@ClinicID";
            strQuery += "  order by FirstName ASC";


            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }




    public DataTable DoctersMasterNewENQ(int Cid, int Rolid)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();


            strQuery = "Select FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1 and IsDeleted=0";
            if (Cid > 0)
            {
                strQuery += " and ClinicID=@ClinicID";
            }

            strQuery += "  order by FirstName ASC";


            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public DataTable DoctersMaster123(int DoctorID, int Rolid)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();


            strQuery = "Select FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1 and IsDeleted=0";
            if (DoctorID > 0)
            {
                strQuery += " and DoctorID=@DoctorID";
            }

            strQuery += "  order by FirstName ASC";


            objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public DataTable DoctersSelectDoctorID(string DoctorName)
    {
        DataTable dt = new DataTable();
        try
        {
            General objGeneral = new General();


            strQuery = "Select * from tbl_DoctorDetails where  IsActive =1 and IsDeleted=0";
            strQuery += " and FirstName +' ' +LastName like '%" + DoctorName + "%'";

            dt = objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }



    public DataTable EmaployeMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds.Tables[0];

    }

    public int GetEnquiryNo()
    {
        int Id = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            Id = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Id;

    }


    public int GetEnquirySourceId(string Sourcename)
    {
        int Id = 0;
        try
        {
            General objGeneral = new General();


            objGeneral.AddParameterWithValueToSQLCommand("@Sourcename", Sourcename);
            Id = objGeneral.GetExecuteScalarByCommand_SP("GET_EnquirySourceId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Id;

    }


    public int GetPatient_No()
    {
        int Id = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 10);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            Id = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Id;

    }


    //public DataTable GetTotalPaidAmount(int Cid)
    //{


    //    strQuery = "Select Sum (PaidAmount) TotalAmount from InvoiceMaster  where ClinicID='" + Cid + "'";
    //    return objGeneral.GetDatasetByCommand(strQuery);

    //}


    public decimal GetTotalPaidAmount(int Cid)
    {
        decimal TOtal = 0;
        try
        {
            strQuery = " Select IsNull(Sum (PaidAmount),0) TotalAmount from InvoiceMaster  ";
            if (Cid > 0)
                strQuery += " where ClinicID='" + Cid + "' and  month(PayDate) = month(GETDATE())  and   Year(PayDate) = Year(GETDATE())  ";

            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }

    public DataTable GETFinancialYear()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

            ds = objGeneral.GetDatasetByCommand_SP("GET_FinancialYear");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }


    public DataTable GETFinancialYearDATE()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);

            ds = objGeneral.GetDatasetByCommand_SP("GET_FinancialYear");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }
    public decimal GetTotalPaidAmountFYear(int Cid)
    {
        decimal TOtal = 0;
        string DateF = "";
        try
        {
            //int YearDate = System.DateTime.Now.Year;

            DataTable dt = GETFinancialYear();

            DateF = dt.Rows[0]["QM_FIN_YEAR"].ToString();

            string TDate = DateF.Substring(0, 10);

            string FDate = DateF.Substring(11);



            strQuery = " Select IsNull(Sum (PaidAmount),0) TotalAmount from InvoiceMaster  ";

            strQuery += " where   convert(date,PayDate,105) between convert(date,'" + TDate + "',105) and convert(date,'" + FDate + "',105)  ";

            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }



    public decimal GetTotalPaidAmountDocter(int Cid)
    {
        decimal TOtal = 0;
        try
        {
            strQuery = " Select IsNull(Sum (PaidAmount),0) TotalAmount from InvoiceMaster  ";
            if (Cid > 0)
                strQuery += " where DoctorID='" + Cid + "' and  month(PayDate) = month(GETDATE())  and   Year(PayDate) = Year(GETDATE())";


            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }


    public int GetTotalCONVERTEDEnq()
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(*) from PatientMaster  where EnquiryId not in (0)  ";

            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }

    public int GetTotalCLINICS()
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(*) from tbl_ClinicDetails where IsActive =1  ";

            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }


    public int GetTotalDAILYAPPONTMENTS()
    {
        int TOtal = 0;
        try
        {
            strQuery = "  Select count(Appointmentid) As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101) AND Status IN  (0,1)   ";

            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }

    public decimal GetTotalExpense(int Cid)
    {
        decimal TOtal = 0;
        try
        {
            strQuery = "Select  IsNull(Sum (Amount),0)  Amount from ExpenseMaster  where  IsActive =1 ";

            if (Cid > 0)
                strQuery += " and ClinicID='" + Cid + "' and  month(ExpDate) = month(GETDATE())  and   Year(ExpDate) = Year(GETDATE())  ";

            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;

    }

    public decimal GetTotalExpenseAC(int Cid)
    {
        decimal TOtal = 0;
        try
        {
            strQuery = "Select IsNull(Sum (Amount),0) from ExpenseMaster E join tbl_DoctorDetails DD on DD.DoctorID =E.DoctorID Join tbl_ClinicDetails C on C.ClinicID= E.ClinicID where E.IsActive= 1 ";

            if (Cid > 0)
                strQuery += " and ClinicID='" + Cid + "' and  month(ExpDate) = month(GETDATE())  and   month(ExpDate) = month(GETDATE()) ";

            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;

    }



    public decimal GetTotalExpenseFYear(int Cid)
    {
        decimal TOtal = 0;
        string DateF = "";
        try
        {


            DataTable dt = GETFinancialYear();

            DateF = dt.Rows[0]["QM_FIN_YEAR"].ToString();

            string TDate = DateF.Substring(0, 10);

            string FDate = DateF.Substring(11);


            strQuery = "Select  IsNull(Sum (Amount),0)  Amount from ExpenseMaster  where  IsActive =1 ";
            strQuery += " and  convert(date,ExpDate,105) between convert(date,'" + TDate + "',105) and convert(date,'" + FDate + "',105)  ";


            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;

    }


    public decimal GetTotalExpenseDocter(int Cid)
    {
        decimal TOtal = 0;
        try
        {
            strQuery = "Select  IsNull(Sum (Amount),0)  Amount from ExpenseMaster  where  IsActive =1  and  month(ExpDate) = month(GETDATE())  and   Year(ExpDate) = Year(GETDATE()) ";


            if (Cid > 0)
                strQuery += " and DoctorID='" + Cid + "'";


            TOtal = Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }

    public int GetDoctorMax_No()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 13);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }


    public int GetPatientTreatmentMax_no()
    {

        int TOtal = 0;
        try
        {
            General objGeneral = new General();

            strQuery = "select IsNull(MAX(PTID)+1,1) from PatientTreatmentImage where IsActive=1";

            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return TOtal;
    }


    public int GetPENDINGFOLLOWUPSTelecaller(int Cid)
    {
        //  strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "' and Statusid not in (3) ";  
        int TOtal = 0;
        try
        {
            strQuery = " SELECT Count(*) FROM Enquiry WHERE NOT EXISTS  (SELECT * FROM Followup  WHERE Followup.EnquiryID = Enquiry.EnquiryID) and Enquiry.TelecallerToEmpId = '" + Cid + "' and Enquiry.IsActive =1 and Enquiry.IsPatient=0";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }


    public int GetPENDINGFOLLOWUPS(int Cid)
    {
        //  strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "' and Statusid not in (3) ";  
        int TOtal = 0;
        try
        {
            strQuery = " SELECT Count(*) FROM Enquiry WHERE NOT EXISTS  (SELECT * FROM Followup  WHERE Followup.EnquiryID = Enquiry.EnquiryID) and Enquiry.AssignToEmpId = '" + Cid + "' and Enquiry.IsActive =1 and Enquiry.IsPatient=0";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }

    public int GetFOLLOWUPS(int Cid)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "' ";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }

    public int GetASSIGNENQUIRIES1(int Cid)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(AssignToEmpId) from Enquiry where TelecallerToEmpId='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }


    public int GetSubAdminLink(int Did)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(*) Did From [SubAdminClinic]  where DoctorId='" + Did + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }




    public int GetTelecallerEmp(int TelecallerToEmpId)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(TelecallerToEmpId) from Enquiry where TelecallerToEmpId='" + TelecallerToEmpId + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }


    public int GetDoctorMax_NoNew(int Cid)
    {
        // strQuery = "select Count(DoctorID) from tbl_DoctorDetails  where IsDeleted=0 and ClinicID='" + Cid + "'";

        //   strQuery = " select Count(D.DoctorID) from tbl_DoctorDetails D left Join Login L on D.DoctorID = L.ClinicID  where IsDeleted=0 and L.RoleID  In (3) and D.ClinicID='" + Cid + "'";
        int TOtal = 0;
        try
        {
            strQuery = " select Count(DC.DoctorID)from tbl_DoctorDetails D  left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID  where IsDeleted = 0  and  DC.IsDeactive=1 and DC.ClinicID ='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }

    public int GetAppoinmentMax_No()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 14);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }

    public int GetEnquiryCountNo()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 15);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }


    public int GetEnquiryCountNoNew(int Cid)
    {
        int TOtal = 0;
        try
        {
            // strQuery = "select COUNT(EnquiryID) from Enquiry where IsActive=1 and ClinicID='" + Cid + "'";

            strQuery = "Select COUNT(E.EnquiryID) from Enquiry E left Join  EnquirySourceMaster ES on ES.Sourceid =E.Sourceid left Join  tbl_ClinicDetails CD on CD.ClinicID =E.ClinicID  where E.IsActive =1 and E.IsPatient=0 ";

            if (Cid > 0)
                strQuery += " and E.ClinicID ='" + Cid + "'";


            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }

    public int GetASSIGNENQUIRIES(int Cid)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }


    public int GetEmployyeCount()
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(*) from tblEmployeePersonal where IsActive =1";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }



    public int GetExpenseNo()
    {
        int TOtal = 0;
        try
        {
            strQuery = " select IsNull(MAX(ExpenseID)+1,1) from ExpenseMaster where IsActive='1'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }



    public int GetDoctorCountMASTER()
    {
        int TOtal = 0;
        try
        {
            strQuery = " Select Count(D.DoctorID) from tbl_DoctorDetails D left Join Login L on D.DoctorID = L.ClinicID   where L.RoleID  In (3) and D.IsDeleted=0 ";

            //  strQuery = "Select Count(D.DoctorID) from tbl_DoctorDetails D where D.IsDeleted=0 ";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }



    public int GetTreatmentMASTER()
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select Count(TM.patientid) from TreatmentbyPatient TM join PatientMaster PM on PM.patientid= TM.patientid  where TM.IsActive =1";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }

    public int GetFollowupCountNoNew(int UserId, int RoleID)
    {
        int TOtal = 0;
        try
        {
            strQuery = "select COUNT(Followupid) from Followup where IsActive=1 ";

            if (RoleID == 1)
            {
                strQuery += " and ClinicID='" + UserId + "'";
            }
            if (RoleID == 3)
            {
                strQuery += " and employeeid='" + UserId + "'";

            }
            strQuery += " and NextFollowupdate =GETDATE()";

            // strQuery = "select COUNT(EnquiryID) from Enquiry where IsActive=1 and IsPatient=0  and ClinicID='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }




    public int GetFollowupCountNoTelecaller(int UserId, int RoleID)
    {
        int TOtal = 0;
        try
        {
            strQuery = "select COUNT(Followupid) from Followup where IsActive=1 ";

            if (RoleID == 1)
            {
                strQuery += " and ClinicID='" + UserId + "'";
            }
            if (RoleID == 3)
            {
                strQuery += " and employeeid='" + UserId + "'";

            }
            strQuery += " and NextFollowupdate =GETDATE()";

            // strQuery = "select COUNT(EnquiryID) from Enquiry where IsActive=1 and IsPatient=0  and ClinicID='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }



    public int GetFollowupCountNo()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 16);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }


    public int GetTotalNoofAppoinmentNo(long Cid)
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 18);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }

    public int GetPatientCount_No()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 17);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }

    public int GetPatientCount_NoNew(int Cid)
    {
        int TOtal = 0;
        try
        {
            strQuery = "select count(patientid) from PatientMaster where IsActive=1 and ClinicID='" + Cid + "'";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }



    public int GetPatientCountDocterCount(int Cid)
    {
        int TOtal = 0;
        try
        {
            strQuery = "Select count(patientid) from AppointmentMaster where IsActive =1 and DoctorID ='" + Cid + "' ";
            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }



    public DataTable GetTypeofWorkLab()
    {
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 21);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return ds.Tables[0];

    }


    public int GetFollowupNo()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            TOtal = objGeneral.GetExecuteScalarByCommand_SP("GET_Common");

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;
    }

    public int GetpatientNo()
    {
        int TOtal = 0;
        try
        {
            General objGeneral = new General();

            strQuery = "Select MAX(patientid) from PatientMaster where IsActive=1";

            TOtal = Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return TOtal;

    }




    public DataTable ComplaintsDetils(int Pid)
    {
        try
        {
            if (Pid > 0)
            {
                General objGeneral = new General();
                return objGeneral.GetDatasetByCommand("Select * from PatientbyDentalinfo PyD  WHERE PyD.patientid = '" + Pid + "'");
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



    public DataTable RetriveCityMaster(int StateID)
    {
        try
        {
            if (StateID > 0)
            {
                General objGeneral = new General();
                return objGeneral.GetDatasetByCommand("SELECT ID,CityName, CityID FROM City WHERE StateID = '" + StateID + "'");
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetAllEmploymentType()
    {
        try
        {
            string strQuery = string.Empty;
            General objGeneral = new General();
            strQuery = "SELECT * FROM EmploymentTypes WHERE isActive=1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public DataTable RetriveSourceMaster()
    {
        try
        {
            General objGeneral = new General();
            return objGeneral.GetDatasetByCommand("SELECT SourceID,SourceType FROM tblSourceTypes where ISNULL(IsActive,0)=1");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetAllHobbies()
    {
        try
        {
            string strQuery = string.Empty;
            General objGeneral = new General();
            strQuery = "SELECT * FROM HobbiesMaster WHERE IsActive=1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public int GetCustomerNo()
    {
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 7);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception e)
        {

            throw e;
        }

    }
    public int GetinvoiceNo()
    {
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 20);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception e)
        {

            throw e;
        }

    }


    public DataTable GetAllDoctorDetails(int ClinicID)
    {
        try
        {
            strQuery = "Select * from tbl_DoctorDetails D Join tbl_ClinicDetails C on C.ClinicID=D.ClinicID where D.DoctorID='" + ClinicID + "'";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public DataTable GetAlltblClinicDetails(int ClinicID)
    {
        try
        {
            strQuery = "Select * from tbl_ClinicDetails where ClinicID='" + ClinicID + "'";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }


    public DataTable GetYear()
    {
        try
        {
            strQuery = "Select * from YearMaster";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }


    public DataTable GetState()
    {
        try
        {
            strQuery = "select s.StateID, s.StateName from tbl_ClinicDetails c left join state s on c.StateID = s.StateID Group by s.StateID, s.StateName ";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];
    }

    public DataTable GetMonths()
    {
        try
        {
            strQuery = "Select * from MonthsMaster";
            return objGeneral.GetDatasetByCommand(strQuery);
        }

        catch (Exception e)
        {

            throw e;
        }

    }



    public DataTable AllDoctorType()
    {
        try
        {

            General objGeneral = new General();

            ds = objGeneral.GetDatasetByCommand_SP("sp_GetAllDoctorType");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }
    public DataTable DoctorSpeciality()
    {
        try
        {

            General objGeneral = new General();

            ds = objGeneral.GetDatasetByCommand_SP("sp_GetDoctorSpeciality");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }
    public DataTable DoctorDegree()
    {
        try
        {

            General objGeneral = new General();

            ds = objGeneral.GetDatasetByCommand_SP("sp_GetDoctorDegree");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

    }



    public DataTable GetApp_Version()
    {
        try
        {

            strQuery = "SELECT * FROM App_VersionMaster";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }


    public DataTable IssuetypeMasterInfo()
    {
        try
        {

            strQuery = "SELECT * FROM IssuetypeMaster where IsActive=1";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public DataTable statusMasterInfo()
    {
        try
        {

            strQuery = "SELECT * FROM Enquirystatus where IsActive=1 and StatusId in (1,3,5,6,7)";
            return objGeneral.GetDatasetByCommand(strQuery);
        }
        catch (Exception e)
        {

            throw e;
        }
    }


    public int App_VersionUpdate(string App_Version, string App_VCode, bool ForceUpdate)
    {
        try
        {

            strQuery = "update App_VersionMaster set App_Version='" + App_Version + "',App_VCode='" + App_VCode + "',ForceUpdate='" + ForceUpdate + "'";
            objGeneral.GetExecuteNonQueryByCommand(strQuery);
            return 1;
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public int UserLoginhistory(int Empid, int RoleID)
    {
        try
        {
            strQuery = "insert into UserLoginHistory (EmployeeId,RoleId,LoginDateTime)Values (" + Empid + "," + RoleID + ",GETDATE())";
            objGeneral.GetExecuteNonQueryByCommand(strQuery);
            return 1;
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public int UserLoginhistoryNew(int Empid, int RoleID, int Vid)
    {
        try
        {

            strQuery = "insert into UserLoginHistory (EmployeeId,RoleId,LoginDateTime,Vid)Values (" + Empid + "," + RoleID + ",GETDATE()," + Vid + ")";
            objGeneral.GetExecuteNonQueryByCommand(strQuery);
            return 1;
        }
        catch (Exception e)
        {
            throw e;
        }
    }



    public DataTable clinicVSAppointments(string FromDate, string Todate, int ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);

            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);
            if (RoleId == 3)
            {

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                ds = objGeneral.GetDatasetByCommand_SP("Get_ReportSubAdminDetilsOfClinic");
            }
            else
            {
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");

            }

        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }

    public DataTable clinicVSConsultation(string FromDate, string Todate, string ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);
            //if (RoleId == 3)
            //{
            //    objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            //    ds = objGeneral.GetDatasetByCommand_SP("Get_ReportSubAdminDetilsOfClinic");
            //}
            //else
            //{
            //    objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            //    //  ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");

            //}
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllConsultationDetilsOfClinic");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }

    public DataTable clinicVSEnquiry(string FromDate, string Todate, int ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

            ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }


    public DataTable clinicVSFollowup(string FromDate, string Todate, int ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

            ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }


    public int GetPaymentinvoiceNo()
    {
        try
        {
            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 25);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
            return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");
        }
        catch (Exception e)
        {

            throw e;
        }

    }


    public DataTable clinicVSExpenseMaster(string FromDate, string Todate, int ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

            ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }

    public DataTable clinicVSInvoiceMaster(string FromDate, string Todate, int ClinicID, string DoctorsID, int RoleId)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
            objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
            objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

            ds = objGeneral.GetDatasetByCommand_SP("Get_ReportAllDetilsOfClinic");
        }
        catch (Exception ex)
        {

        }
        return ds.Tables[0];

    }
}



[Serializable]
public class invoiceDetils
{
    public int ID { get; set; }
    public int TreatmentID { get; set; }
    public int RowNumber { get; set; }
    public string Unit { get; set; } 
    public string Cost { get; set; }
    public string Discount { get; set; }
    public int ISInvoice { get; set; }
    public string Tex { get; set; }
}

[Serializable]
public class LabDetails1
{
    public long Labid;

    public long patientid;
    public long TypeOfworkId;
    public string LabName;
    public string WorkStatus;
    public string OutwardDate;
    public string ToothNo;
    public string InwardDate;
    public string Workcompletion;
    public string Notes;
    public long CreateID;
    public string billuplod;


}

[Serializable]
public class ClinicDetails
{
    public long clinicID;

    public string ClinicName;
    public string LastName;
    public string FirstName;
    public string AddressLine1;
    public string AddressLine2;
    public long LocationID;
    public long CountryID;
    public long StateID;
    public long CityID;
    public string PhoneNo1;
    public string PhoneNo2;
    public string Emailid;
    public string Noofweek;
    public string openTime;
    public string CloseTime;
    public bool IsActive;
    public bool IsApprove;
    public int Modifiedby;
    public string ModifiedDate;
    public string UserName;
    public string UserPassword;
    public string LocationName;

}
[Serializable]
public class DoctorDetails
{
    public long DoctorID;
    public long DoctorTypeID;
    public string RegDate;
    public string FirstName;
    public string LastName;
    public string Gender;
    public string BirthDate;
    public long CountryID;
    public long StateID;
    public long CityID;
    public string PhoneNo1;
    public string PhoneNo2;
    public string Email;
    public string BloodGroup;
    public string AreaPin;
    public string AddressLine1;
    public string AddressLine2;
    public bool IsActive;
    public int Modifiedby;
    public string ModifiedDate;
    public string UserName;
    public string UserPassword;

    public string PanCardNo;
    public string PanCardImageUrl;
    public string AdharCardNo;
    public string AdharCardImageUrl;
    public string ProfileImageUrl;
    public string degrees;
    public string specialities;
    public long ClinicID;
    public string Intime;
    public string Outtime;

    public string RegistrationNo;
    public string RegistrationImageUrl;
    public string IdentityPolicyNo;
    public string IdentityPolicyImageUrl;
    public string DegreeUpload1;
    public string DegreeUpload2;
}
[Serializable]
public class Unit_Master
{
    public long Unitid;
    public long Categoryid;
    public string Unitname;
    public int CreatedBy;
    public DateTime CreatedDate;
    public int ModifiedBy;
    public DateTime ModifiedDate;
    public bool IsActive;
}

[Serializable]
public class Accessory_Master
{
    public long Accessoryid;
    public long Accessorytypeid;
    public string Accessoryname;
    public int CreatedBy;
    public DateTime CreatedDate;
    public int ModifiedBy;
    public DateTime ModifiedDate;
    public bool IsActive;
}

[Serializable]
public class Glass_Master
{
    public long Glassid;
    public string GlassType;
    public string GlassName;
    public string Remarks;
    public int CreatedBy;
    public DateTime CreatedDate;
    public int ModifiedBy;
    public DateTime ModifiedDate;
    public bool IsActive;
}


[Serializable]
public class Color_Master
{
    public long Colorid;
    public string ColorName;
    public string ReferenceId;
    public string RefType;
    public int CreatedBy;
    public DateTime CreatedDate;
    public int ModifiedBy;
    public DateTime ModifiedDate;
    public bool IsActive;
}


[Serializable]
public class Enquiry_Details
{
    public long EnquiryID;
    public long CatId;
    public long Sourceid;
    public long PurposeId;
    public long ClinicID;
    public long TreatmentID;
    public long RoleId;
    public long TelecallerToEmpId;
    public string Enquiryno;
    public string EnquiryDate;
    public string FirstName;
    public string LastName;
    public string DateBirth;
    public string Age;
    public string Gender;
    public string Address;
    public long CountryId;
    public long stateid;
    public long Cityid;
    public string Area;
    public string Email;
    public string Mobile;
    public string Telephone;
    public long ReceivedByEmpId;
    public long AssignToEmpId;
    public string Status;
    public string Folllowupdate;
    public string InterestLevel;
    public string InterestLevelCode;
    public int CreatedBy;
    public string CreatedDate;
    public int ModifiedBy;
    public string ModifiedDate;
    public bool IsActive;
    public string Conversation;
    public string Pstatus;

}



[Serializable]
public class Patient_Details
{
    public long patientid;
    public long EnquiryId;
    public long ClinicID;


    public string PatientCode;
    public string RegistrationDate;
    public string FirstName;
    public string LastName;
    public string DateBirth;
    public string Age;
    public string boolgroup;
    public string Gender;
    public string Address;
    public long CountryId;

    public long stateid;
    public long Cityid;
    public string Area;
    public string Email;
    public string Mobile;
    public string Telephone;

    public int CreatedBy;
    public string CreatedDate;
    public int ModifiedBy;
    public string ModifiedDate;
    public bool IsActive;
    public string ProfileImage;

    public string MedicalProblem;
    public string Allergic;
    public string Nooftooth;
    public string Pregnant;
    public string DueDate;
    public string PanMasalaChewing;
    public string Tobacco;
    public string Somking;
    public string cigrattesInDay;
    public string ListofMedicine;

    public string FamilyDoctorName;
    public string DrAddress;


    public string PaymentMode;
    public string Amount;
    public string PayDate;
    public string Complaint;
    public string DentalTreatment;
    public string ConsentStatement;

    public string UserName;
    public string Password;
    public string ConsentParth;


}


[Serializable]
public class Appointment_Details
{
    public long Appointmentid;
    public long DoctorID;
    public long patientid;
    public long EnquiryID;

    public long ClinicID;


    public string AppointmenNo;

    public string FirstName;
    public string LastName;
    public string DateBirth;
    public string Age;

    public string Gender;


    public string Email;
    public string Mobile1;
    public string Mobile2;

    public long CreatedBy;
    public string CreatedDate;
    public long ModifiedBy;
    public string ModifiedDate;
    public bool IsActive;


    public string start_date;
    public string end_date;
    public string start_time;
    public string end_time;





}








[Serializable]
public class Followup_Details
{
    public long Followupid;
    public long EnquiryID;
    public long ClinicID;
    public string FollowupCode;
    public int employeeid;
    public string enquiryno;
    public string Followupdate;
    public int Followupmodeid;
    public string FollowupmodeNew;
    public string ConversationDetails;
    public string NextFollowupdate;
    public string InterestLevel;
    public int Statusid;
    public string Remak;
    public int CreatedBy;
    public int ModifiedBy;
    public string Fname;
    public string LName;
}

[Serializable]
public class Employee_Details
{
    public string EmployeeCode;
    public long EmployeeID;
    public long ClinicID;
    public string RegistrationDate;
    public string FirstName;
    public string MiddleName;
    public string Surname;
    public string Gender;
    public string Religion;
    public string Emp_Cast;
    public string BloodGroup;
    public string BirthDate;
    public string Nationality;
    public int CreatedBy;
    public int ModifiedBy;
    public string EmployeePhoto;
    public long Role;
    public string UserName;
    public string Password;

    //EMPContactInfo

    public string CurrentAddress;
    public string CurrentLandmark;
    public int CurrentCountry;
    public int CurrentState;
    public int CurrentCity;
    public string CurrentPinCode;

    public string PermanentAddress;
    public string PermanentLandmark;
    public int PermanentCountry;
    public int PermanentState;
    public int PermanentCity;
    public string PermanentPinCode;
    public string ResidentPhone;
    public string Mobile;
    public string Email;

    //Bank and Other
    public string BankName;
    public string BranchName;
    public string IFSC_Code;
    public string AccountNumber;
    public int ContactPersonCountry;
    public string AccountHolderName;
    public string AadhaarNo;
    public string PassportNo;
    public string DrivinglicenceNo;
    public string Documentimg;


}

[Serializable]
public class Customer_Details
{
    public string CustomerCode;

    public long EnquiryId;

    public long CustomerID;
    public long Cust_TypeID;
    public DateTime RegistrationDate;
    public string FristName;
    public string LastName;
    public string Gender;
    public string Nationality;
    public string AadhaarcardNo;
    public int CreatedBy;
    public int ModifiedBy;
    public string CustomerPhoto;
    //CustomerContactInfo

    public string CustomerAddress;
    public string CustomerLandmark;
    public int CustomerCountry;
    public int CustomerState;
    public int CustomerCity;
    public string CustomerPinCode;
    public string CustomerResidentPhone;
    public string CustomerMobile;
    public string CustomerEmail;

    //OtherCustomerContactInfo
    public string OtherType;
    public string OtherContactPersonAddress;
    public string OtherContactPersonLandmark;
    public int OtherContactPersonCountry;
    public int OtherContactPersonState;
    public int OtherContactPersonCity;
    public string OtherContactPersonPinCode;
    public string OtherContactPersonResidentPhone;
    public string OtherContactPersonMobile;
    public string OtherContactPersonEmail;

    //ContactPersonInfo
    public string CPFristName;
    public string CPLastName;
    public string ContactPersonAddress;
    public string ContactPersonLandmark;
    public int ContactPersonCountry;
    public int ContactPersonState;
    public int ContactPersonCity;
    public string ContactPersonPinCode;
    public string ContactPersonResidentPhone;
    public string ContactPersonMobile;
    public string ContactPersonEmail;
    public string CPAadhaarcardNo;
}



[Serializable]
public class LoginEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }


}

[Serializable]
public class FailedQuestionList
{
    public int srno { get; set; }
    public bool IsSourceIDMismatch { get; set; }
    public bool IsTreatmentIDMismatch { get; set; }
    public bool IsClinicIDMismatch { get; set; }
    public bool IsDoctorIDMismatch { get; set; }

}


[Serializable]
public class EnqyiryExcel
{
    public int srno { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile  { get; set; }
 
}




[Serializable]
public class MedicinesDetails
{
    public int ID { get; set; }
    public int RowNumber { get; set; }
    public string MedicinesName { get; set; }
    public string MedicinesType { get; set; }
    public string Dose { get; set; }
    public string NoOfDays { get; set; }
    public string Morning { get; set; }
    public string Afternoon { get; set; }
    public string Evening { get; set; }
    public string Remarks { get; set; }

    public string InHouse { get; set; }
}