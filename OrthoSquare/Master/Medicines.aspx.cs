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

namespace OrthoSquare.Master
{
    public partial class Medicines : System.Web.UI.Page
    {
        Bal_MaterilaType objMT = new Bal_MaterilaType();
        Bal_UnitMaster objUnit = new Bal_UnitMaster();
        BAL_Medicines objMedicines = new BAL_Medicines();

        public static DataTable AllData = new DataTable();
        General objGeneral = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaterialType();
                BindUnit();
                getAllMedicines();
            }
        }

        private long MedicinesId
        {
            get
            {
                if (ViewState["MedicinesId"] != null)
                {
                    return (long)ViewState["MedicinesId"];
                }
                return 0;
            }
            set
            {
                ViewState["MedicinesId"] = value;
            }
        }

        public void MaterialType()
        {
            try
            {
                ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Medicine");
                ddlMaterialType.DataValueField = "MaterialTypeId";
                ddlMaterialType.DataTextField = "MaterialName";
                ddlMaterialType.DataBind();
                ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));

                ddlMaterialTypeSearch.DataSource = objMT.GetAllMaterialType("", "Material");
                ddlMaterialTypeSearch.DataValueField = "MaterialTypeId";
                ddlMaterialTypeSearch.DataTextField = "MaterialName";
                ddlMaterialTypeSearch.DataBind();
                ddlMaterialTypeSearch.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void BindUnit()
        {
            try
            {
                DataTable dt = objUnit.GetAllUnit("", "Medicine");
                ddlUnit.DataSource = dt;
                ddlUnit.DataValueField = "UnitId";
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, new ListItem("--- Select Unit---", "0"));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void getAllMedicines()
        {
            try
            {
                string MaterialType = "";

                if(ddlMaterialType.SelectedValue=="0")
                {
                    MaterialType = "";
                }
                else
                {
                    MaterialType = ddlMaterialTypeSearch.SelectedValue;
                }

                AllData = objMedicines.GetAllMedicines(txtMedicinesSearch.Text.Trim(), MaterialType);
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objMedicines.AddMedicines(MedicinesId, Convert.ToInt32(ddlMaterialType.SelectedValue),txtMedicines.Text.Trim(),txtCompanyName.Text.Trim(),Convert.ToInt32(ddlUnit.SelectedValue),txtPrice.Text);

                if (_isInserted == -1)
                {

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to Add Medicines')", true);
 
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Medicines Added Successfully')", true);

                    //   lblMessage.Text = "Unit Added Successfully";
                    //   lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearData();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void CleartextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {

                if ((c.GetType() == typeof(TextBox)))
                {



                    ((TextBox)(c)).Text = "";

                }


                if (c.HasControls())
                {

                    CleartextBoxes(c);

                }

            }
        }


        public void ClearData()
        {
            CleartextBoxes(this);
            BindUnit();
            MaterialType();
            getAllMedicines();
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();

        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getAllMedicines();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllMedicines();
        }



        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objMedicines.DeleteMedicines(ID);
                if (_isDeleted != -1)
                {
                    getAllMedicines();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateDetials")
            {
                try
                {

                    Edit.Visible = false;
                    Add.Visible = true;
                    int Id = Convert.ToInt32(e.CommandArgument);
                    MedicinesId = Id;
                    DataTable Dt = objMedicines.GetSelectMedicines(Id);
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        txtMedicines.Text = Dt.Rows[0]["MedicinesName"].ToString();
                        txtCompanyName.Text = Dt.Rows[0]["MedicinesCompany"].ToString();
                        MaterialType();
                        if (Dt.Rows[0]["MaterialTypeId"].ToString() != "")
                        {
                          ddlMaterialType.SelectedValue= Dt.Rows[0]["MaterialTypeId"].ToString();
                        }
                        BindUnit();
                        if (Dt.Rows[0]["UnitId"].ToString() != "")
                        {
                            ddlUnit.SelectedValue = Dt.Rows[0]["UnitId"].ToString();
                        }
                        txtPrice.Text = Dt.Rows[0]["Price"].ToString();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;

            getAllMedicines();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearData();
            Edit.Visible = false;
            Add.Visible = true;
        }
    }
}