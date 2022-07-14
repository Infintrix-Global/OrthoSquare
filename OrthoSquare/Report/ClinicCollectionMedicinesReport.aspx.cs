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
using System.Text;
namespace OrthoSquare.Report
{
    public partial class ClinicCollectionMedicinesReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                txtFromPayDate.Text = Convert.ToDateTime(System.DateTime.Now).AddDays(-15).ToString("dd-MM-yyyy");
                txtToPayDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


                bindClinic();
                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                }
                getAllCollection();
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

        public void getAllCollection()
        {

            AllData = objExp.GetAllClinicCollectionMedicines_Report(txtFromPayDate.Text, txtToPayDate.Text, Convert.ToInt32(ddlClinic.SelectedValue));

            //gvShow.DataSource = AllData;
            //gvShow.DataBind();

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(AllData.Rows[i]["PaidAmount"]);


                }
                lblTotalTop.Text = Total.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblTotalTop.Text = "0";
                gvShow.DataSource = null;
                gvShow.DataBind();
            }

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
              
                Label lblClinicID = (Label)e.Row.FindControl("lblClinicID");


                // lblPendingAmount.Text = objExp.GetPendingAmount(Convert.ToInt32  (lblClinicID.Text),0,0).ToString();


                sumFooterValue += Convert.ToDecimal(lblPaidAmount.Text);
               
            }

            // lblTotalTop.Text = sumFooterValue.ToString();
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblPaidAmountTotal = (Label)e.Row.FindControl("lblPaidAmountTotal");
              
                lblPaidAmountTotal.Text = sumFooterValue.ToString();
              
            }
        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btExcel_Click11(object sender, ImageClickEventArgs e)
        {

            AllData = objExp.GetAllClinicCollectionMedicines_Report(txtFromPayDate.Text, txtToPayDate.Text, Convert.ToInt32(ddlClinic.SelectedValue));

            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename="+ "Medicines_" + DateTime.Now.ToString("yyyy-MM-dd") +".xls");
            response.AddHeader("Content-Type", "application/Excel");
            response.ContentType = "application/vnd.xlsx";
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    GridView gridView = new GridView();
                    gridView.DataSource = AllData;
                    gridView.DataBind();
                    gridView.RenderControl(htw);
                    response.Write(sw.ToString());
                    gridView.Dispose();
                    AllData.Dispose();
                    response.End();
                }
            }
        }

    }
}