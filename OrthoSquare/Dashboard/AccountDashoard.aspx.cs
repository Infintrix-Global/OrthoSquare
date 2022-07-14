using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;

namespace OrthoSquare.Dashboard
{
    public partial class AccountDashoard : System.Web.UI.Page
    {
        BAL_Expense objExp = new BAL_Expense();
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcommon = new clsCommonMasters();
        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TotalInvoice();
                TotalExpense();
                getAllExpense();
                getAllCollectionAccount();
                AdminCount();
            }
        }


        public void AdminCount()
        {
            NameValueCollection nv = new NameValueCollection();

            DataSet ds = objG.GetDataSet("GET_AdminCount", nv);
            DataTable dtEY = ds.Tables[0];
            DataTable dtEM = ds.Tables[1];
            DataTable dtED = ds.Tables[2];

            DataTable dtFY = ds.Tables[3];
            DataTable dtFM = ds.Tables[4];
            DataTable dtFD = ds.Tables[5];

            DataTable dtCEY = ds.Tables[6];
            DataTable dtCEM = ds.Tables[7];
            DataTable dtCED = ds.Tables[8];

            DataTable dtNPY = ds.Tables[9];
            DataTable dtNPM = ds.Tables[10];
            DataTable dtNPD = ds.Tables[11];

            DataTable dtVPY = ds.Tables[12];
            DataTable dtVPM = ds.Tables[13];
            DataTable dtVPD = ds.Tables[14];


            DataTable dtTCY = ds.Tables[15];
            DataTable dtTCM = ds.Tables[16];
            DataTable dtTCD = ds.Tables[17];

            DataTable dtPMY = ds.Tables[18];
            DataTable dtPMM = ds.Tables[19];
            DataTable dtPMD = ds.Tables[20];

            DataTable dtPEY = ds.Tables[21];
            DataTable dtPEM = ds.Tables[22];
            DataTable dtPED = ds.Tables[23];

            lblEnqYear.Text = dtEY.Rows[0]["EnquiryYear"].ToString();
            lblEnqMonth.Text = dtEM.Rows[0]["EnquiryMonth"].ToString();
            lbllblEnqDay.Text = dtED.Rows[0]["EnquiryDay"].ToString();

            lblFollouwpsYear.Text = dtFY.Rows[0]["FolllowuYear"].ToString();
            lblFollouwpsMonth.Text = dtFM.Rows[0]["FolllowuMonth"].ToString();
            lblFollouwpsDay.Text = dtFD.Rows[0]["FolllowuDay"].ToString();

            lblConversionYear.Text = dtCEY.Rows[0]["ConversionYear"].ToString();
            lblConversionMonth.Text = dtCEM.Rows[0]["ConversionMonth"].ToString();
            lblConversionDay.Text = dtCED.Rows[0]["ConversionDay"].ToString();

            lblNewYear.Text = dtNPY.Rows[0]["NewYear"].ToString();
            lblNewMonth.Text = dtNPM.Rows[0]["NewMonth"].ToString();
            lblNewDay.Text = dtNPD.Rows[0]["NewDay"].ToString();

            lblVisitsYear.Text = dtVPY.Rows[0]["PatientYear"].ToString();
            lblVisitsMonth.Text = dtVPM.Rows[0]["PatientMonth"].ToString();
            lblVisitsDay.Text = dtVPD.Rows[0]["PatientDay"].ToString();


            lblTreatCollYear.Text = Convert.ToDecimal(dtTCY.Rows[0]["TotalAmountYear"]).ToString("#,##0.00");
            lblTreatCollMonth.Text = Convert.ToDecimal(dtTCM.Rows[0]["TotalAmountMonth"]).ToString("#,##0.00");
            lblTreatCollDay.Text = Convert.ToDecimal(dtTCD.Rows[0]["TotalAmountDay"]).ToString("#,##0.00");

            lblMediCollYear.Text = Convert.ToDecimal(dtPMY.Rows[0]["GrandTotalYear"]).ToString("#,##0.00");
            lblMediCollMonth.Text = Convert.ToDecimal(dtPMM.Rows[0]["GrandTotalMonth"]).ToString("#,##0.00");
            lblMediCollDay.Text = Convert.ToDecimal(dtPMD.Rows[0]["GrandTotalDay"]).ToString("#,##0.00");


            lblExpenseYear.Text = Convert.ToDecimal(dtPEY.Rows[0]["AmountYear"]).ToString("#,##0.00");
            lblExpenseMonth.Text = Convert.ToDecimal(dtPEM.Rows[0]["AmountMonth"]).ToString("#,##0.00");
            lblExpenseDay.Text = Convert.ToDecimal(dtPED.Rows[0]["AmountDay"]).ToString("#,##0.00");

        }


        public void TotalInvoice()
        {
            DataTable dt = objcommon.GETFinancialYearDATE();

            lblCollectionF.Text = dt.Rows[0]["QM_FIN_YEAR"].ToString().Substring(0, 7);

            decimal Totalinv1 = objcommon.GetTotalPaidAmount(0);
            decimal TotalinvF1 = objcommon.GetTotalPaidAmountFYear(0);
            if (Totalinv1 != 0)
            {
                totalinvoice.Text = Totalinv1.ToString("#,##0.00");
                lblFCollecion.Text = TotalinvF1.ToString("#,##0.00");

                //totalinvoice.Text = Totalinv1.ToString();
                //lblFCollecion.Text = TotalinvF1.ToString();
            }
            else
            {

                totalinvoice.Text = "0.00";
            }
        }

        public void TotalExpense()
        {

            DataTable dt = objcommon.GETFinancialYearDATE();

            lblFEYear.Text = dt.Rows[0]["QM_FIN_YEAR"].ToString().Substring(0, 7);

            decimal TotalExp = objcommon.GetTotalExpenseAC(0);
            decimal TotalExpFY = objcommon.GetTotalExpenseFYear(0);
            if (TotalExp != 0)
            {
                lblExp.Text = TotalExp.ToString("#,##0.00");
                lblFExpenses.Text = TotalExpFY.ToString("#,##0.00");
            }
            else
            {

                lblExp.Text = "0.00";
            }
        }

        public void getAllExpense()
        {
            string FromDate = Convert .ToDateTime(System.DateTime.Now.AddDays(-3)).ToString ("dd-MM-yyyy");
            string TODate = Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy");


            AllData = objExp.GetAllExpenSeReport(0,0, FromDate, TODate);
           
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void getAllCollectionAccount()
        {
            string FromDate = Convert.ToDateTime(System.DateTime.Now.AddDays(-3)).ToString("dd-MM-yyyy");
            string TODate = Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy");


          DataTable  AllData1 = objExp.GetAllDocterCollectionReportNew1Account(FromDate, TODate);

            GridViewinvAccount.DataSource = AllData1;
            GridViewinvAccount.DataBind();

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
              
            }

          
        }

        protected void GridViewinvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewinvAccount.PageIndex = e.NewPageIndex;
            getAllCollectionAccount();
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllExpense();
        }
    }
}