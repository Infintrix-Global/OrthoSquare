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
using System.IO;
using System.Net;
using PreconFinal.Utility;
using System.Data.OleDb;

namespace OrthoSquare.Master
{
    public partial class MaterialInOutDetails : System.Web.UI.Page
    {
        BAL_MaterialMaster objm = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                BindMaterial();
                BindVendor();
                getAllinoutmaterial();

            }

        }

        public void BindMaterial()
        {


            ddlMaterial.DataSource = objm.GetAllMaterial(0);
            ddlMaterial.DataTextField = "MaterialName";
            ddlMaterial.DataValueField = "MaterialId";
            ddlMaterial.DataBind();
            ddlMaterial.Items.Insert(0, new ListItem("--- Select ---", "0"));


            ddlMaterialSearch.DataSource = objm.GetAllMaterial(0);
            ddlMaterialSearch.DataTextField = "MaterialName";
            ddlMaterialSearch.DataValueField = "MaterialId";
            ddlMaterialSearch.DataBind();
            ddlMaterialSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void BindVendor()
        {


            ddlVendor.DataSource = objVendor.GetAllVendor (0,0);
            ddlVendor.DataTextField = "VendorName";
            ddlVendor.DataValueField = "VendorID";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ddlvenderSearch.DataSource = objVendor.GetAllVendor(0,0);
            ddlvenderSearch.DataTextField = "VendorName";
            ddlvenderSearch.DataValueField = "VendorID";
            ddlvenderSearch.DataBind();
            ddlvenderSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        private long InoutID
        {
            get
            {
                if (ViewState["InoutID"] != null)
                {
                    return (long)ViewState["InoutID"];
                }
                return 0;
            }
            set
            {
                ViewState["InoutID"] = value;
            }
        }


        public void getAllinoutmaterial()
        {



            AllData = objm.GetAllinoutmaterial(Convert.ToInt32(ddlvenderSearch.SelectedValue), Convert.ToInt32(ddlMaterialSearch.SelectedValue));
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
         
        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllinoutmaterial();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

          

            if (e.CommandName == "EditDocterDetails")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                InoutID = id;
                DataTable dt1 = objm.GetAllinoutmaterialSelect(Convert .ToInt32 (InoutID));


                txtOrderQty.Text = dt1.Rows[0]["OrderQty"].ToString();
                txtOrderDate.Text = Convert.ToDateTime(dt1.Rows[0]["OrderDate"]).ToString("dd-MM-yyyy");
                ddlMaterial.SelectedValue = dt1.Rows[0]["MaterialId"].ToString();
                ddlVendor.SelectedValue = dt1.Rows[0]["VendorID"].ToString();
                Div2.Visible = false;
                Add.Visible = true;
                Edit.Visible = false;

            }
            if (e.CommandName == "EditInouttime")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                InoutID = id;

                DataTable dt = objm.GetAllinoutmaterialSelect(Convert.ToInt32(InoutID));
                txtReceiveQty.Text = dt.Rows[0]["ReceiveQty"].ToString();
                if (dt.Rows[0]["Receiveddate"].ToString () != "")
                {
                    txtReceiveddate.Text = Convert.ToDateTime(dt.Rows[0]["Receiveddate"]).ToString("dd-MM-yyyy");
                }
                Div2.Visible = true;
                Add.Visible = false;
                Edit.Visible = false;
              
            }

          
           

        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);



            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objm.DeleteINOUTMaterial(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "In Out Material Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("MaterialInOutDetails.aspx");
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = -1;
          
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllinoutmaterial();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {


            try
            {
                int _isInserted = -1;




              //  _isInserted = objm.AddInOutMaterial(Convert .ToInt32 (InoutID), Convert.ToInt32(ddlMaterial.SelectedValue), Convert.ToInt32(ddlVendor.SelectedValue), txtOrderDate.Text, Convert.ToInt32(txtOrderQty.Text));


              
                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add In out Material Order";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "In out Material Order Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    txtOrderDate.Text = "";
                    txtOrderQty.Text = "";
                    BindMaterial();
                    BindVendor();
                    getAllinoutmaterial();
                }
            }
            catch (Exception ex)
            {
            }
        }



        protected void btnUpdateIOMaterial_Click(object sender, EventArgs e)
        {


            try
            {
                int _isInserted = -1;




                _isInserted = objm.AddInOutMaterialReceive(Convert.ToInt32(InoutID), txtReceiveddate.Text, Convert.ToInt32(txtReceiveQty.Text));



                if (_isInserted == -1)
                {
                    lblmsg1.Text = "Failed to Add In out Material Received Order ";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblmsg1.Text = "In out Material Received Order Added Successfully";
                    lblmsg1.ForeColor = System.Drawing.Color.Green;

                    txtReceiveddate.Text = "";
                    txtReceiveQty.Text = "";
                    getAllinoutmaterial();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnIOCancel_Click(object sender, EventArgs e)
        {
            Div2.Visible = false;
            Add.Visible = false;
            Edit.Visible = true;
            getAllinoutmaterial();
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            getAllinoutmaterial();
        }

        protected void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = objm.GetAllMaterialDetliat(Convert.ToInt32(ddlMaterial.SelectedValue));
            txtBrandName.Text = dt.Rows[0]["BrandName"].ToString();
            txtPrice.Text = dt.Rows[0]["Price"].ToString();

        }

        protected void txtOrderQty_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert .ToInt32 (txtOrderQty.Text) * Convert .ToInt32 (txtPrice.Text)).ToString ();

        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblReceiveQty = (Label)e.Row.FindControl("lblReceiveQty");
                Label lblTotalRec = (Label)e.Row.FindControl("lblTotalRec");

                lblTotal.Text = (Convert.ToInt32(lblPrice.Text) * Convert.ToInt32(lblOrderQty.Text)).ToString();
                lblTotalRec.Text = (Convert.ToInt32(lblPrice.Text) * Convert.ToInt32(lblReceiveQty.Text)).ToString();





            }
        }
    }
}