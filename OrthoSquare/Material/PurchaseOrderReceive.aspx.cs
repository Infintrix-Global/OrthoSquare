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
namespace OrthoSquare.Material
{
    public partial class PurchaseOrderReceive : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        Bal_MaterilaType objMT = new Bal_MaterilaType();
        BAL_Pack objPack = new BAL_Pack();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        clsCommonMasters objcommon = new clsCommonMasters();
        GeneralNew objG = new GeneralNew();
        General objGeneral = new General();
        int SelectedItems = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getAllOrderPurchaseList();

            }
        }

        public void getAllOrderPurchaseList()
        {

            NameValueCollection nv = new NameValueCollection();

            nv.Add("@VendorID", VendorID.ToString());
            nv.Add("@FromDate", "");
            nv.Add("@ToDate", "");
            nv.Add("@PurchaseOrderId", "0");
            nv.Add("@OrderNo", OrderNo);
            nv.Add("@Mode", "1");
            DataTable dt = objG.GetDataTable("GET_MaterialStockPurchaseOrder", nv);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalTop.Text = dt.Rows.Count.ToString();

                gvShow.DataSource = dt;
                gvShow.DataBind();
            }
            else
            {
                gvShow.DataSource = null;
                gvShow.DataBind();
                lblTotalTop.Text = "0";
            }
        }



        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Receive")
            {
                PanelAdd.Visible = true;
                Panellist.Visible = false;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int PurchaseOrderId = Convert.ToInt32(gvShow.DataKeys[rowIndex].Values[0]);

                txtOrder_No.Text = gvShow.DataKeys[rowIndex].Values[1].ToString();

                txtROderDate.Text = Convert.ToDateTime(gvShow.DataKeys[rowIndex].Values[2]).ToString("dd-MM-yyyy");

                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                NameValueCollection nv = new NameValueCollection();

                nv.Add("@VendorID", "0");
                nv.Add("@FromDate", "");
                nv.Add("@ToDate", "");
                nv.Add("@PurchaseOrderId", PurchaseOrderId.ToString());
                nv.Add("@OrderNo", "");
                nv.Add("@Mode", "2");
                DataTable dt = objG.GetDataTable("GET_MaterialStockPurchaseOrder", nv);

                gvAssignMaterial.DataSource = dt;
                gvAssignMaterial.DataBind();
            }
        }



        private long VendorID
        {
            get
            {
                if (ViewState["VendorID"] != null)
                {
                    return (long)ViewState["VendorID"];
                }
                return 0;
            }
            set
            {
                ViewState["VendorID"] = value;
            }
        }


        private string OrderNo
        {
            get
            {
                if (ViewState["OrderNo"] != null)
                {
                    return ViewState["OrderNo"].ToString();
                }
                return "";
            }
            set
            {
                ViewState["OrderNo"] = value;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllOrderPurchaseList();
        }


        protected void txtVendor_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objM.GetVendorNameSelect(txtVendor.Text);
            VendorID = Convert.ToInt32(dt.Rows[0]["VendorID"]);
            getAllOrderPurchaseList();
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchVendorName(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {


                    cmd.CommandText = "Select * from VendorMaster  where VendorTypeId=2 and IsActive=1 and ClinicID=0 and  VendorName like '%" + prefixText + "%'";


                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["VendorName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrderNo(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {


                    cmd.CommandText = "Select * From PurchaseOrderMaster where IsActive=1  and OrderCode like '%" + prefixText + "%'";


                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["OrderCode"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            OrderNo = txtOrderNo.Text;
            getAllOrderPurchaseList();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAssignMaterial.Rows)
            {
                int _isInserted = -1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    General objGeneral = new General();
                    Label lblMaterialId = (row.Cells[0].FindControl("lblMaterialId") as Label);
                    Label lblClinicQty = (row.Cells[0].FindControl("lblClinicQty") as Label);
                    Label lblPurchaseOrderId = (row.Cells[0].FindControl("lblPurchaseOrderId") as Label);
                    TextBox txtAssign = (row.Cells[0].FindControl("txtAssign") as TextBox);
                    TextBox txtRemark = (row.Cells[0].FindControl("txtRemark") as TextBox);
                    TextBox txtPrice = (row.Cells[0].FindControl("txtPrice") as TextBox);
                    //NameValueCollection nv = new NameValueCollection();
                    //nv.Add("@PurchaseOrderId", lblPurchaseOrderId.Text);
                    //nv.Add("@MaterialId", lblMaterialId.Text);
                    //nv.Add("@ReceivedDate", objGeneral.getDatetime(txtDate.Text).ToString());
                    //nv.Add("@RequestQty", lblClinicQty.Text);
                    //nv.Add("@OrderCode", txtOrder_No.Text);
                    //nv.Add("@ActualQty", txtAssign.Text);
                    //nv.Add("@CreateId", SessionUtilities.Empid.ToString());
                    //nv.Add("@Price", txtPrice.Text);

                    //_isInserted = objG.GetDataExecuteScaler("SP_AddPurchaseOrderReceive", nv);


                  
                    objGeneral.AddParameterWithValueToSQLCommand("@PurchaseOrderId", lblPurchaseOrderId.Text);
                    objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", lblMaterialId.Text);
                    objGeneral.AddParameterWithValueToSQLCommand("@ReceivedDate", objGeneral.getDatetime(txtDate.Text));
                    objGeneral.AddParameterWithValueToSQLCommand("@RequestQty", lblClinicQty.Text);
                    objGeneral.AddParameterWithValueToSQLCommand("@OrderCode", txtOrder_No.Text);
                    objGeneral.AddParameterWithValueToSQLCommand("@ActualQty ", txtAssign.Text);
                    objGeneral.AddParameterWithValueToSQLCommand("@CreateId ", Session["Empid"].ToString());
                    objGeneral.AddParameterWithValueToSQLCommand("@Price ", txtPrice.Text);


                    _isInserted = objGeneral.GetExecuteScalarByCommand_SP("SP_AddPurchaseOrderReceive");


                    SelectedItems++;

                }

            }

            string message = "Added Successful";
            string url = "PurchaseOrderReceive.aspx";

            objcommon.ShowMessageAndRedirect(this, message, url);
        }

        protected void btBack_Click(object sender, EventArgs e)
        {

        }


        protected void gvAssignMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblMaterialId = (Label)e.Row.FindControl("lblMaterialId");

                Label lblPurchaseOrderId = (Label)e.Row.FindControl("lblPurchaseOrderId");
                Label lblClinicQty = (Label)e.Row.FindControl("lblClinicQty");

                NameValueCollection nv = new NameValueCollection();
                nv.Add("@MaterialId", lblMaterialId.Text);
                nv.Add("@PurchaseOrderId", lblPurchaseOrderId.Text);

                DataTable dt = objG.GetDataTable("GET_PurchaseOrderReceiveQty", nv);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblClinicQty.Text = (Convert.ToInt32(lblClinicQty.Text) - Convert.ToInt32(dt.Rows[0]["Qty"])).ToString();
                }
            }
        }
    }
}