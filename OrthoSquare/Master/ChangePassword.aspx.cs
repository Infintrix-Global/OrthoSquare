
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
namespace OrthoSquare.Master
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BAL_Login objL = new BAL_Login();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
           
        }

        private void Clear()
        {
            txtPassword.Text = "";
            txtOldPassword.Text = "";
            txtConfirmPswd.Text = "";
        }


        private void ChangeUserPassword()
        {
            int userid = SessionUtilities.UserID;



            DataTable dtUser = objL.CheckUserExists(userid, txtOldPassword.Text);
           
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                try
                {
                    bool result = false;

                   // string strNewEncryptedPassword = objBasePage.Encryptdata(txtConfirmPswd.Text.Trim());

                    result = objL.UpdatePassword(userid, txtOldPassword.Text, txtConfirmPswd .Text);
                    if (result == true)
                    {
                      

                       
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                        lblMessage.Text = "User password changed successfully.";
                    }
                    else
                    {
                      
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Unable to change password.";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
               
                lblMessage.Text = "Please check your old credentials.";
            }
            Clear();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            ChangeUserPassword();
        }

    }
}