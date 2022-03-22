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

            // DataTable SEM = _ballogin.CheckSoftwareExpiredMaster();

            DateTime dateTime = DateTime.UtcNow.Date;
            string Todate = dateTime.ToString("yyyyMMdd");

            // string ExpDate = Convert.ToDateTime(SEM.Rows[0]["ExpiredDate"]).ToString("yyyyMMdd");

            //if (Convert.ToInt32(Todate) > Convert.ToInt32(ExpDate))
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Your software has been expired')", true);

            //}
            //else
            //{
            if (Convert.ToInt32(_dtLogin.Rows[0][0].ToString()) == -1)
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Enter Correct User Name or Password')", true);
            }
            else
            {


                SessionUtilities.UserID = int.Parse(_dtLogin.Rows[0]["UserID"].ToString());
                SessionUtilities.Empid = int.Parse(_dtLogin.Rows[0]["ClinicID"].ToString());
                SessionUtilities.RoleID = int.Parse(_dtLogin.Rows[0]["RoleID"].ToString());


                Session["User"] = _dtLogin;

                if (SessionUtilities.RoleID == 1)
                {
                    Response.Redirect("Dashboard/BranchDashboard.aspx");
                }
                else if (SessionUtilities.RoleID == 2)
                {

                    Response.Redirect("Dashboard/SuperAdminDashboard.aspx");
                }
                else if (SessionUtilities.RoleID == 3)
                {

                    Response.Redirect("Dashboard/DocterDashboard.aspx");

                }
                else if (SessionUtilities.RoleID == 4)
                {

                    Response.Redirect("Dashboard/AccountDashoard.aspx");

                }
                else if (SessionUtilities.RoleID == 9)
                {

                    Response.Redirect("Dashboard/TelecallerDashoard.aspx");

                }
                else if (SessionUtilities.RoleID == 5)
                {

                    Response.Redirect("Dashboard/TelecallerDashoard.aspx");

                }
                else if (SessionUtilities.RoleID == 10)
                {

                    Response.Redirect("Dashboard/TelecallerDashoard.aspx");

                }
                else
                {

                }


                // }
            }
        }
    }
}