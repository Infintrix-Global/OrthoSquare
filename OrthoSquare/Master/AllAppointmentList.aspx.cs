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
    public partial class AllAppointmentList : System.Web.UI.Page
    {

        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
                //bindDoctorMaster();
                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                    // BindPatient();
                }

                string DateToday = "1";
                GridTodayAppoinmentget(DateToday);
            }
        }



        public void GridTodayAppoinmentget(string DateToday)
        {
            int App = 0;
            int Cid = 0;
            int Did = 0;
            if (RadlistAp.SelectedValue == "")
            {

                App = 0;
            }
            else
            {
                App = Convert.ToInt32(RadlistAp.SelectedValue);

            }

            if(SessionUtilities .RoleID ==1)
            {

                Cid = Convert .ToInt32 (ddlClinic.SelectedValue );

            }
            if (SessionUtilities.RoleID == 3)
            {
                Did = Convert.ToInt32(ddlDocter.SelectedValue);
               // ddlDocter.SelectedValue =SessionUtilities.Empid.ToString ();

            }

            AllData = objApp.GetAllListtodayAppoinmentDetails(txtName.Text, txtMobile.Text, Did, Cid, App, txtSFromFollowDate.Text, txtSToFollowDate.Text, DateToday);

            GridAppoinment.DataSource = AllData;
            GridAppoinment.DataBind();

        }

        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objc.GetAllClinicDetais();

            }
            ddlClinic.DataSource = dt;

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }


        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            }

            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));

        }




        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Approve")
            {

                int _isDeleted = objApp.GetApprove(Aid);
                string DateToday = "";
                GridTodayAppoinmentget(DateToday);
                Response.Redirect("AllAppointmentList.aspx");

            }
            if (e.CommandName == "Reject")
            {


                int _isDeleted = objApp.GetReject(Aid);
                Response.Redirect("AllAppointmentList.aspx");
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
            string DateToday = "";
            GridTodayAppoinmentget(DateToday);
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