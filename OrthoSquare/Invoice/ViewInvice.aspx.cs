using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Invoice
{
    public partial class ViewInvice : System.Web.UI.Page
    {

        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        public static DataTable AllData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAllInvoice();

            }
        }

        public void getAllInvoice()
        {

            AllData = objinv.GetAllInvoicDispaly();
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllInvoice();
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int invCode = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Viewinv")
            {
                //Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invCode);

                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Int32 rowind = gvRow.RowIndex;
                Label lblInvoiceCode = (Label)gvRow.FindControl("lblInvoiceCode");

                Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invCode + "&Fid=" + lblInvoiceCode.Text);
            }
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtSearch.Text != "")
                {
                    search += "PFristName like '%" + txtSearch.Text + "%'";
                }
                else
                {
                    // search += "Mobile = " + txtm.Text + "";
                }

                DataRow[] dtSearch1 = AllData.Select(search);
                if (dtSearch1.Count() > 0)
                {
                    DataTable dtSearch = dtSearch1.CopyToDataTable();
                    gvShow.DataSource = dtSearch;
                    gvShow.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvShow.DataSource = dt;
                    gvShow.DataBind();
                }
                //}
                //else
                //{
                //    gvShow.DataSource = AllData;
                //    gvShow.DataBind();
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
          // Edit.Visible = false;
          // .. Add.Visible = true;
        }
    }
}