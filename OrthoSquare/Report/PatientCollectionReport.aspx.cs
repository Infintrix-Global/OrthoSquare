using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.IO;

namespace OrthoSquare.Report
{
    public partial class PatientCollectionReport : System.Web.UI.Page
    {

        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();

        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (SessionUtilities.RoleID == 2)
            {
                bindClinic();
                getAllCollection();


            }
            else
            {
                bindClinic();

                ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                //  ddlClinic.Enabled = false;
                bindDoctorMaster(SessionUtilities.Empid);
                getAllCollection();

            }
        }



        public void bindClinic()
        {
            ddlClinic.DataSource = objc.GetAllClinicDetais();
            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void bindDoctorMaster(int Cid)
        {
            ddlDocter.DataSource = objcommon.DoctersMaster(Cid);
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }



        public void getAllCollection()
        {

            AllData = objExp.GetAllPatientCollectionReport(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue));
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();

        }



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllCollection();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                Label lblPendingAmount = (Label)e.Row.FindControl("lblPendingAmount");

                Label lblpatientid = (Label)e.Row.FindControl("lblpatientid");

                lblPendingAmount.Text = objExp.GetPendingAmount(0, 0, Convert.ToInt32(lblpatientid.Text)).ToString();





                sumFooterValue += Convert.ToDecimal(lblPaidAmount.Text);
                sumFooterPendingValue += Convert.ToDecimal(lblPendingAmount.Text);

            }

            // lblTotalTop.Text = sumFooterValue.ToString();
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblPaidAmountTotal = (Label)e.Row.FindControl("lblPaidAmountTotal");
                Label lblPendingAmountTotal = (Label)e.Row.FindControl("lblPendingAmountTotal");
                lblPaidAmountTotal.Text = sumFooterValue.ToString();
                lblPendingAmountTotal.Text = sumFooterPendingValue.ToString();

            }
        }
    }
}