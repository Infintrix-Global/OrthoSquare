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

namespace OrthoSquare.Invoice
{
    public partial class PayMentReport : System.Web.UI.Page
    {
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
                BindDocter(0);
                getAllPaymentMode();
            }
        }


        public void bindClinic()
        {

            DataTable dt;
            dt = objc.GetAllClinicDetais();
            ddlclinicSearch.DataSource = dt;
            ddlclinicSearch.DataValueField = "ClinicID";
            ddlclinicSearch.DataTextField = "ClinicName";
            ddlclinicSearch.DataBind();
            ddlclinicSearch.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        protected void ddlclinicSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlclinicSearch.SelectedValue));

        }
        public void BindDocter(int Cid)
        {

            ddlDoctors.DataSource = objcomm.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            ddlDoctors.DataTextField = "FirstName";
            ddlDoctors.DataValueField = "DoctorID";
            ddlDoctors.DataBind();
            ddlDoctors.Items.Insert(0, new ListItem("--- Select Doctor---", "0"));
        }

        public void getAllPaymentMode()
        {

            string payM = "";
            if (ddlPayMode.SelectedItem.Text == "---Select---")
            {
                payM = "";
            }
            else
            {
                payM = ddlPayMode.SelectedItem.Text;
            }

            AllData = objinv.GetAllPayMentModeDetails(Convert.ToInt32(ddlclinicSearch.SelectedValue), Convert.ToInt32(ddlDoctors.SelectedValue), txtFromPayDate.Text, txtToPayDate.Text, payM);

          //  Session["PayDetsils"] = AllData;
            GridViewPaymode.DataSource = AllData;
            GridViewPaymode.DataBind();


        }


        public void getAllPayment()
        {

            string payM = "";
            if (ddlPayMode.SelectedItem.Text == "---Select---")
            {
                payM = "";
            }
            else
            {
                payM = ddlPayMode.SelectedItem.Text;
            }

            AllData = objinv.GetAllPayMentDetails(Convert.ToInt32(ddlclinicSearch.SelectedValue), Convert.ToInt32(ddlDoctors.SelectedValue), txtFromPayDate.Text, txtToPayDate.Text, payM);

            Session["PayDetsils"] = AllData;
            gvShow.DataSource = AllData;
            gvShow.DataBind();


        }
        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllPayment();
        }

        protected void GridViewPaymode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPaymode.PageIndex = e.NewPageIndex;
            getAllPaymentMode();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllPaymentMode();
        }

        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            DataTable dtDataExcel = (DataTable)Session["PayDetsils"];

            if (dtDataExcel != null && dtDataExcel.Rows.Count > 0)
            {
                List<ExcelRows> objExcelRows = new List<ExcelRows>();
                ExcelRows obj = new ExcelRows();
                obj.ColumnHeaderName = "Enquiry Report";
                obj.ColumnValue = null;
                objExcelRows.Add(obj);

                GridViewExportUtil.ExportToExcelManual("EnquiryReport", objExcelRows, dtDataExcel, null);

            }
            else
            {
                return;
            }
        }

        protected void GridViewPaymode_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PanelPayMode.Visible = false;
            PanelViewDetails.Visible = true;
            string strpay = e.CommandArgument.ToString();
            ddlPayMode.SelectedItem.Text = strpay;
            getAllPayment();

        }
    }
}