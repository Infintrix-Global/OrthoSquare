using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Master
{
    public partial class MaterialMaster : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Brand objBrand = new BAL_Brand();
        BAL_Pack objPack = new BAL_Pack();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                BindBrand();
                BindPack();
                getAllTreatment();
            }
        }

        private long Mid
        {
            get
            {
                if (ViewState["Mid"] != null)
                {
                    return (long)ViewState["Mid"];
                }
                return 0;
            }
            set
            {
                ViewState["Mid"] = value;
            }
        }

        public void BindBrand()
        {
            ddlBrand.DataSource = objBrand.GetAllBrand();
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void BindPack()
        {
            ddlPack.DataSource = objPack.GetAllPack();
            ddlPack.DataValueField = "PackId";
            ddlPack.DataTextField = "PackName";
            ddlPack.DataBind();
            ddlPack.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void getAllTreatment()
        {

            AllData = objM.GetAllMaterial(0);
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }


        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objM.AddMaterial(Mid, txtAdd.Text, Convert.ToInt32(ddlBrand.SelectedValue), Convert.ToInt32(ddlPack.SelectedValue), txtPrice.Text);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Material";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "Material Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtAdd.Text = "";
                    txtPrice.Text = "";
                    BindBrand();
                    BindPack();
                    getAllTreatment();
                    //   Response.Redirect("TreatmentMaster.aspx");
                    btSearch_Click(sender, e);
                    Mid = 0;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "MaterialName like '%" + txtSearch.Text + "%'";
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
                }
                else
                {
                    gvShow.DataSource = AllData;
                    gvShow.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objM.DeleteMaterial(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];

                    lblMessage.Text = "Material Deleted.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("MaterialMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
            getAllTreatment();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Update1")
            {
                int Mid1 = Convert.ToInt32(e.CommandArgument);
                Mid = Mid1;
                DataTable dt = objM.GetAllMaterialSelect(Mid1);

                txtAdd.Text = dt.Rows[0]["MaterialName"].ToString();
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
                BindBrand();
                if (dt.Rows[0]["BrandId"].ToString() != "")
                {
                    ddlBrand.SelectedValue = dt.Rows[0]["BrandId"].ToString();
                }
                BindPack();
                if (dt.Rows[0]["PackId"].ToString() != "")
                {
                    ddlPack.SelectedValue = dt.Rows[0]["PackId"].ToString();
                }
                Edit.Visible = false;
                Add.Visible = true;
            }
        }
    }
}