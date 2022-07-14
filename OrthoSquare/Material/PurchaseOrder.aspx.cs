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
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        Bal_MaterilaType objMT = new Bal_MaterilaType();
        BAL_Pack objPack = new BAL_Pack();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        clsCommonMasters objcommon = new clsCommonMasters();
        GeneralNew objG = new GeneralNew();
        General objGeneral = new General();
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
            nv.Add("@FromDate", txtFromDate.Text);
            nv.Add("@ToDate", txtToDate.Text);
            nv.Add("@PurchaseOrderId", "0");
            nv.Add("@OrderNo", "");
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


        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvviewOrder = e.Row.FindControl("gvviewOrder") as GridView;
                Label lblPurchaseOrderId = (Label)e.Row.FindControl("lblPurchaseOrderId");
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@VendorID", "0");
                nv.Add("@FromDate", txtFromDate.Text);
                nv.Add("@ToDate", txtToDate.Text);
                nv.Add("@PurchaseOrderId", lblPurchaseOrderId.Text);
                nv.Add("@OrderNo", "");
                nv.Add("@Mode", "2");
                DataTable dt = objG.GetDataTable("GET_MaterialStockPurchaseOrder", nv);
                gvviewOrder.DataSource = dt;
                gvviewOrder.DataBind();



            }



        }


        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }


        public void PurchaseOrdeNo()
        {
            txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

           // int Pno = objcommon.GetPurchaseOrde_No();
            txtPurchaseOrder.Text = "ORD" + GenerateRandomNo().ToString(); 

        }


        public void getPurchaseVendor()
        {

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@Id","0");
           
            DataTable dt = objG.GetDataTable("GET_PurchaseVendor", nv);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlVendor.DataSource = dt;
                ddlVendor.DataValueField = "VendorID";
                ddlVendor.DataTextField = "VendorName";
                ddlVendor.DataBind();
                ddlVendor.Items.Insert(0, new ListItem("--- Select Vendor ---", "0"));

            }


          
        }

        private void AddMedicinesRow(bool AddBlankRow)
        {
            try
            {

                string MaterialType = "", MaterialName = "", hdnWOEmployeeIDVal = "", PackName = "";
                string SlotPositionStart = "", SlotPositionEnd = "";

                List<MaterialDetails> objMedi = new List<MaterialDetails>();

                foreach (GridViewRow item in GridMateialStock.Rows)
                {
                    string inHouseValues = "";
                    string Morning = "";
                    string Afternoon = "";
                    string Evening = "";
                    hdnWOEmployeeIDVal = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;
                    MaterialType = ((DropDownList)item.FindControl("ddlMaterialType")).SelectedValue;
                    MaterialName = ((DropDownList)item.FindControl("ddlMaterialName")).SelectedValue;
                    PackName = ((DropDownList)item.FindControl("ddlPack")).SelectedValue;

                    TextBox txtQty = (TextBox)item.FindControl("txtQty");

                    TextBox txtRemark = (TextBox)item.FindControl("txtRemark");

                    AddMedicines(ref objMedi, Convert.ToInt32(hdnWOEmployeeIDVal), MaterialType, MaterialName, txtQty.Text, txtRemark.Text, PackName);
                }
                if (AddBlankRow)
                    AddMedicines(ref objMedi, 1, "0", "0", "0", "", "0");
                //GrowerPutData = objinvoice;
                GridMateialStock.DataSource = objMedi;
                GridMateialStock.DataBind();
                ViewState["Data"] = objMedi;
            }
            catch (Exception ex)
            {

            }
        }

        private void AddMedicines(ref List<MaterialDetails> objGP, int ID, string MaterialTypeId, string MaterialID, string Qty, string Remarks, string PackId)
        {
            MaterialDetails objM = new MaterialDetails();
            objM.ID = ID;
            objM.RowNumber = objGP.Count + 1;
            objM.MaterialTypeId = MaterialTypeId;
            objM.MaterialID = MaterialID;
            objM.Qty = Qty;
            objM.PackId = PackId;

            objM.Remarks = Remarks;

            objGP.Add(objM);
            ViewState["ojbpro"] = objGP;
        }

        public void GridSplitjob()
        {
            GridMateialStock.DataSource = ViewState["Data"];
            GridMateialStock.DataBind();
        }

        protected void GridMateialStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMaterialType = (DropDownList)e.Row.FindControl("ddlMaterialType");
                DropDownList ddlMaterialName = (DropDownList)e.Row.FindControl("ddlMaterialName");
                DropDownList ddlPack = (DropDownList)e.Row.FindControl("ddlPack");
                Label lblMaterialTypeid = (Label)e.Row.FindControl("lblMaterialTypeid");

                Label lblMaterialID = (Label)e.Row.FindControl("lblMaterialID");
                Label lblPack = (Label)e.Row.FindControl("lblPack");


                ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Material");
                ddlMaterialType.DataValueField = "MaterialTypeId";
                ddlMaterialType.DataTextField = "MaterialName";
                ddlMaterialType.DataBind();
                ddlMaterialType.Items.Insert(0, new ListItem("--- Select Inventory Type---", "0"));


                ddlPack.DataSource = objPack.GetAllPack();
                ddlPack.DataValueField = "PackId";
                ddlPack.DataTextField = "PackName";
                ddlPack.DataBind();
                ddlPack.Items.Insert(0, new ListItem("--- Select Packaging---", "0"));


                //ddlMedicinesType.Items.Insert(ddlMedicinesType.Items.Count, new ListItem("Other", "Other"));
                ddlMaterialType.SelectedValue = lblMaterialTypeid.Text;
                ddlPack.SelectedValue = lblPack.Text;
                BindMedicines(ref ddlMaterialName, lblMaterialTypeid.Text);
                ddlMaterialName.SelectedValue = lblMaterialID.Text;


            }
        }


        public void BindMedicines(ref DropDownList ddlMaterialName, string MaterialType)
        {


            AllData = objM.GetGtMaterial(MaterialType, "");

            ddlMaterialName.DataSource = AllData;
            ddlMaterialName.DataTextField = "MaterialName";
            ddlMaterialName.DataValueField = "MaterialId";
            ddlMaterialName.DataBind();
            ddlMaterialName.Items.Insert(0, new ListItem("---Item Name---", "0"));

        }



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddMedicinesRow(true);
        }

        protected void GridMateialStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<MaterialDetails> objinvoice = ViewState["ojbpro"] as List<MaterialDetails>;
            objinvoice.RemoveAt(e.RowIndex);
            GridMateialStock.DataSource = objinvoice;
            GridMateialStock.DataBind();


        }

        protected void ddlMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlMaterialType = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMaterialType.NamingContainer;
            if (row != null)
            {
                DropDownList ddlMaterialName = (DropDownList)row.FindControl("ddlMaterialName");

                string MedicinesType = "0";


                AllData = objM.GetGtMaterial(ddlMaterialType.SelectedValue, "");

                ddlMaterialName.DataSource = AllData;
                ddlMaterialName.DataTextField = "MaterialName";
                ddlMaterialName.DataValueField = "MaterialId";
                ddlMaterialName.DataBind();
                ddlMaterialName.Items.Insert(0, new ListItem("---Material Name---", "0"));

            }


        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int SelectedItems = 0;
            int PurchaseOrderId = -1;


            //NameValueCollection nv = new NameValueCollection();

            //nv.Add("@PurchaseOrderId", "0");
            //nv.Add("@OrderDate", objGeneral.getDatetime(txtDate.Text).ToString());
            //nv.Add("@OrderCode", txtPurchaseOrder.Text);
            //nv.Add("@VendorID", ddlVendor.SelectedValue);
            //nv.Add("@ShipAddress",txtshippingAddress.Text);
            //nv.Add("@Remark", txtReMarks.Text);
            //nv.Add("@CreateBy", Session["Empid"].ToString());

            //PurchaseOrderId = objG.GetDataExecuteScaler("SP_AddPurchaseOrderStock", nv);


            General objGeneral = new General();
            objGeneral.AddParameterWithValueToSQLCommand("@PurchaseOrderId", "0");
            objGeneral.AddParameterWithValueToSQLCommand("@OrderDate", objGeneral.getDatetime(txtDate.Text));
            objGeneral.AddParameterWithValueToSQLCommand("@OrderCode", txtPurchaseOrder.Text);
            objGeneral.AddParameterWithValueToSQLCommand("@VendorID", ddlVendor.SelectedValue);
            objGeneral.AddParameterWithValueToSQLCommand("@ShipAddress", txtshippingAddress.Text);
            objGeneral.AddParameterWithValueToSQLCommand("@Remark ", txtReMarks.Text);
            objGeneral.AddParameterWithValueToSQLCommand("@CreateBy ", Session["Empid"].ToString());
            PurchaseOrderId = objGeneral.GetExecuteScalarByCommand_SP("SP_AddPurchaseOrderStock");

            foreach (GridViewRow row in GridMateialStock.Rows)
            {
                int _isInserted = -1;

                if (row.RowType == DataControlRowType.DataRow)
                {
                    General objGeneral1 = new General();
                    TextBox txtRemark = (row.Cells[0].FindControl("txtRemark") as TextBox);
                    TextBox txtQty = (row.Cells[0].FindControl("txtQty") as TextBox);

                    DropDownList ddlMaterialType = (row.Cells[0].FindControl("ddlMaterialType") as DropDownList);
                    DropDownList ddlMaterialName = (row.Cells[0].FindControl("ddlMaterialName") as DropDownList);
                    DropDownList ddlPack = (row.Cells[0].FindControl("ddlPack") as DropDownList);
                    NameValueCollection nv1 = new NameValueCollection();

                    nv1.Add("@PurchaseOrderId", PurchaseOrderId.ToString());

                    nv1.Add("@MaterialId", ddlMaterialName.SelectedValue);
                    nv1.Add("@MaterialTypeId", ddlMaterialType.SelectedValue);
                    nv1.Add("@Qty", txtQty.Text);
                    nv1.Add("@Remark", txtRemark.Text);
                    nv1.Add("@PackID", ddlPack.SelectedValue);

                    _isInserted = objG.GetDataExecuteScaler("SP_AddPurchaseOrderDetailsStock", nv1);

                    SelectedItems++;

                }




            }



            objcommon.ShowMessage(this, "Added Successfully");


            GridMateialStock.DataSource = null;
            GridMateialStock.DataBind();
            PurchaseOrdeNo();
            getPurchaseVendor();
            txtReMarks.Text = "";
            txtshippingAddress.Text = "";
            AddMedicinesRow(true);

        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            GridMateialStock.DataSource = null;
            GridMateialStock.DataBind();
            PurchaseOrdeNo();
            getPurchaseVendor();
            txtReMarks.Text = "";
            txtshippingAddress.Text = "";


            AddMedicinesRow(true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            getAllOrderPurchaseList();
            Panellist.Visible = true;
            Add.Visible = false;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Panellist.Visible = false;
            Add.Visible = true;
            PurchaseOrdeNo();
            getPurchaseVendor();
            AddMedicinesRow(true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllOrderPurchaseList();
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

      

       
    }
}