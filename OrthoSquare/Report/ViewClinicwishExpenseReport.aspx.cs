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
    public partial class ViewClinicwishExpenseReport : System.Web.UI.Page
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

                getAllExpense();
            }
        }
        public void getAllExpense()
        {

            AllData = objExp.GetAllClinicviewExpenSeReport(Convert.ToInt32(SessionUtilities.Empid), txtSFromFollowDate.Text, txtSToFollowDate.Text);
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