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
    public partial class UnitMaster : System.Web.UI.Page
    {
        Bal_UnitMaster objUnit = new Bal_UnitMaster();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllUnit();
            }

        }

        private long UnitId
        {
            get
            {
                if (ViewState["UnitId"] != null)
                {
                    return (long)ViewState["UnitId"];
                }
                return 0;
            }
            set
            {
                ViewState["UnitId"] = value;
            }
        }

        public void getAllUnit()
        {
            try
            {
                string IsMedi = "";

                if (RadioBtnIsMedicalSearch.SelectedValue == "All")
                {
                    IsMedi = "";
                }
                else
                {
                    IsMedi = RadioBtnIsMedicalSearch.SelectedValue;
                }

                AllData = objUnit.GetAllUnit(txtSearch.Text.Trim(), IsMedi);
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


                _isInserted = objUnit.AddUnit(UnitId, txtAdd.Text, RadioBtnIsMedical.SelectedValue);

                if (_isInserted == -1)
                {
                    // lblMessage.Text = "Failed to Add Pack";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to Add Unit')", true);

                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Unit Added Successfully')", true);

                    //   lblMessage.Text = "Unit Added Successfully";
                    //   lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtAdd.Text = "";
                    RadioBtnIsMedical.ClearSelection();
                    getAllUnit();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            RadioBtnIsMedicalSearch.ClearSelection();
            RadioBtnIsMedicalSearch.Items.FindByText("All").Selected = true;
            getAllUnit();

        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getAllUnit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllUnit();
        }



        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objUnit.DeleteUnit(ID);
                if (_isDeleted != -1)
                {
                    getAllUnit();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                try
                {

                    Edit.Visible = false;
                    Add.Visible = true;
                    int Id = Convert.ToInt32(e.CommandArgument);
                    UnitId = Id;
                    DataTable Dt = objUnit.GetSelectUnit(Id);
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        txtAdd.Text = Dt.Rows[0]["UnitName"].ToString();
                        if (Dt.Rows[0]["IsMedical"].ToString() != "")
                        {
                            RadioBtnIsMedical.Items.FindByText(Dt.Rows[0]["IsMedical"].ToString()).Selected = true;
                        }
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

            getAllUnit();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAdd.Text = "";
            Edit.Visible = false;
            Add.Visible = true;
        }


    }
}