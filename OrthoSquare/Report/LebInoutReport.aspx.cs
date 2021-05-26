using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System.IO;


namespace OrthoSquare.Report
{
    public partial class LebInoutReport : System.Web.UI.Page
    {

        BAL_Patient objp = new BAL_Patient();
        BAL_LabsDetails objLab = new BAL_LabsDetails();

        int cid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
                BindPatient();
                BindInoutRepot();
            }
        }


        public void BindPatient()
        {
            ddlpatient.DataSource = objp.GetPatientlist();
            ddlpatient.DataTextField = "Fname";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();
            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindInoutRepot()
        {
            if (SessionUtilities.RoleID == 1)
            {
                cid = SessionUtilities.Empid;
            }

            DataTable dt = objLab.GetLabsInoutReport(Convert.ToInt32(ddlpatient.SelectedValue), cid);
            GridinoutLab.DataSource = dt;
            GridinoutLab.DataBind();
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridinoutLab.PageIndex = e.NewPageIndex;
            BindInoutRepot();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblinEnqDate = (Label)e.Row.FindControl("lblinEnqDate");

                Label lbloutEnqDate = (Label)e.Row.FindControl("lbloutEnqDate");


                
                if (lblinEnqDate.Text == "01-01-1990")
                {
                    lblinEnqDate.Text = "";
                }


                if (lbloutEnqDate.Text == "01-01-1990")
                {
                    lbloutEnqDate.Text = "";
                }

            }
        }


        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInoutRepot();
        }
    }
}