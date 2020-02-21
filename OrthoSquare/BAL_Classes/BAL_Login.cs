using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace OrthoSquare.BAL_Classes
{
    public class BAL_Login
    {
        public DataTable getLoginDetails(LoginEntity _loginEntity)
        {
            General objGeneral = new General();
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
    }
}