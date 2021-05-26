using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OrthoSquare.Entities;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_Login
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;

        public DataTable getLoginDetails(LoginEntity _loginEntity)
        {
           
            DataSet ds = new DataSet();
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@User_Name", _loginEntity.UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", _loginEntity.Password);
              
                ds = objGeneral.GetDatasetByCommand_SP("sp_login");
            }
            catch (Exception ex)
            {
            }

            return ds.Tables[0];
        }


        public bool UpdatePassword(int userid, string oldpassword, string newpassword)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Update Login set Password=@newpassword where UserID=@userid AND Password=@oldpassword";
                objGeneral.AddParameterWithValueToSQLCommand("@userid", userid);
                objGeneral.AddParameterWithValueToSQLCommand("@oldpassword", oldpassword);
                objGeneral.AddParameterWithValueToSQLCommand("@newpassword", newpassword);
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable CheckUserExists(int userid, string Password)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Select * from Login where UserID='" + userid + "' and Password='" + Password + "'";
                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable CheckSoftwareExpiredMaster()
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Select * from SoftwareExpiredMaster where IsActive =1";
                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //public DataTable getLoginPatientAPI(VerifyLogin _LoginEntity)
        //{

        //    if (_LoginEntity.RoleID  == "8")
        //    {
        //        strQuery = "	SELECT L.*,R.RoleName,R.DashBoardName,P.* from [Login] L Left join [Role] R on L.RoleID = R.RoleID left join PatientMaster P on L.ClinicID = P.patientid where L.UserName=@User_Name and L.Password=@Password ";
        //    }
        //    else
        //    {
        //        strQuery = "SELECT L.*,R.RoleName,R.DashBoardName,D.* from [Login] L Left join [Role] R on L.RoleID = R.RoleID left join tbl_DoctorDetails D on L.ClinicID = D.DoctorID where L.UserName=@User_Name and L.Password=@Password ";

        //    }



        //    objGeneral.AddParameterWithValueToSQLCommand("@User_Name", _LoginEntity.UserName);
        //    objGeneral.AddParameterWithValueToSQLCommand("@Password", _LoginEntity.Password);
        //    objGeneral.AddParameterWithValueToSQLCommand("@RoleID", _LoginEntity.RoleID);
        //       return  objGeneral.GetDatasetByCommand ("strQuery");



        //}


    }
}

