using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;


public class clsCommonMasters
{

   
    DataSet ds = new DataSet();
    General objGeneral = new General();
    //DataSet ds = new DataSet();
    private string strQuery = string.Empty;
    public DataTable CountryMaster()
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode",6);
            objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
            objGeneral.AddParameterWithValueToSQLCommand("@Countryid",0);
            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);

            ds = objGeneral.GetDatasetByCommand_SP("GET_Common");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

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
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 8);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }

    public DataTable GetRole()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 9);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        ds= objGeneral.GetDatasetByCommand_SP("GET_Common");
        return ds.Tables[0];

    }

    public DataTable GetRoleNEW()
    {
        strQuery = "SELECT * FROM Role WHERE IsActive=1";
       
        return objGeneral.GetDatasetByCommand(strQuery);

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
        strQuery = "Select * from ToothNoMaster";
        return objGeneral.GetDatasetByCommand(strQuery);

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


    public DataTable DoctersMaster(int Cid)
    {
        try
        {

            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
            objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);

            objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
            ds = objGeneral.GetDatasetByCommand_SP("Get_Doctorinfo");
        }
        catch (Exception ex)
        {
        }
        return ds.Tables[0];

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
        }
        return ds.Tables[0];

    }

    public int GetEnquiryNo()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID",0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }

    public int GetPatient_No()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 10);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }


    //public DataTable GetTotalPaidAmount(int Cid)
    //{
        

    //    strQuery = "Select Sum (PaidAmount) TotalAmount from InvoiceMaster  where ClinicID='" + Cid + "'";
    //    return objGeneral.GetDatasetByCommand(strQuery);

    //}


    public decimal GetTotalPaidAmount(int Cid)
    {
        strQuery = " Select IsNull(Sum (PaidAmount),0) TotalAmount from InvoiceMaster  ";
        if (Cid > 0)
            strQuery += " where ClinicID='" + Cid + "'";
            

        return Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
    }

    public decimal GetTotalPaidAmountDocter(int Cid)
    {
        strQuery = " Select IsNull(Sum (PaidAmount),0) TotalAmount from InvoiceMaster  ";
        if (Cid > 0)
            strQuery += " where DoctorID='" + Cid + "'";


        return Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));
    }


    public int GetTotalCONVERTEDEnq()
    {
        strQuery = "Select Count(*) from PatientMaster  where EnquiryId not in (0)  ";
        
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
    }

    public int GetTotalCLINICS()
    {
        strQuery = "Select Count(*) from tbl_ClinicDetails where IsActive =1  ";

        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
    }


    public int GetTotalDAILYAPPONTMENTS()
    {
        strQuery = "  Select count(Appointmentid) As DLastName from AppointmentMaster AM join  tbl_DoctorDetails D on D.DoctorID = AM.DoctorID where convert(date,AM.start_date,101)  =CONVERT(date,GETDATE(),101) AND Status IN  (0,1)   ";

        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
    }

    public decimal GetTotalExpense(int Cid)
    {
        strQuery = "Select  IsNull(Sum (Amount),0)  Amount from ExpenseMaster  where  IsActive =1 ";

        
        if (Cid > 0)
            strQuery += " and ClinicID='" + Cid + "'";
        
        
        return Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));


    }



    public decimal GetTotalExpenseDocter(int Cid)
    {
        strQuery = "Select  IsNull(Sum (Amount),0)  Amount from ExpenseMaster  where  IsActive =1 ";


        if (Cid > 0)
            strQuery += " and DoctorID='" + Cid + "'";


        return Convert.ToDecimal(objGeneral.GetExecuteScalarByCommand(strQuery));


    }

    public int GetDoctorMax_No()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 13);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }


    public int GetPatientTreatmentMax_no()
    {
        General objGeneral = new General();

        strQuery = "select IsNull(MAX(PTID)+1,1) from PatientTreatmentImage where IsActive=1";

        return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(strQuery));


    }




    public int GetPENDINGFOLLOWUPS(int Cid)
    {
        strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "' and Statusid not in (3) ";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

    }


    public int GetASSIGNENQUIRIES1(int Cid)
    {
        strQuery = "Select Count(AssignToEmpId) from Enquiry where AssignToEmpId='" + Cid + "'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

    }



    public int GetDoctorMax_NoNew(int Cid)
    {
        strQuery = "select Count(DoctorID) from tbl_DoctorDetails where IsDeleted=0 and ClinicID='" + Cid + "'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

    }

    public int GetAppoinmentMax_No()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 14);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }

    public int GetEnquiryCountNo()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 15);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }


    public int GetEnquiryCountNoNew(int Cid)
    {
        strQuery = "select COUNT(EnquiryID) from Enquiry where IsActive=1 and ClinicID='"+Cid+"'";
        return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(strQuery));


    }

    public int GetASSIGNENQUIRIES(int Cid)
    {
        strQuery = "Select Count(employeeid) from Followup where employeeid='" + Cid + "'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


    }


    public int GetEmployyeCount()
    {
        strQuery = "Select Count(*) from tblEmployeePersonal where IsActive =1";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


    }
   
    

    public int GetExpenseNo()
    {
        strQuery = " select IsNull(MAX(ExpenseID)+1,1) from ExpenseMaster where IsActive='1'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


    }

    public int GetTreatmentMASTER()
    {
        strQuery = "Select Count(*) from TreatmentMASTER where IsActive =1";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


    }

    public int GetFollowupCountNoNew(int Cid)
    {
        strQuery = "select COUNT(Followupid) from Followup where IsActive=1 and ClinicID='" + Cid + "'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));


    }

    public int GetFollowupCountNo()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 16);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }


    public int GetTotalNoofAppoinmentNo(long Cid)
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 18);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }

    public int GetPatientCount_No()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 17);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }

    public int GetPatientCount_NoNew(int Cid)
    {
        strQuery = "select count(patientid) from PatientMaster where IsActive=1 and ClinicID='" + Cid + "'";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

    }



    public int GetPatientCountDocterCount(int Cid)
    {
        strQuery = "Select count(patientid) from AppointmentMaster where IsActive =1 and DoctorID ='" + Cid + "' ";
        return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

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
        }
        return ds.Tables[0];

    }


    public int GetFollowupNo()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }



    public int GetpatientNo()
    {
        General objGeneral = new General();

        strQuery = "Select MAX(patientid) from PatientMaster where IsActive=1";

        return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(strQuery));


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
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 7);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }
    public int GetinvoiceNo()
    {
        General objGeneral = new General();
        objGeneral.AddParameterWithValueToSQLCommand("@mode", 20);
        objGeneral.AddParameterWithValueToSQLCommand("@stateID", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@Countryid", 0);
        objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
        return objGeneral.GetExecuteScalarByCommand_SP("GET_Common");


    }


    public DataTable GetAllDoctorDetails(int ClinicID)
    {
        strQuery = "Select * from tbl_DoctorDetails D Join tbl_ClinicDetails C on C.ClinicID=D.ClinicID where D.DoctorID='" + ClinicID + "'";
        return objGeneral.GetDatasetByCommand(strQuery);

    }

    public DataTable GetAlltblClinicDetails(int ClinicID)
    {
        strQuery = "Select * from tbl_ClinicDetails where ClinicID='" + ClinicID + "'";
        return objGeneral.GetDatasetByCommand(strQuery);

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

    public string Tex { get; set; }
}

[Serializable]
public class LabDetails
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
    public string  openTime;
    public string CloseTime;
    public bool IsActive;
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

    
    public string  Enquiryno;
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


  
}


[Serializable]
public class Appointment_Details
{
    public long Appointmentid;
    public long DoctorID;
    public long patientid;
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
    public string ConversationDetails;
    public string NextFollowupdate;
    public string InterestLevel;
    public int Statusid;
    public string Remak;
    public int CreatedBy;
    public int ModifiedBy;

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