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
    public partial class MateriaType : System.Web.UI.Page
    {
        Bal_MaterilaType objMT = new Bal_MaterilaType();

        public static DataTable AllData = new DataTable();
        General objGeneral = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getAllMaterialType();
            }
        }

        private long MaterialTypeId
        {
            get
            {
                if (ViewState["MaterialTypeId"] != null)
                {
                    return (long)ViewState["MaterialTypeId"];
                }
                return 0;
            }
            set
            {
                ViewState["MaterialTypeId"] = value;
            }
        }

        public DataTable getAllMaterialType()
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

                AllData = objMT.GetAllMaterialType(txtSearch.Text.Trim(), IsMedi);
                gvShow.DataSource = AllData;
                gvShow.DataBind();

                return AllData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void RadioBtnIsMedicalSearch_Select(object sender, EventArgs e)
        {

            getAllMaterialType();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objMT.AddMaterialType(MaterialTypeId, txtAdd.Text, RadioBtnIsMedical.SelectedValue);

                if (_isInserted == -1)
                {

                    string CloseWindow;
                    CloseWindow = "alert('Failed to Add  Inventory Type')";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "CloseWindow", CloseWindow, true);

                }
                else
                {

                    string CloseWindow;
                    CloseWindow = "alert('Inventory Type Added Successfully')";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "CloseWindow", CloseWindow, true);

                    txtAdd.Text = "";
                    RadioBtnIsMedical.ClearSelection();
                    getAllMaterialType();

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
            getAllMaterialType();

        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getAllMaterialType();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllMaterialType();
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
            DataView sortedView = new DataView(getAllMaterialType());
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            gvShow.DataSource = sortedView;
            gvShow.DataBind();
        }


        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objMT.DeleteMaterialType(ID);
                if (_isDeleted != -1)
                {
                    getAllMaterialType();
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
                    MaterialTypeId = Id;
                    DataTable Dt = objMT.GetSelectMaterialTYpe(Id);
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        txtAdd.Text = Dt.Rows[0]["MaterialName"].ToString();
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

            getAllMaterialType();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAdd.Text = "";
            Edit.Visible = false;
            Add.Visible = true;
        }

    }
}