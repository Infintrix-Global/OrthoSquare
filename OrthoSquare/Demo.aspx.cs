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
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace OrthoSquare
{
    public partial class Demo : System.Web.UI.Page
    {

        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridSplitjob();
            }
        }


        public void GridSplitjob()
        {

            DataTable dt= objM.Demo(0);
            GridViewInvoiceDetails.DataSource = dt;
            GridViewInvoiceDetails.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            int _isInserted = -1;

            foreach (GridViewRow row in GridViewInvoiceDetails.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    NameValueCollection nv = new NameValueCollection();

                    Label lblInvoiceTid = (row.Cells[0].FindControl("lblInvoiceTid") as Label);
                    Label lblInvoiceNo = (row.Cells[0].FindControl("lblInvoiceNo") as Label);

                
                    nv.Add("@InvoiceTid", lblInvoiceTid.Text);
                    nv.Add("@InvoiceNo", lblInvoiceNo.Text);

                    _isInserted = objG.GetDataExecuteScaler("sp_UpdateInvoicePayment", nv);



                }
            }
        }
    }
}