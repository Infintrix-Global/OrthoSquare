using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace OrthoSquare.Dashboard
{
    public partial class TelecallerDashoard : System.Web.UI.Page
    {
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_FollowupMode objFMode = new BAL_FollowupMode();
        clsCommonMasters objcommon = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindASSIGNENQUIRIES();
                BINDPENDINGFOLLOWUPS();
                FollowupNo();
                BindFolloupview();
            }

        }


        public void BindASSIGNENQUIRIES()
        {

            int Eno = objcommon.GetASSIGNENQUIRIES1(SessionUtilities.Empid);
            lblEnq.Text = Eno.ToString();
        }

        public void BINDPENDINGFOLLOWUPS()
        {

            int Eno = objcommon.GetPENDINGFOLLOWUPSTelecaller(SessionUtilities.Empid);
            lblpendingFollowup.Text = Eno.ToString();
        }


        public void FollowupNo()
        {

            int Eno = objcommon.GetFollowupCountNoTelecaller(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            lblFollwupCOunt.Text = Eno.ToString();
        }


        public void BindFolloupview()
        {

            GridViewFolloupDetils1.DataSource = objFMode.FolloupSearchTellecallList1(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            GridViewFolloupDetils1.DataBind();



        }

        protected void GridViewFolloupDetils1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFolloupDetils1.PageIndex = e.NewPageIndex;
            BindFolloupview();
        }

        protected void GridViewFolloupDetils1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "FollowupEnquiry")
            {
                string Eid = e.CommandArgument.ToString();
             
                Response.Redirect("../Enquiry/FollowupDetails.aspx?Eid=" + Eid);
            }
        }
    }
}