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
    public partial class LabDetails : System.Web.UI.Page
    {

        BAL_LabMasterNew objLab = new BAL_LabMasterNew();
        public static DataTable AllData = new DataTable();

        General objGeneral = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllLab();
            }
        }

        private long LabId
        {
            get
            {
                if (ViewState["LabId"] != null)
                {
                    return (long)ViewState["LabId"];
                }
                return 0;
            }
            set
            {
                ViewState["LabId"] = value;
            }
        }

        public DataTable getAllLab()
        {
            try
            {
                AllData = objLab.GetAllLab();
                if (AllData.Rows.Count > 0 && AllData != null)
                {
                    gvShow.DataSource = AllData;
                    gvShow.DataBind();
                }

                return AllData;
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


                _isInserted = objLab.AddLab(LabId, txtLabName.Text.Trim(), RadioCommissionType.SelectedItem.Text, txtCommission.Text.Trim(), SessionUtilities.Empid);

                if (_isInserted == -1)
                {
                    // lblMessage.Text = "Failed to Add Brand";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to Add Lab')", true);

                }
                else
                {

                    //   lblMessage.Text = "Brand Added Successfully";
                    //  lblMessage.ForeColor = System.Drawing.Color.Green;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Lab Added Successfully')", true);

                    txtCommission.Text = "";
                    txtLabName.Text = "";
                    getAllLab();
                    //  Response.Redirect("BrandMaster.aspx");
                    btSearch_Click(sender, e);
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
            getAllLab();
        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "LabName like '%" + txtSearch.Text + "%'";
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

                throw ex;
            }
        }

        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }

        protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {

                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }
            DataView sortedView = new DataView(getAllLab());
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            gvShow.DataSource = sortedView;
            gvShow.DataBind();
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

                int _isDeleted = objLab.DeleteLab(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];
                    Response.Redirect("LabMasterNew.aspx");
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
            getAllLab();

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
                int ID = Convert.ToInt32(e.CommandArgument);
                LabId = ID;
                Edit.Visible = false;
                Add.Visible = true;
                DataTable dt = objLab.GetSelectLab(ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtLabName.Text = dt.Rows[0]["LabName"].ToString();
                    txtCommission.Text = dt.Rows[0]["Commission"].ToString();
                    //    RadioCommissionType .SelectedItem.Text = dt.Rows[0]["CommissionType"].ToString();

                    //if (dt.Rows[0]["CommissionType"].ToString() != "")
                    //{
                    //    RadioCommissionType.Items.FindByText(dt.Rows[0]["CommissionType"].ToString()).Selected = true;
                    //}
                }

            }
        }



        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblCommissionType = (Label)e.Row.FindControl("lblCommissionType");


                    if (lblCommissionType.Text == "Rupee (?)")
                    {

                        lblCommissionType.Text = "Rupee";
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }
    }
}