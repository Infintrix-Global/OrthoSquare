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


        int Did = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               

                if(SessionUtilities .RoleID ==1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMaster(SessionUtilities.Empid);
                 //   getAllExpense();


                }
                else
                {
                    bindClinic();

                    ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));
                    //  ddlClinic.Enabled = false;
                    // bindDoctorMaster(SessionUtilities.Empid);
                    getAllExpense();

                }

               // BindDocter();
               // BindDocterSearch();
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
         //   gvShow.PageIndex = e.NewPageIndex;
         ////   btSearch_Click(sender, e);
         //   getAllExpense();
        }


        public void bindDoctorMaster(int Cid)
        {

           
  
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);
            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMasterAdmin(Cid);
            }



            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "DoctorName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

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
            AllData = objExp.GetAllExpenSeReport(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue), txtFromDate.Text, txtToDate.Text);
            DataTable dt = objExp.GetAllExpenSeReportEXL(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue), txtFromDate.Text, txtToDate.Text);

            Session["ExpenseDetails"] = dt;

            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllExpense();

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert .ToInt32 (ddlClinic.SelectedValue));
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                Label lblFormPlace = (Label)e.Row.FindControl("lblFormPlace");
                Label lblToPlace = (Label)e.Row.FindControl("lblToPlace");
                Label lblVendorName = (Label)e.Row.FindControl("lblVendorName");
                Label lblVendorType = (Label)e.Row.FindControl("lblVendorType");

                if (lblVendorType.Text == "Travelling")
                {
                    if (lblFormPlace.Text != "")
                    {
                        lblVendorName.Text = "From " + lblFormPlace.Text + "  To " + lblToPlace.Text;
                    }
                    else
                    {
                        lblVendorName.Text = "";
                    }
                }
                sumFooterValue += Convert.ToDecimal(lblAmount.Text);
            }

            lblTotalTop.Text = sumFooterValue.ToString();
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = sumFooterValue.ToString();


            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExcel1_Click1(object sender, EventArgs e)
        {
            DataTable dtDataExcel = (DataTable)Session["ExpenseDetails"];

            if (dtDataExcel != null && dtDataExcel.Rows.Count > 0)
            {
                List<ExcelRows> objExcelRows = new List<ExcelRows>();
                ExcelRows obj = new ExcelRows();
                obj.ColumnHeaderName = "Expense Report";
                obj.ColumnValue = null;
                objExcelRows.Add(obj);

                GridViewExportUtil.ExportToExcelManual("ExpenseReport", objExcelRows, dtDataExcel, null);
               // lblMessage.Text = "";
            }
            else
            {
              //  lblMessage.Visible = true;
              //  lblMessage.Text = "No Record exists for Excel Download.";
                return;
            }
        }

    }
}