using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_EmployeeMaster
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();

        public int Add_EmployeeDetails(Employee_Details bojEmpDetails)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@EmployeeID", bojEmpDetails.EmployeeID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojEmpDetails.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@EmployeeCode", bojEmpDetails.EmployeeCode);
                objGeneral.AddParameterWithValueToSQLCommand("@RegistrationDate",objGeneral .getDatetime (bojEmpDetails.RegistrationDate));
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojEmpDetails.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@MiddleName", bojEmpDetails.MiddleName);
                objGeneral.AddParameterWithValueToSQLCommand("@Surname", bojEmpDetails.Surname);
                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojEmpDetails.Gender);
                objGeneral.AddParameterWithValueToSQLCommand("@Nationality", bojEmpDetails.Nationality);
                objGeneral.AddParameterWithValueToSQLCommand("@Religion", bojEmpDetails.Religion);
                objGeneral.AddParameterWithValueToSQLCommand("@Emp_Cast", bojEmpDetails.Emp_Cast);
                objGeneral.AddParameterWithValueToSQLCommand("@BloodGroup", bojEmpDetails.BloodGroup);
                objGeneral.AddParameterWithValueToSQLCommand("@BirthDate", objGeneral.getDatetime(bojEmpDetails.BirthDate));
                objGeneral.AddParameterWithValueToSQLCommand("@EmployeePhoto ", bojEmpDetails.EmployeePhoto);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojEmpDetails.CreatedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", bojEmpDetails.ModifiedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentAddress", bojEmpDetails.CurrentAddress);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentLandmark", bojEmpDetails.CurrentLandmark);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentCountry", bojEmpDetails.CurrentCountry);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentState", bojEmpDetails.CurrentState);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentCity", bojEmpDetails.CurrentCity);
                objGeneral.AddParameterWithValueToSQLCommand("@CurrentPinCode", bojEmpDetails.CurrentPinCode);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentAddress", bojEmpDetails.PermanentAddress);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentLandmark", bojEmpDetails.PermanentLandmark);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentCountry", bojEmpDetails.PermanentCountry);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentState ", bojEmpDetails.PermanentState);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentCity", bojEmpDetails.PermanentCity);
                objGeneral.AddParameterWithValueToSQLCommand("@PermanentPinCode", bojEmpDetails.PermanentPinCode);
                objGeneral.AddParameterWithValueToSQLCommand("@ResidentPhone", bojEmpDetails.ResidentPhone);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", bojEmpDetails.Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", bojEmpDetails.Email);
                objGeneral.AddParameterWithValueToSQLCommand("@BankName", bojEmpDetails.BankName);
                objGeneral.AddParameterWithValueToSQLCommand("@BranchName", bojEmpDetails.BranchName);
                objGeneral.AddParameterWithValueToSQLCommand("@IFSC_Code", bojEmpDetails.IFSC_Code);
                objGeneral.AddParameterWithValueToSQLCommand("@AccountNumber", bojEmpDetails.AccountNumber);
                objGeneral.AddParameterWithValueToSQLCommand("@AccountHolderName", bojEmpDetails.AccountHolderName);
                objGeneral.AddParameterWithValueToSQLCommand("@AadhaarNo", bojEmpDetails.AadhaarNo);
                objGeneral.AddParameterWithValueToSQLCommand("@DrivinglicenceNo", bojEmpDetails.DrivinglicenceNo);
                objGeneral.AddParameterWithValueToSQLCommand("@PassportNo", bojEmpDetails.PassportNo);
                objGeneral.AddParameterWithValueToSQLCommand("@Documentimg", bojEmpDetails.Documentimg);
                objGeneral.AddParameterWithValueToSQLCommand("@Role", bojEmpDetails.Role);
                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojEmpDetails.UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojEmpDetails.Password);


                if (bojEmpDetails.EmployeeID > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);

                    isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddEmployee");
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                    isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_AddEmployee");
                }
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public DataTable GetAllEmployee(string strname,string Mno,string Eno)
        {
               

              string strQ=" Select * from tblEmployeePersonal EP join tblEmployeeContactDetails EC on EC.EmployeeID =EP.EmployeeID ";
              strQ += " Join Login L on EP.EmployeeID = L.ClinicID   where L.RoleID Not In (1,2,3) and  EP.IsActive=1";

              if (strname != "")
                  strQ += "and  FirstName like '%" + strname + "%'";
              if(Mno != "")
                    strQ += "and  Mobile = '" + Mno + "'";
              if (Eno != "")
                  strQ += "and EmployeeCode = '" + Eno + "'";
             

              return objGeneral.GetDatasetByCommand(strQ);
           
        
        }

        public int DeleteEmployee(int EID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@EmployeeID", EID);
                ds = objGeneral.GetDatasetByCommand_SP("Get_Employeeinfo");
                _isDeleted = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public DataTable GetSelectAllEmployee(int EID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                objGeneral.AddParameterWithValueToSQLCommand("@EmployeeID", EID);
                ds = objGeneral.GetDatasetByCommand_SP("Get_Employeeinfo");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }
    }
}