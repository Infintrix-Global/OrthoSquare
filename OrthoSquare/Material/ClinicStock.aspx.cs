using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace OrthoSquare.Material
{
    public partial class ClinicStock : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        clsCommonMasters objcommon = new clsCommonMasters();
        Bal_MaterilaType objMtype = new Bal_MaterilaType();
        BAL_Clinic objc = new BAL_Clinic();
        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                MaterialType();
                getAllGridplaceorder();


            }
        }

        public void MaterialType()
        {
            try
            {
                ddlMaterialType.DataSource = objMtype.GetAllMaterialType("", "Material");
                ddlMaterialType.DataValueField = "MaterialTypeId";
                ddlMaterialType.DataTextField = "MaterialName";
                ddlMaterialType.DataBind();
                ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void getAllGridplaceorder()
        {

            DataTable AllData1 = objM.GetMaterialStock(ddlMaterialType.SelectedValue, txtMaterial.Text.Trim(), 2, Convert.ToInt32(Session["Empid"].ToString()));
            if (AllData1 != null && AllData1.Rows.Count > 0)
            {
                Gridplaceorder.DataSource = AllData1;
                Gridplaceorder.DataBind();
            }
        }



        protected void Gridplaceorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridplaceorder.PageIndex = e.NewPageIndex;
            getAllGridplaceorder();

        }

        protected void Gridplaceorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStockMaterialID = (Label)e.Row.FindControl("lblStockMaterialID");

                DataTable AllData1 = objM.GetMaterialStock("0",lblStockMaterialID.Text, 3, Convert.ToInt32(Session["Empid"].ToString()));

                if (AllData1 != null && AllData1.Rows.Count > 0)
                {
                    e.Row.Visible = false;
                
                }
            }
        }



    
        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblInstock = (Label)e.Row.FindControl("lblInstock");

                if (lblInstock.Text == "")
                {
                    lblInstock.Text = "0";

                }


            }

        }

        protected void txtOrderQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;
                int SelectedItems = 0;

                TextBox txtOrderQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtOrderQty.NamingContainer;
                if (row != null)
                {
                    Label lblMaterialTypeId = (Label)row.FindControl("lblMaterialTypeId");
                    Label lblMaterialId = (Label)row.FindControl("lblMaterialId");
                    Label lblBrandname1 = (Label)row.FindControl("lblBrandname1");
                    Label lblUUnit = (Label)row.FindControl("lblUUnit");
                    Label lblId = (Label)row.FindControl("lblId");
                    Label lblStockMaterialID = (Label)row.FindControl("lblStockMaterialID");

                    NameValueCollection nv = new NameValueCollection();

                    nv.Add("@ID", lblId.Text);
                    nv.Add("@MaterialId", lblMaterialId.Text);
                    nv.Add("@MaterialTypeId", lblMaterialTypeId.Text);
                    nv.Add("@Qty", txtOrderQty.Text);
                    nv.Add("@StockMaterialID", lblStockMaterialID.Text);
                    nv.Add("@CreateBy", Session["Empid"].ToString());
                    nv.Add("@mode","1");

                    _isInserted = objG.GetDataExecuteScaler("SP_AddMaterialStock", nv);
                }
                getAllGridplaceorder();

            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllGridplaceorder();
        }

    
    }
}