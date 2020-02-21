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
    public partial class ExpenseReport : System.Web.UI.Page
    {
        BAL_Expense objExp = new BAL_Expense();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        decimal sumFooterValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               

                if(SessionUtilities .RoleID ==2)
                {
                    bindClinic();
                    getAllExpense();


                }
                else
                {
                    bindClinic();

                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString ();
                  //  ddlClinic.Enabled = false;
                    bindDoctorMaster(SessionUtilities.Empid);
                    getAllExpense();

                }

               // BindDocter();
               // BindDocterSearch();
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
         //   btSearch_Click(sender, e);
            getAllExpense();
        }


        public void bindDoctorMaster(int Cid)
        {
            ddlDocter.DataSource = objcommon.DoctersMaster(Cid);
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        public void bindClinic()
        {
            ddlClinic.DataSource = objc.GetAllClinicDetais();
            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void getAllExpense()
        {
            string Docter = "";

            if (ddlDocter.SelectedValue=="")
            {

                Docter = "0";
            }
            else
            {
                Docter = ddlDocter.SelectedValue;
              
            }



            AllData = objExp.GetAllExpenSeReport(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(Docter), txtFromDate.Text, txtToDate.Text);
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllExpense();

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert .ToInt32 (ddlClinic .SelectedValue));
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