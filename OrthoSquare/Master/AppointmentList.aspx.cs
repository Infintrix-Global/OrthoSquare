using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Master
{
    public partial class AppointmentList : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Appointment objApp = new BAL_Appointment();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindDoctorMaster();
                GridTodayAppoinmentget();
            }
        }

        public void GridTodayAppoinmentget()
        {
            int App = 0;
            if (RadlistAp.SelectedValue =="")
            {

                App =0;
            }
            else
            {
                App = Convert .ToInt32  (RadlistAp.SelectedValue );

            }



            AllData = objApp.GetAllListtodayAppoinmentNew(txtName.Text, txtMobile.Text, Convert.ToInt32(ddlDocter.SelectedValue), App);

            GridAppoinment.DataSource = AllData;
            GridAppoinment.DataBind();

        }

        public void bindDoctorMaster()
        {


            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(SessionUtilities.Empid, SessionUtilities.RoleID);

              

            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(0, SessionUtilities.RoleID);

               
            }




           
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "DoctorName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Approve")
            {

                int _isDeleted = objApp.GetApprove(Aid);
                GridTodayAppoinmentget();
                Response.Redirect("BranchDashboard.aspx");

            }
            if (e.CommandName == "Reject")
            {


                int _isDeleted = objApp.GetReject(Aid);
                Response.Redirect("BranchDashboard.aspx");
            }
        }

        protected void GridAppoinment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblstatus = (Label)e.Row.FindControl("lblstatus");

                if (lblstatus.Text == "True")
                {
                    e.Row.Attributes["style"] = "background-color: #28b779";
                }


            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            GridTodayAppoinmentget();
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fullcalendar/demos/NewAppointmentClinic.aspx");
        }

        protected void Appoinment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAppoinment.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }
    }
}