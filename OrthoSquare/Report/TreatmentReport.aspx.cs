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
using PreconFinal.Utility;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Text;

namespace OrthoSquare.Report
{
    public partial class TreatmentReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Finance objF = new BAL_Finance();
        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSFromFollowDate.Text = Convert.ToDateTime(System.DateTime.Now).AddDays(-15).ToString("dd-MM-yyyy");
                txtSToFollowDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


                bindClinic();
                bindTreatmentGroup();


                getAllCollection();



            }
        }

        private long DoctorId
        {
            get
            {
                if (ViewState["DoctorId"] != null)
                {
                    return (long)ViewState["DoctorId"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorId"] = value;
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
                if (DoctorId > 0)
                {
                    dt = objcommon.GetDoctorByClinic(Convert.ToInt32(DoctorId));
                }
                else
                {
                    dt = objc.GetAllClinicDetais();
                }


            }
            ddlClinic.DataSource = dt;

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void bindTreatmentGroup()
        {

            DataTable dt;

            dt = objExp.GET_TreatmentGroup();

            ddlTreatmentGroup.DataSource = dt;

            ddlTreatmentGroup.DataValueField = "GroupID";
            ddlTreatmentGroup.DataTextField = "GroupName";
            ddlTreatmentGroup.DataBind();
            ddlTreatmentGroup.Items.Insert(0, new ListItem("-- Select Group Name --", "0", true));

        }


        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }

        public void getAllCollection()
        {
            Total = 0;
            AllData = objExp.GetAllTreatmentReport(txtSFromFollowDate.Text, txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(RadioButtonListFinance.SelectedValue), Convert.ToInt32(ddlTreatmentGroup.SelectedValue));

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(AllData.Rows[i]["GrandTotal"]);

                  
                }
                lblGrandTotal.Text = Total.ToString();
                lblTotalCount.Text = AllData.Rows.Count.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblGrandTotal.Text = "0";
                gvShow.DataSource = null;
                gvShow.DataBind();
            }

            DataTable DtSum = new DataTable();
            DtSum = objExp.GetAllTreatmentReport(txtSFromFollowDate.Text, txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), 4, Convert.ToInt32(ddlTreatmentGroup.SelectedValue));
            if (DtSum != null && DtSum.Rows.Count > 0)
            {
                lblPaidAmount.Text = DtSum.Rows[0]["PaidAmount"].ToString();       
            }
            else
            {
                lblPaidAmount.Text = "0";
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

        protected void RadioButtonListFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total = 0;
            getAllCollection();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
        }

        protected void ddlTreatmentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total = 0;
            getAllCollection();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btExcel_Click(object sender, ImageClickEventArgs e)
        {

           
            AllData = objExp.GetAllTreatmentReport(txtSFromFollowDate.Text, txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(RadioButtonListFinance.SelectedValue), Convert.ToInt32(ddlTreatmentGroup.SelectedValue));


            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
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