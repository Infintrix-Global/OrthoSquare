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
            ddlpatient.DataTextField = "FristName";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();

            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindInoutRepot()
        {

            DataTable dt = objLab.GetLabsInoutReport(Convert.ToInt32(ddlpatient.SelectedValue));
            GridinoutLab.DataSource = dt;

            GridinoutLab.DataBind();


        }



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridinoutLab.PageIndex = e.NewPageIndex;
            BindInoutRepot();
        }

        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInoutRepot();
        }
    }
}