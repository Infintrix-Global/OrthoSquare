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
    public partial class ClinicwishExpenseReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        decimal sumFooterValue = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
                if(SessionUtilities .RoleID ==1)
                {

                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                }
                getAllExpense();
            }
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

        public void getAllExpense()
        {

            AllData = objExp.GetAllClinicExpenSeReport(Convert.ToInt32(ddlClinic.SelectedValue), txtSFromFollowDate.Text, txtSToFollowDate.Text);
            gvShow.DataSource = AllData;
            gvShow.DataBind();


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllExpense();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllExpense();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                sumFooterValue += Convert.ToDecimal(lblAmount.Text);
            }

            lblTotalTop.Text = sumFooterValue.ToString();
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = sumFooterValue.ToString();


            }
        }
    }
}