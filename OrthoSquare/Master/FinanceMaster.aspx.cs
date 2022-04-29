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
    public partial class FinanceMaster : System.Web.UI.Page
    {
       
        BAL_Finance objF = new BAL_Finance();
        public static DataTable AllData = new DataTable();

        General objGeneral = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllFinance();
            }
        }

        private long Financeid
        {
            get
            {
                if (ViewState["Financeid"] != null)
                {
                    return (long)ViewState["Financeid"];
                }
                return 0;
            }
            set
            {
                ViewState["Financeid"] = value;
            }
        }

        public DataTable getAllFinance()
        {
            try
            {
                AllData = objF.GetAllFinance();
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


                _isInserted = objF.AddFinance(Financeid, txtFinanceName.Text.Trim(),txtInterestRate.Text.Trim());

                if (_isInserted == -1)
                {
                    // lblMessage.Text = "Failed to Add Brand";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to Add Finance')", true);

                }
                else
                {

                    //   lblMessage.Text = "Brand Added Successfully";
                    //  lblMessage.ForeColor = System.Drawing.Color.Green;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Finance Added Successfully')", true);

                    txtInterestRate.Text = "";
                    txtFinanceName.Text = "";
                    getAllFinance();
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
            getAllFinance();
        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "FinanceName like '%" + txtSearch.Text + "%'";
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
            DataView sortedView = new DataView(getAllFinance());
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

                int _isDeleted = objF.DeleteFinance(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];
                    Response.Redirect("FinanceMaster.aspx");
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
            getAllFinance();

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
                Financeid = ID;
                Edit.Visible = false;
                Add.Visible = true;
                DataTable dt = objF.GetSelectFinance(ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtFinanceName.Text = dt.Rows[0]["FinanceName"].ToString();
                    txtInterestRate.Text = dt.Rows[0]["InterestRate"].ToString();
                 
                }

            }
        }



  
    }
}