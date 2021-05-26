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

namespace OrthoSquare.Dashboard
{
    public partial class AccountDashoard : System.Web.UI.Page
    {
        BAL_Expense objExp = new BAL_Expense();
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcommon = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TotalInvoice();
                TotalExpense();
                getAllExpense();
                getAllCollectionAccount();
            }
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
    }
}