using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;


namespace OrthoSquare
{
    public partial class Login : System.Web.UI.Page
    {
        BasePage objBasePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

       

        protected void btnlogin_Click1(object sender, EventArgs e)
        {
            LoginEntity _LoginEntity = new LoginEntity();
            _LoginEntity.UserName = txtUserName.Text;
            _LoginEntity.Password = txtPassword.Text;

            BAL_Login _ballogin = new BAL_Login();
            DataTable _dtLogin = _ballogin.getLoginDetails(_LoginEntity);



            SessionUtilities.UserID = int.Parse(_dtLogin.Rows[0]["UserID"].ToString());
            SessionUtilities.Empid = int.Parse(_dtLogin.Rows[0]["ClinicID"].ToString());
            SessionUtilities.RoleID = int.Parse(_dtLogin.Rows[0]["RoleID"].ToString());




            if (Convert.ToInt32(_dtLogin.Rows[0][0].ToString()) == -1)
            {
                //   lblMessage.Visible = true;
                // lblMessage.ForeColor = System.Drawing.Color.Red;
                //  lblMessage.Text = "Enter Correct User Name or Password";
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Enter Correct User Name or Password')", true);
            }
            else
            {
                Session["User"] = _dtLogin;

                if (SessionUtilities.RoleID == 1)
                {
                    Response.Redirect("Dashboard/BranchDashboard.aspx");
                }
                else if (SessionUtilities.RoleID == 2)
                {

                    Response.Redirect("Dashboard/SuperAdminDashboard.aspx");
                }
                else
                {

                    Response.Redirect("Dashboard/DocterDashboard.aspx");

                }
            }
        }
    }
}