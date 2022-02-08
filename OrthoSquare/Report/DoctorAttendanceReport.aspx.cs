using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;

using OrthoSquare.Utility;

namespace OrthoSquare.Report
{

    
    public partial class DoctorAttendanceReport : System.Web.UI.Page
    {
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
        int cid = 0,Did=0;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
              

                BindDocter();
                if(SessionUtilities.RoleID == 3)
                {
                    ddlDoctor.SelectedValue = SessionUtilities.Empid.ToString ();

                }
                BindDocterAttendance();
            }
        }

        public void BindDocter()
        {

            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcomm.DoctersMasterNew(SessionUtilities.Empid, SessionUtilities.RoleID);


            }
            else
            {
                ddlDoctor.DataSource = objcomm.DoctersMasterNew(0, SessionUtilities.RoleID);

            }


           // ddlDoctor.DataSource = objdoc.GetAllDocters(Did);
            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();

            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        protected void gvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDocterAttendance.PageIndex = e.NewPageIndex;
            BindDocterAttendance();
        }
        public void BindDocterAttendance()
        {

            if (SessionUtilities.RoleID == 1)
            {
                cid = SessionUtilities.Empid;
                Did = 0;
            }
            else if (SessionUtilities.RoleID == 3)
            {
                Did = Convert .ToInt32(ddlDoctor.SelectedValue) ;
                cid = 0;
            }
            else
            {
                cid = 0;
                Did = 0;
            }

            DataTable dt = objdoc.GetDoctersDate_Attendance(Convert.ToInt32(ddlDoctor.SelectedValue), txtSFromFollowDate.Text, txtSToFollowDate.Text, cid);
            GridDocterAttendance.DataSource = dt;

            GridDocterAttendance.DataBind();


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDocterAttendance();
        }
    }
}