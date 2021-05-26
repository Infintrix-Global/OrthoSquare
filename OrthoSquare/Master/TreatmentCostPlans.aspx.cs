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
    public partial class TreatmentCostPlans : System.Web.UI.Page
    {
        BAL_Treatment objES = new BAL_Treatment();
        public static DataTable AllData = new DataTable();
        BAL_DentalCategory objDC = new BAL_DentalCategory();
        BAL_TreatmentCostPlans objTCP = new BAL_TreatmentCostPlans();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDentalCategorySearch();
                Session["Searched"] = null;
                getAllTreatment();
                bindDentalCategory();
                getAllTreatmentCostPaln();
               

            }
        }
        public void getAllTreatment()
        {

            AllData = objES.GetAllTreatment();
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }



        public void getAllTreatmentCostPaln()
        {

            AllData = objTCP.GetAllTreatmentCostPlans(Convert .ToInt32 (ddlCategorySearch .SelectedValue ));
            GridTreatmentCostPlans.DataSource = AllData;
            GridTreatmentCostPlans.DataBind();
        }

        public void bindDentalCategory()
        {
            ddlCategory.DataSource = objDC.GetAllDentalCategory();
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Dental Category--", "0", true));

        }

        public void bindDentalCategorySearch()
        {
            ddlCategorySearch.DataSource = objDC.GetAllDentalCategory();
            ddlCategorySearch.DataValueField = "CategoryID";
            ddlCategorySearch.DataTextField = "CategoryName";
            ddlCategorySearch.DataBind();
            ddlCategorySearch.Items.Insert(0, new ListItem("-- Select Dental Category--", "0", true));

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {

            string TreatmentID = "";

            foreach (GridViewRow row in gvShow.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);

                    if (chkRow.Checked)
                    {
                        Label studentID = (row.Cells[0].FindControl("lblTreatmentID") as Label);

                        TreatmentID += studentID.Text + ","; 
                    }

                }
            }

            if (TreatmentID != "")
            {
                TreatmentID = TreatmentID.Remove(TreatmentID.Length - 1);
            }



            try
            {
                int _isInserted = -1;


                _isInserted = objTCP.AddTreatmentCostPlans(Convert.ToInt32(ddlCategory.SelectedValue), TreatmentID);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Treatment";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "Treatment Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    getAllTreatment();
                    bindDentalCategory();
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
             Edit.Visible = true;
            Add.Visible = false;
        
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }

        protected void GridTreatmentCostPlans_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(GridTreatmentCostPlans.DataKeys[e.RowIndex].Value);

                int _isDeleted = objTCP.DeleteTreatmentCostPlans(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];

                    lblMessage.Text = "Treatment Cost Plans Deleted.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("TreatmentCostPlans.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void gvShow_PageIndexChanging123(object sender, GridViewPageEventArgs e)
        {

            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }

        protected void GridTreatmentCostPlans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridTreatmentCostPlans.PageIndex = e.NewPageIndex;
            getAllTreatmentCostPaln();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "TreatmentName like '%" + txtSearch.Text + "%'";
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

        protected void ddlCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllTreatmentCostPaln();
        }

    }
}